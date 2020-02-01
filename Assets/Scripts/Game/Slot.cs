using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public LevelData Level;
    // Start is called before the first frame update
    void Start()
    {
        Level = MusicPlayer.main.CurrentLevel;
    }

    // Update is called once per frame
    void Update()
    {
        float ySpeed = Level.Speed * Time.deltaTime;
        gameObject.transform.position -= new Vector3(0, ySpeed, 0);
    }
}