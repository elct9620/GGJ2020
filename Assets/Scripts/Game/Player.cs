using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movingTime = 0.1f;
    //public LayerMask blockingLayer;            //Layer on which collision will be checked.
    public int step = 10;
    
    public GameObject movingArea;
    private BoxCollider2D boxCollider;         //The BoxCollider2D component attached to this object.
    private Rigidbody2D rb2D;                //The Rigidbody2D component attached to this object.
    private float inverseMoveTime;            //Used to make movement more efficient.
    private Vector2 endPosition;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        inverseMoveTime = 1 / movingTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // int horizontal;
        int vertical = 0;
        switch (gameObject.name)
        {
            case ("Player1"):
                vertical = (int) (Input.GetAxisRaw ("Player1Vertical"));
                break;
            case ("Player2"):
                vertical = (int) (Input.GetAxisRaw ("Player2Vertical"));
                break;
        }
        

        if (vertical != 0)
        {
            Debug.LogError("in vertical!");
            tryMove(vertical);
        }
    }
    void tryMove(int vertical)
    {
        Vector2 nowPosition = transform.position;
        endPosition = nowPosition + new Vector2 (0, 10 * vertical);
        RectTransform rt = movingArea.GetComponent<RectTransform>();
        float gap = 20;
        float topMost =  rt.rect.height * 0.5f  - gap;
        float bottomMost = -1 * rt.rect.height * 0.5f  + gap;
        if (endPosition.y > bottomMost && endPosition.y < topMost)
        {
            StopAllCoroutines();
            StartCoroutine(SmoothMovement(endPosition));

        }
            // transform.position = endPosition;
    }
    protected IEnumerator SmoothMovement (Vector3 end)
    {
        //Calculate the remaining distance to move based on the square magnitude of the difference between current position and end parameter. 
        //Square magnitude is used instead of magnitude because it's computationally cheaper.
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
        //While that distance is greater than a very small amount (Epsilon, almost zero):
        while(sqrRemainingDistance > float.Epsilon)
        {   
            //Find a new position proportionally closer to the end, based on the moveTime
            Vector3 newPostion = Vector3.MoveTowards(rb2D.position, end, step * inverseMoveTime * Time.deltaTime);
            Debug.LogError("in newPostion!" + newPostion);
            //Call MovePosition on attached Rigidbody2D and move it to the calculated position.
            rb2D.MovePosition (newPostion);

            //Recalculate the remaining distance after moving.
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;

            //Return and loop until sqrRemainingDistance is close enough to zero to end the function
            yield return null;
        }
    }
}
