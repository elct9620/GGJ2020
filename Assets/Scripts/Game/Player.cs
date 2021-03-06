﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movingTime = 0.1f;
    //public LayerMask blockingLayer;            //Layer on which collision will be checked.
    public float step = 0.01f;
    public GameObject note;
    public float noteSpeed = 1.0f;
    public Animator Animator;
    public List<AudioClip> ShootingSounds;
    public AudioSource Source;
    public GameObject NoteSelector;
    public int hurtedDuration = 60;

    // public GameObject movingArea;
    private BoxCollider2D boxCollider;         //The BoxCollider2D component attached to this object.
    private Rigidbody2D rb2D;                //The Rigidbody2D component attached to this object.
    private float inverseMoveTime;            //Used to make movement more efficient.
    private Vector2 endPosition;
    // Start is called before the first frame update

    public delegate void OnThrowEvent();
    public event OnThrowEvent OnThrow;

    private int hurted = 0;

    void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        inverseMoveTime = 1 / movingTime;

        OnThrow += () =>
        {
            Animator.SetTrigger("Throw");
            Source.clip = ShootingSounds[Mathf.FloorToInt(ShootingSounds.Count * Random.value)];
            Source.Play();
        };
    }

    // Update is called once per frame
    void Update()
    {
        // int horizontal;
        int vertical = 0;

        DetectMove(ref vertical);
        DetectShoot();

        if (vertical != 0)
        {
            tryMove(vertical);
        }

        if (hurted > 0)
        {
            hurted--;
            if (hurted == 0)
            {
                gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
        }
    }
    void DetectMove(ref int vertical)
    {
        switch (gameObject.name)
        {
            case ("Player1"):
                vertical = (int)(Input.GetAxisRaw("Player1Vertical"));
                break;
            case ("Player2"):
                vertical = (int)(Input.GetAxisRaw("Player2Vertical"));
                break;
        }
    }
    void DetectShoot()
    {
        switch (gameObject.name)
        {
            case ("Player1"):
                if (Input.GetKeyDown(KeyCode.D) && hurted == 0)
                {
                    Slot.Types? type = NoteSelector.GetComponent<NoteSelector>().useSelectedType();
                    if (type != null)
                    {
                        SpawnNote(1, noteSpeed, (Slot.Types)type);
                        if (OnThrow != null)
                            OnThrow.Invoke();
                    }
                }
                break;
            case ("Player2"):
                if (Input.GetKeyDown(KeyCode.LeftArrow) && hurted == 0)
                {
                    Slot.Types? type = NoteSelector.GetComponent<NoteSelector>().useSelectedType();
                    if (type != null)
                    {
                        SpawnNote(2, noteSpeed, (Slot.Types)type);
                        if (OnThrow != null)
                            OnThrow.Invoke();
                    }
                }
                break;
        }
    }

    public GameObject SpawnNote(int playerid, float speed, Slot.Types type)
    {
        Vector3 distanceNotePlayer = new Vector3(0, 0, 0);
        if (playerid == 1)
            distanceNotePlayer = new Vector3(1, 0, 0);
        else if (playerid == 2)
            distanceNotePlayer = new Vector3(-1, 0, 0);

        note.GetComponent<NoteMove>().player = playerid;
        note.GetComponent<NoteMove>().speed = speed;
        note.GetComponent<NoteMove>().SetType(type);
        GameObject noteShoot = Instantiate(note, transform.position + distanceNotePlayer, transform.rotation) as GameObject;
        return noteShoot;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "SlotShoot" && (
            (other.GetComponent<NoteMove>().player == 1 && gameObject.name == "Player2") ||
            (other.GetComponent<NoteMove>().player == 2 && gameObject.name == "Player1")
        ))
        {
            other.GetComponent<NoteMove>().startDisappear();
            gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 0.6f, 0.6f, 0.9f);
            hurted = hurtedDuration;
        }
    }

    void tryMove(int vertical)
    {
        Vector2 nowPosition = transform.position;
        endPosition = nowPosition + new Vector2(0, vertical * step);
        //RectTransform rt = movingArea.GetComponent<RectTransform>();
        float gap = 1;
        float topMost = 5 - gap * 2;
        float bottomMost = -5 + gap;
        if (endPosition.y > bottomMost && endPosition.y < topMost)
        {
            StopAllCoroutines();
            StartCoroutine(SmoothMovement(endPosition));

        }
        // transform.position = endPosition;
    }
    protected IEnumerator SmoothMovement(Vector3 end)
    {
        //Calculate the remaining distance to move based on the square magnitude of the difference between current position and end parameter. 
        //Square magnitude is used instead of magnitude because it's computationally cheaper.
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
        //While that distance is greater than a very small amount (Epsilon, almost zero):
        while (sqrRemainingDistance > float.Epsilon)
        {
            //Find a new position proportionally closer to the end, based on the moveTime
            Vector3 newPostion = Vector3.MoveTowards(rb2D.position, end, inverseMoveTime * Time.deltaTime);
            //Call MovePosition on attached Rigidbody2D and move it to the calculated position.
            rb2D.MovePosition(newPostion);

            //Recalculate the remaining distance after moving.
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;

            //Return and loop until sqrRemainingDistance is close enough to zero to end the function
            yield return null;
        }
    }
}
