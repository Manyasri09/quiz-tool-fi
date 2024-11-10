using System;
using UnityEngine;

public class EventAction : MonoBehaviour
{
    public static EventAction Instance { get; private set; }  // Singleton instance
    public static event Action<string> OnWordSelected;  // Event to be triggered when a word is selected

    // Ensure only one instance of EventAction exists in the scene
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);  // Destroy duplicate instance
        }
        else
        {
            Instance = this;  // Assign the singleton instance
        }
    }

    // Method to trigger the OnWordSelected event
    public void WordSelected(string word)
    {
        OnWordSelected?.Invoke(word);  // This triggers the event
        Debug.Log("Word selected: " + word);
    }
}
