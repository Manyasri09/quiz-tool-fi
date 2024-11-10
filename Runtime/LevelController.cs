using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public LevelView levelView;  // Reference to the LevelView component
    public LevelContainer levelContainer;  // Reference to the container that holds levels
    private int currentLevelIndex;  // Index to track the current level

    private void OnEnable()
    {
        // Subscribe to the word selection event
        EventAction.OnWordSelected += OnWordButtonSelected;
        Debug.Log("Event subscribed: OnWordSelected");
    }

    private void OnDisable()
    {
        // Unsubscribe from the word selection event
        EventAction.OnWordSelected -= OnWordButtonSelected;
        Debug.Log("Event unsubscribed: OnWordSelected");
    }

    private void Start()
    {
        // Initialize the game by setting the current level index to 0 (first level)
        currentLevelIndex = 0;
        Debug.Log("Starting game. Loading level: " + currentLevelIndex);
        LoadLevel(currentLevelIndex);
    }

    private void LoadLevel(int levelIndex)
    {
        // Ensure the level index is within the valid range
        if (levelIndex < levelContainer.Levels.Count)
        {
            var level = levelContainer.Levels[levelIndex];
            if (level != null)
            {
                Debug.Log("Loading Level: " + level.LevelNumber);

                // Set the sprite for the current level's animation
                if (level.AnimationSprite != null)
                {
                    Debug.Log("Sprite loaded successfully.");
                    levelView.SetAnimationSprite(level.AnimationSprite); // Set the sprite directly
                }
                else
                {
                    Debug.LogError("Failed to load sprite: sprite is null.");
                }

                // Set the word combinations for the buttons
                levelView.SetWordCombinations(level.WordCombinations);
                Debug.Log("Loaded Level " + level.LevelNumber);
            }
            else
            {
                Debug.LogError("Level data is null for level index: " + levelIndex);
            }
        }
        else
        {
            Debug.LogError("Invalid level index: " + levelIndex);
        }
    }

    // Event handler when a word button is selected
    public void OnWordButtonSelected(string selectedWord)
    {
        var level = levelContainer.Levels[currentLevelIndex];
        if (level != null)
        {
            // Check if the selected word matches the correct combination (which is the title)
            if (selectedWord == level.CorrectCombination)
            {
                Debug.Log("Correct word (title) selected: " + selectedWord);

                // Move to the next level
                currentLevelIndex++;

                // Check if there are more levels
                if (currentLevelIndex < levelContainer.Levels.Count)
                {
                    Debug.Log("Loading next level: " + currentLevelIndex);
                    LoadLevel(currentLevelIndex);  // Load the next level
                }
                else
                {
                    Debug.Log("Game Complete");
                }
            }
            else
            {
                Debug.Log("Incorrect word selected: " + selectedWord);
                levelView.ShowIncorrectSelectionAnimation();  // Show incorrect selection animation
            }
        }
        else
        {
            Debug.LogError("Level data is null for current level index: " + currentLevelIndex);
        }
    }
}
