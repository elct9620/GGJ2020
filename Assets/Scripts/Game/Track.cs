using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    public GameObject Slots;
    public Slot SlotPrefab;
    public Score Score;
    public AudioSource Source;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateNote());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public IEnumerator CreateNote()
    {
        foreach (Note note in Score.Notes)
        {
            while (note.Time >= Source.time)
            {
                yield return null;
            }

            Slot slot = Instantiate(SlotPrefab, Slots.transform);
        }
    }
}
