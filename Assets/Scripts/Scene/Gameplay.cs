using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class Gameplay : MonoBehaviour
{
    public static Text scoreText;
    public Text Time;
    public Text Name;
    public GameObject GO;
    public GameObject ResultPanel;
    public GameObject Player1;
    public GameObject Player2;
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
        float totalPlaybackTime = MusicPlayer.main.GetComponent<AudioSource>().clip.length;
        float playbackTime = totalPlaybackTime - MusicPlayer.main.Source.time;

        string minutes = Convert.ToString(Convert.ToInt32(Mathf.Floor(playbackTime / 60.0f)));
        string seconds = Convert.ToString(Convert.ToInt32(Mathf.Floor(playbackTime % 60)));

        Time.text = String.Format("{0}:{1}", minutes.PadLeft(2, '0'), seconds.PadLeft(2, '0'));
        if (minutes == "0" && seconds == "0")
        {
            ResultPanel.SetActive(true);
            ResultPanel.GetComponent<Animator>().Play("Popup");
        }
    }
    public static void UpdateScore()
    {
        Gameplay.score += 10;
        Gameplay.scoreText.text = "Score : " + Gameplay.score.ToString();
    }
    public void RestartGame()
    {
        // 重新開始
        MusicPlayer.main.Replay();
        ResultPanel.SetActive(false);
        Player1.transform.localPosition = new Vector3 (-4, 0, 0);
        Player2.transform.localPosition = new Vector3 (4, 0, 0);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Main");
    }
}
