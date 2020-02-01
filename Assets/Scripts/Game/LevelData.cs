using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Game/LevelData", order = 1)]
public class LevelData : ScriptableObject
{
    public string Name = "RepaTiti A";
    public List<ScoreData> Scores;
    public float Speed = 2.0f;
}