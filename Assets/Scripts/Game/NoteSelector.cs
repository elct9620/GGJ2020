using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSelector : MonoBehaviour
{
    public Sprite CircleSprite;
    public Sprite SquareSprite;
    public Sprite TriangleSprite;
    
    private float circlePower = 0.0f;
    private float squarePower = 0.0f;
    private float trianglePower = 0.0f;

    private bool changed = true;
    private int regainCountDown = 15;

    private Slot.Types selected = Slot.Types.Circle;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (regainCountDown >= 0) {
            regainCountDown--;
        } else {
            if (circlePower <= 1.0f) {
                circlePower += 0.01f;
                changed = true;
            }
            if (squarePower <= 1.0f) {
                squarePower += 0.01f;
                changed = true;
            }
            if (trianglePower <= 1.0f) {
                trianglePower += 0.01f;
                changed = true;
            }
            regainCountDown = 15;
        }

        detectChange();

        if (changed) {
            switch(selected) {
                case Slot.Types.Circle:
                    gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, circlePower);
                break;
                case Slot.Types.Square:
                    gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, squarePower);
                break;
                case Slot.Types.Triangle:
                    gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, trianglePower);
                break;
            }
            changed = false;
        }
    }

    public Slot.Types? useSelectedType()
    {
        switch(selected) {
            case Slot.Types.Circle:
                if (circlePower <= 0.2f) { return null; }
                circlePower -= 0.2f;
            break;
            case Slot.Types.Square:
                if (squarePower <= 0.2f) { return null; }
                squarePower -= 0.2f;
            break;
            case Slot.Types.Triangle:
                 if (trianglePower <= 0.2f) { return null; }
                trianglePower -= 0.2f;
            break;
        }
        changed = true;
        return selected;
    }

    void detectChange()
    {
        if (
            (gameObject.transform.parent.name == "Player1" && Input.GetKeyDown(KeyCode.A)) ||
            (gameObject.transform.parent.name == "Player2" && Input.GetKeyDown(KeyCode.RightArrow))
        ) {
            switch(selected) {
                case Slot.Types.Circle:
                    selected = Slot.Types.Square;
                    gameObject.GetComponent<SpriteRenderer>().sprite = SquareSprite;
                break;
                case Slot.Types.Square:
                    selected = Slot.Types.Triangle;
                    gameObject.GetComponent<SpriteRenderer>().sprite = TriangleSprite;
                break;
                case Slot.Types.Triangle:
                    selected = Slot.Types.Circle;
                    gameObject.GetComponent<SpriteRenderer>().sprite = CircleSprite;

                break;
            }
            changed = true;
        }
    }
}
