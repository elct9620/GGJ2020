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
    public float WaitSecounds = 1.0f;

    public delegate void OnEndedEvent();
    public event OnEndedEvent OnEnded;

    private List<Track> _Tracks;
    private bool Ended = false;
    void Start()
    {
        _Tracks = new List<Track>();

        CreateTracks();
        StartCoroutine(PlayMusic());
    }

    // Update is called once per frame
    void Update()
    {
        if (Source.time >= Clip.length && !Ended)
        {
            if (OnEnded != null)
            {
                Ended = true;
                OnEnded.Invoke();
            }
        }
    }

    public void Replay()
    {
        foreach (Track track in _Tracks)
        {
            _Tracks.Remove(track);
            Destroy(track.gameObject);
        }

        Ended = false;
        CreateTracks();
        Source.time = 0;
        StartCoroutine(PlayMusic());
    }

    public IEnumerator PlayMusic()
    {
        Source.clip = Clip;
        yield return new WaitForSeconds(WaitSecounds);
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
            _Tracks.Add(track);
            index += 1;
        }
    }
}
