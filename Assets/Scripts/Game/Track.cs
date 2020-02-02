using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    public GameObject Slots;
    public Slot SlotPrefab;
    public ScoreData Score;
    public AudioSource Source;
    public LevelData Level;
    public float TimeOffset = 0.0f;
    public float SquarePitchPercentage = 0.33f;
    public float TrianglePitchPercentage = 0.66f;
    public float FilledPercentage = 0.5f;
    public SpriteRenderer BottomFire;
    public int PreferCombo = 10;

    public int Combo = 0;
    public int ComboBonusScaler = 10;

    // Start is called before the first frame update
    void Start()
    {
        Source = MusicPlayer.main.Source;
        Level = MusicPlayer.main.CurrentLevel;

        TimeOffset = Camera.main.orthographicSize * 2;

        UpdateBottomAlpha();
        StartCoroutine(CreateNote());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public IEnumerator CreateNote()
    {
        int maxPitch = 0, minPitch = 100000;
        foreach (NoteData note in Score.Notes)
        {
            if (maxPitch < note.Pitch) { maxPitch = note.Pitch; }
            if (minPitch > note.Pitch) { minPitch = note.Pitch; }
        }
        int squarePitch = (int)Mathf.Lerp((float)minPitch, (float)maxPitch, SquarePitchPercentage);
        int trianglePitch = (int)Mathf.Lerp((float)minPitch, (float)maxPitch, TrianglePitchPercentage);

        foreach (NoteData note in Score.Notes)
        {
            while (note.Time >= Source.time + TimeOffset)
            {
                yield return null;
            }

            Slot slot = Instantiate(SlotPrefab, Slots.transform);
            slot.Note = note;
            if (note.Pitch > trianglePitch)
            {
                slot.SetType(Slot.Types.Triangle);
            }
            else if (note.Pitch > squarePitch)
            {
                slot.SetType(Slot.Types.Square);
            }
            else
            {
                slot.SetType(Slot.Types.Circle);
            }
            slot.Source.clip = Score.Clip;

            if (Random.value < FilledPercentage)
            {
                slot.Filled = true;
            }

            slot.OnExit += OnSlotExit;
        }
    }

    public void OnSlotExit(bool Filled)
    {
        if (!Filled)
        {
            Combo = 0;
            UpdateBottomAlpha();
            return;
        }

        Combo += 1;
        UpdateBottomAlpha();
    }

    void AddComboBonus()
    {
        Gameplay.score += Combo * ComboBonusScaler;
    }

    private void UpdateBottomAlpha()
    {
        float alpha = Mathf.Lerp(0.25f, 1.0f, (Combo * 1.0f) / (PreferCombo * 1.0f));
        BottomFire.color = new Color(BottomFire.color.r, BottomFire.color.g, BottomFire.color.b, alpha);
    }
}
