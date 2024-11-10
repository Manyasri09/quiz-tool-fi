using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 1)]
public class LevelData : ScriptableObject
{
    public int LevelNumber;  // Level number
    public Sprite AnimationSprite;  // Sprite for the level animation
    public List<string> WordCombinations;  // List of word combinations for the buttons
    public string CorrectCombination;  // The correct combination (the title)
}
