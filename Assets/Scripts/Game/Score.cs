using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Score", menuName = "Game/Score", order = 1)]
public class Score : ScriptableObject
{
    public List<Note> Notes;
}