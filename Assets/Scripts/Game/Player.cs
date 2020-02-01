using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movingTime = 0.1f;
    //public LayerMask blockingLayer;            //Layer on which collision will be checked.

    public GameObject movingArea;
    private BoxCollider2D boxCollider;         //The BoxCollider2D component attached to this object.
    private Rigidbody2D rb2D;                //The Rigidbody2D component attached to this object.
    private float inverseMoveTime;            //Used to make movement more efficient.

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        inverseMoveTime = 1 / movingTime;
    }

    // Update is called once per frame
    void Update()
    {
        // int horizontal;
        int vertical = 0;
        vertical = (int) (Input.GetAxisRaw ("Vertical"));

        if (vertical != 0)
        {
            Debug.LogError("in vertical!");
            tryMove(vertical);
        }
    }
    void tryMove(int vertical)
    {
        // mid = 379
        Vector2 nowPosition = transform.position;
        Vector2 endPosition = nowPosition + new Vector2 (0, vertical);
        RectTransform rt = movingArea.GetComponent<RectTransform>();
        float gap = 20;
        float topMost = 379 + rt.rect.height * 0.5f  - gap;
        float bottomMost = 379 - rt.rect.height * 0.5f  + gap;
        if (endPosition.y > bottomMost && endPosition.y < topMost)
            StartCoroutine(SmoothMovement(endPosition));
    }
    protected IEnumerator SmoothMovement (Vector3 end)
    {
        //Calculate the remaining distance to move based on the square magnitude of the difference between current position and end parameter. 
        //Square magnitude is used instead of magnitude because it's computationally cheaper.
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
        Debug.LogError("in sqrRemainingDistance!" + sqrRemainingDistance);
        //While that distance is greater than a very small amount (Epsilon, almost zero):
        while(sqrRemainingDistance > float.Epsilon)
        {   
            Debug.LogError("in float.Epsilon!" + float.Epsilon);
            //Find a new position proportionally closer to the end, based on the moveTime
            Vector3 newPostion = Vector3.MoveTowards(rb2D.position, end, inverseMoveTime * Time.deltaTime);

            //Call MovePosition on attached Rigidbody2D and move it to the calculated position.
            rb2D.MovePosition (newPostion);

            //Recalculate the remaining distance after moving.
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;

            //Return and loop until sqrRemainingDistance is close enough to zero to end the function
            yield return null;
        }
    }
}
