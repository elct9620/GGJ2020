using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Gameplay : MonoBehaviour
{
    public static Text scoreText;
    public Text Time;
    public Text Name;
    public GameObject GO;
    public static int score;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GO.GetComponent<Text>();
        Name.text = MusicPlayer.main.CurrentLevel.Name;
    }

    // Update is called once per frame
    void Update()
    {
        float playbackTime = MusicPlayer.main.Source.time;
        string minutes = Convert.ToString(Convert.ToInt32(Mathf.Floor(playbackTime / 60.0f)));
        string seconds = Convert.ToString(Convert.ToInt32(Mathf.Floor(playbackTime % 60)));

        Time.text = String.Format("{0}:{1}", minutes.PadLeft(2, '0'), seconds.PadLeft(2, '0'));
    }
    public static void UpdateScore()
    {
        Gameplay.score += 10;
        Gameplay.scoreText.text = "Score : " + Gameplay.score.ToString();
    }
}
