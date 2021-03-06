﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreData", menuName = "Game/ScoreData", order = 1)]
public class ScoreData : ScriptableObject
{
    public List<NoteData> Notes;
    public AudioClip Clip;
    public float PitchTransposeAdd = -60.0f;
    public float PitchTransposeDivision = 12.0f;
}