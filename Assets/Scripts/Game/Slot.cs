using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{
    public enum Types { Circle, Square, Triangle };
    public LevelData Level;
    public AudioSource MainSource;
    public AudioSource Source;
    public Sprite CircleSprite;
    public Sprite SquareSprite;
    public Sprite TriangleSprite;
    public SpriteRenderer Sprite;

    public GameObject ScoreText;

    public NoteData Note;
    // Collider Height
    public float BeatOffset = 1.0f;
    public float yOffset = 0.0f;
    public float TrackEnd = 0.0f;
    public bool Filled = false;

    private bool PlayEnd = false;
    public Types Type;
    public ParticleSystem Effect;

    public delegate void OnExitEvent(bool IsFilled);
    public event OnExitEvent OnExit;

    // Start is called before the first frame update
    void Start()
    {
        Level = MusicPlayer.main.CurrentLevel;
        MainSource = MusicPlayer.main.Source;

        yOffset = Camera.main.orthographicSize * -1;
        TrackEnd = yOffset + BeatOffset / 2;

        /*
                int PitchOffset = Note.Pitch - 60;
                int AbsPitchOffset = Mathf.Abs(PitchOffset);
                int PitchDirection = 1;
                if (PitchOffset != 0)
                {
                    PitchDirection = PitchOffset / AbsPitchOffset;
                }
                else
                {
                    PitchDirection = 1;
                }
        */

        // https://stackoverflow.com/questions/36793628/frequency-and-pitch-relation-for-audioclip-unity3d
        float transpose = -4;
        float note = Note.Pitch - 56f; // Magic number for our midi
        Source.pitch = Mathf.Pow(2, (note + transpose) / 12.0f);

        // Source.pitch = Mathf.Pow(1.05946f, AbsPitchOffset) * PitchDirection;

        UpdateOpacity();
    }

    public void SetType(Types type)
    {
        Type = type;
        switch (type)
        {
            case Types.Circle:
                Sprite.sprite = CircleSprite;
                break;
            case Types.Square:
                Sprite.sprite = SquareSprite;
                break;
            case Types.Triangle:
                Sprite.sprite = TriangleSprite;
                break;
        }
    }

    public bool IsType(Types type)
    {
        return Type == type;
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
            Sprite.enabled = false;
            Destroy(gameObject, 10.0f);

            if (OnExit != null)
            {
                OnExit.Invoke(Filled);
            }
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

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (Filled)
        {
            return;
        }

        if (other.tag == "SlotShoot")
        {
            if (other.GetComponent<NoteMove>().Type == Type)
            {
                Filled = true;
                UpdateOpacity();
                Gameplay.UpdateScore();
                Effect.Emit(1);
                Destroy(other.gameObject);
            }
        }
    }

    public void UpdateOpacity()
    {
        if (Filled)
        {
            Sprite.color = new Color(Sprite.color.r, Sprite.color.g, Sprite.color.b, 1.0f);
        }
        else
        {
            Sprite.color = new Color(Sprite.color.r, Sprite.color.g, Sprite.color.b, 0.5f);
        }
    }

}