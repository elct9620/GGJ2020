using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Game/Level", order = 1)]
public class Level : ScriptableObject
{
    public List<Score> Scores;
}