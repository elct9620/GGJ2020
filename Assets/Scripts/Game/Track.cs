using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    public List<Slot> Slots;
    public Score Score;
    // Start is called before the first frame update
    void Start()
    {
        Slots = new List<Slot>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
