using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    private Renderer cellRenderer;
    public Color correctColor = Color.green; // Color when puzzle is solved
    public string objectName; // Expected object name for this cell

    void Start()
    {
        cellRenderer = GetComponentInChildren<Renderer>(); // Access the Cube's Renderer
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player is standing on this cell
        if (other.CompareTag("Player"))
        {
            // Initiate the speech recognition or trigger the event
            SpeechRecognitionManager.OnWordRecognized += CheckAnswer; 
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Unsubscribe when the player leaves the cell
        if (other.CompareTag("Player"))
        {
            SpeechRecognitionManager.OnWordRecognized -= CheckAnswer;
        }
    }

    private void CheckAnswer(string recognizedWord)
    {
        // Check if the recognized word matches the object name for this cell
        if (recognizedWord.Equals(objectName, System.StringComparison.OrdinalIgnoreCase))
        {
            ChangeColor(); // Change color if the answer is correct
        }
    }

    private void ChangeColor()
    {
        cellRenderer.material.color = correctColor;
    }
}