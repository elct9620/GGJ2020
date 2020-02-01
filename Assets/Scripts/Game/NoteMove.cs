using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMove : MonoBehaviour
{
    public int player;
    public float speed;
    Rigidbody2D rb2D;
    public NoteMove(int playerNumber, float noteSpeed){
        player = playerNumber;
        speed = noteSpeed;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
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
    
    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        Destroy(gameObject);
    }
}
