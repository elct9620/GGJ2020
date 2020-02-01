using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public LevelData Level;
    public AudioSource Source;

    public NoteData Note;
    // Collider Height
    public float BeatOffset = 1.0f;
    public float yOffset = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Level = MusicPlayer.main.CurrentLevel;
        Source = MusicPlayer.main.Source;

        yOffset = Camera.main.orthographicSize * -1;
    }

    // Update is called once per frame
    void Update()
    {
        float offsetTime = Source.time - Note.Time;
        float yPosition = yOffset + (offsetTime * Level.Speed * -1.0f) + BeatOffset;
        Vector3 currentPosition = gameObject.transform.position;
        gameObject.transform.position = new Vector3(currentPosition.x, yPosition, currentPosition.z);
    }
}