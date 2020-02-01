using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public LevelData Level;
    public AudioSource MainSource;
    public AudioSource Source;

    public NoteData Note;
    // Collider Height
    public float BeatOffset = 1.0f;
    public float yOffset = 0.0f;
    public float TrackEnd = 0.0f;
    public bool Filled = false;

    private bool PlayEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        Level = MusicPlayer.main.CurrentLevel;
        MainSource = MusicPlayer.main.Source;

        yOffset = Camera.main.orthographicSize * -1;
        TrackEnd = yOffset - BeatOffset;

        int PitchOffset = Note.Pitch - 65;
        int AbsPitchOffset = Mathf.Abs(PitchOffset);
        int PitchDirection = PitchOffset / AbsPitchOffset;
        Source.pitch = Mathf.Pow(1.05946f, AbsPitchOffset) * PitchDirection;
    }

    bool CanPlay()
    {
        if (Note.Time > MainSource.time || PlayEnd || !Filled)
        {
            return false;
        }

        return true;
    }

    // Update is called once per frame
    void Update()
    {
        float offsetTime = MainSource.time - Note.Time;
        float yPosition = yOffset + (offsetTime * Level.Speed * -1.0f) + BeatOffset;
        Vector3 currentPosition = gameObject.transform.position;
        gameObject.transform.position = new Vector3(currentPosition.x, yPosition, currentPosition.z);

        if (TrackEnd >= yPosition)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        if (CanPlay())
        {
            Source.Play();
            PlayEnd = true;
        }
    }
}