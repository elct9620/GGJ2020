using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMove : MonoBehaviour
{
    public int player;
    public float speed;
    public float disappearAfterSeconds = 0.4f;

    public Sprite CircleSprite;
    public Sprite SquareSprite;
    public Sprite TriangleSprite;
    public Slot.Types Type;
    Rigidbody2D rb2D;
    public NoteMove(int playerNumber, float noteSpeed){
        player = playerNumber;
        speed = noteSpeed;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(disappearing());
    }

    public void SetType(Slot.Types type)
    {
        Type = type;
        switch (type)
        {
            case Slot.Types.Circle:
                gameObject.GetComponent<SpriteRenderer>().sprite = CircleSprite;
                break;
            case Slot.Types.Square:
                gameObject.GetComponent<SpriteRenderer>().sprite =  SquareSprite;
                break;
            case Slot.Types.Triangle:
                gameObject.GetComponent<SpriteRenderer>().sprite =  TriangleSprite;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {   
        if (player == 1)
        {
            transform.position += new Vector3(speed * Time.deltaTime,  0, 0);
            // Vector3 end = transform.position + new Vector3 (speed, 0, 0);
            // Vector3 newPostion = Vector3.MoveTowards(rb2D.position, end, speed * Time.deltaTime);
            // rb2D.MovePosition (newPostion);

        }
        else if (player == 2)
            transform.Translate(new Vector2(-1 * speed, 0) * Time.deltaTime);
    }

    public IEnumerator disappearing()
    {
        yield return new WaitForSeconds(disappearAfterSeconds);
        float alpha = 1.0f;
        while(alpha >= 0.0f) {
            alpha -= 0.1f;
            gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, alpha);
            yield return new WaitForSeconds(0.03f);
        }
        Destroy(gameObject);
    }
    
    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        Destroy(gameObject);
    }
}
