using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelContainer", menuName = "ScriptableObjects/LevelContainer", order = 2)]
public class LevelContainer : ScriptableObject
{
    public List<LevelData> Levels;  // List of levels in the game
}
