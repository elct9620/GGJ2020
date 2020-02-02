using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Opening : MonoBehaviour
{
    public Text Message;
    public float typeSpeed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Typing());
    }

    public IEnumerator Typing()
    {
        char[] characters = Message.text.ToCharArray();
        Message.text = "";
        yield return new WaitForSeconds(0.5f);

        foreach (char word in characters)
        {
            Message.text += word;
            yield return new WaitForSeconds(typeSpeed);
        }

        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("PlaySheet");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
