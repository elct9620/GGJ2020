using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gameplay : MonoBehaviour
{
    public static Text scoreText;
    public GameObject GO;
    public static int score;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GO.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public static void UpdateScore()
    {
        Gameplay.score += 10;
        Gameplay.scoreText.text = "Score : " + Gameplay.score.ToString();
    }
}
