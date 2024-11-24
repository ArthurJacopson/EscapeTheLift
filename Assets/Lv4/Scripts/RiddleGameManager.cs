using System.Collections.Generic; // Needed for List
using UnityEngine;
using TMPro;

public class RiddleGameManager : MonoBehaviour
{
    [System.Serializable]
    public class Riddle
    {
        public string text; // The riddle question
        public int correctGridIndex; // The index of the correct grid (1-9)
    }

    public TextMeshProUGUI screenText; // Reference to the text on the screen
    public GameObject player; // Reference to the player object
    public List<Riddle> riddles = new List<Riddle>(); // Editable list of riddles in the Inspector

    private int currentRiddleIndex = 0; // Keeps track of the current riddle

    void Start()
    {
        // Add predefined riddles if none are assigned in the Inspector
        if (riddles.Count == 0)
        {
            InitializeDefaultRiddles();
        }

        if (riddles.Count > 0)
        {
            ShowNextRiddle(); // Display the first riddle when the game starts
        }
        else
        {
            Debug.LogError("No riddles assigned in the RiddleGameManager!");
        }
    }

    void InitializeDefaultRiddles()
    {
        riddles.Add(new Riddle
        {
            text = "I am round, red, and have a sweet core. In pies and jams, I'm loved even more. What am I?",
            correctGridIndex = 1
        });
        riddles.Add(new Riddle
        {
            text = "I give light but not heat, When I am on, you will clearly see. Flip the switch to summon me. What am I?",
            correctGridIndex = 9
        });
        riddles.Add(new Riddle
        {
            text = "I have hands but no arms, Numbers but no legs. I measure the moments, And set the day’s stage. What am I?",
            correctGridIndex = 8
        });
        riddles.Add(new Riddle
        {
            text = "I am a tool, smooth and sharp, From paper to wood, I leave my mark. Be careful though, I am not a toy. Who am I?",
            correctGridIndex = 4
        });
        riddles.Add(new Riddle
        {
            text = "I have keys but no locks, I have space but no room. You can enter, but you can’t leave. What am I?",
            correctGridIndex = 6
        });
        riddles.Add(new Riddle
        {
            text = "I’m rooted to the ground, Yet my arms reach to the sky. I provide shade and fruit to those nearby. What am I?",
            correctGridIndex = 2
        });
        riddles.Add(new Riddle
        {
            text = "I can be cracked, made, told, or played. In the cold, I’m best displayed. What am I?",
            correctGridIndex = 7
        });
        riddles.Add(new Riddle
        {
            text = "The more you take, the more you leave behind. On every path, I’m easy to find. What am I?",
            correctGridIndex = 3
        });
    }

    void ShowNextRiddle()
    {
        if (currentRiddleIndex < riddles.Count)
        {
            // Display the current riddle text on the screen
            screenText.text = riddles[currentRiddleIndex].text;
        }
        else
        {
            // Game complete, show completion message
            screenText.text = "Congratulations! You’ve solved all the riddles!";
        }
    }

    public void CheckPlayerAnswer(int gridIndex)
    {
        if (currentRiddleIndex >= riddles.Count) return;

        if (gridIndex == riddles[currentRiddleIndex].correctGridIndex)
        {
            Debug.Log("Correct Answer!");
            currentRiddleIndex++; // Move to the next riddle
            ShowNextRiddle(); // Update the screen with the next riddle
        }
        else
        {
            Debug.Log("Wrong Answer! Try again.");
        }
    }
}
