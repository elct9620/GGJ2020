using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public Track TrackPrefab;
    public AudioSource Source;
    public AudioClip Clip;
    public Level CurrentLevel;
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
        int startX = totalTrack / 2 - totalTrack;
        int index = 0;

        foreach (Score score in CurrentLevel.Scores)
        {
            float x = (startX + index) * 1.0f - 0.5f;
            Track track = Instantiate(TrackPrefab, new Vector3(x, 0, 0), Quaternion.identity, gameObject.transform);
            track.Score = score;
            track.Source = Source;
            index += 1;
        }
    }
}
