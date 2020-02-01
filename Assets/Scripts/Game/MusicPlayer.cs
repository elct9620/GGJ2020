using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer _Instance;
    public static MusicPlayer main
    {
        get
        {
            if (!_Instance)
            {
                GameObject main = GameObject.FindWithTag("MainMusicPlayer");
                _Instance = main.GetComponent<MusicPlayer>();
            }

            return _Instance;
        }
    }
    public Track TrackPrefab;
    public AudioSource Source;
    public AudioClip Clip;
    public LevelData CurrentLevel;
    void Start()
    {
        CreateTracks();
        PlayMusic();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void PlayMusic()
    {
        Source.clip = Clip;
        Source.Play();
    }

    private void CreateTracks()
    {
        int totalTrack = CurrentLevel.Scores.Count;
        float startX = totalTrack / 2.0f - totalTrack;
        int index = 0;

        foreach (ScoreData score in CurrentLevel.Scores)
        {
            float x = startX + index + 0.5f;
            Track track = Instantiate(TrackPrefab, new Vector3(x, 0, 0), Quaternion.identity, gameObject.transform);
            track.Score = score;
            index += 1;
        }
    }
}
