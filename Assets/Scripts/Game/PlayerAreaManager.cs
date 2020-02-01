using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
    
public class PlayerManager : MonoBehaviour
{
    public float width;
    public float height;
    public int[] notes;
    public GameObject background1;
    public GameObject background2;
    public Canvas mainCanvas;

    // PlaygroundSettings m_PlayergronudSettings = new PlaygroundSettings();
    // Start is called before the first frame update
    void Start()
    {
        RectTransform rt = background1.GetComponent<RectTransform>();
        RectTransform rt2 = background2.GetComponent<RectTransform>();
        float heightScaleNumber = mainCanvas.GetComponent<RectTransform>().sizeDelta.y / 5;
        float widthScaleNumber = mainCanvas.GetComponent<RectTransform>().sizeDelta.x / 5;
        rt.sizeDelta = new Vector2 (width * widthScaleNumber, height * heightScaleNumber);
        rt2.sizeDelta = new Vector2 (width * widthScaleNumber, height * heightScaleNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
