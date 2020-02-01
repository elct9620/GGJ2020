using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
    

// [System.Serializable]
// public class PlaygroundSettings
// {
//     public float width;
//     public float height;
//     public int[] notes;
//     public GameObject background;
// }
public class PlayerManager : MonoBehaviour
{
    public float width;
    public float height;
    public int[] notes;
    public GameObject background1;
    public GameObject background2;

    // PlaygroundSettings m_PlayergronudSettings = new PlaygroundSettings();
    // Start is called before the first frame update
    void Start()
    {
        RectTransform rt = background1.GetComponent<RectTransform>();
        RectTransform rt2 = background2.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2 (width, height);
        rt2.sizeDelta = new Vector2 (width, height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
