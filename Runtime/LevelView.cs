using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelView : MonoBehaviour
{
    public Image animationImage;
    public List<Button> wordButtons;

    public void SetAnimationSprite(Sprite sprite)
    {
        if (sprite != null)
        {
            animationImage.sprite = sprite;
            Debug.Log("Sprite set successfully.");
        }
        else
        {
            Debug.LogError("Failed to set sprite: sprite is null.");
        }
    }

    public void SetWordCombinations(List<string> combinations)
    {
        if (combinations == null)
        {
            Debug.LogError("Word combinations list is null.");
            return;
        }

        int numButtons = wordButtons.Count;

        for (int i = 0; i < combinations.Count; i++)
        {
            if (i < numButtons)
            {
                TextMeshProUGUI buttonText = wordButtons[i].GetComponentInChildren<TextMeshProUGUI>();
                if (buttonText != null)
                {
                    string combination = combinations[i]; // Store the combination in a local variable
                    buttonText.text = combination;
                    wordButtons[i].gameObject.SetActive(true);
                    
                    wordButtons[i].onClick.RemoveAllListeners();
                    // Use the local variable in the lambda instead of accessing combinations[i]
                    wordButtons[i].onClick.AddListener(() => EventAction.Instance.WordSelected(combination));
                }
                else
                {
                    Debug.LogError($"Button {i} is missing a TextMeshProUGUI component.");
                }
            }
        }

        // Deactivate remaining buttons
        for (int i = combinations.Count; i < numButtons; i++)
        {
            wordButtons[i].gameObject.SetActive(false);
        }
    }

    public void ShowIncorrectSelectionAnimation()
    {
        Debug.Log("Incorrect selection animation triggered.");
    }
}