﻿using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
        Source = MusicPlayer.main.Source;
        Level = MusicPlayer.main.CurrentLevel;

        TimeOffset = Camera.main.orthographicSize * 2;

        StartCoroutine(CreateNote());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public IEnumerator CreateNote()
    {
        System.Array values = System.Enum.GetValues(typeof(Slot.Types));
        Random random = new Random();
        foreach (NoteData note in Score.Notes)
        {
            while (note.Time >= Source.time + TimeOffset)
            {
                yield return null;
            }

            Slot slot = Instantiate(SlotPrefab, Slots.transform);
            slot.Note = note;
            slot.SetType((Slot.Types) values.GetValue(Mathf.FloorToInt(Random.value * values.Length)));
            slot.Source.clip = Score.Clip;
        }
    }
}
