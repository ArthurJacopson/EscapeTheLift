using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int gridIndex; // Assign a unique index for each grid in the Inspector
    public RiddleGameManager gameManager; // Reference to the GameManager script

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.name); // Log which object is triggering
        // Check if the player (via the XR Rig) steps on the grid cell
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player stepped on grid " + gridIndex); // Debug to confirm the trigger works
            gameManager.CheckPlayerAnswer(gridIndex); // Check the answer
        }
    }
}
