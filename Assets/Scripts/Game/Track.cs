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

    // Start is called before the first frame update
    void Start()
    {
        Source = MusicPlayer.main.Source;
        Level = MusicPlayer.main.CurrentLevel;

        StartCoroutine(CreateNote());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public IEnumerator CreateNote()
    {
        foreach (NoteData note in Score.Notes)
        {
            while (note.Time >= Source.time)
            {
                yield return null;
            }

            Slot slot = Instantiate(SlotPrefab, Slots.transform);
        }
    }
}
