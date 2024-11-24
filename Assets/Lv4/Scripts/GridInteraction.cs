using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int gridIndex; // Assign a unique index for each grid in the Inspector
    public RiddleGameManager gameManager; // Reference to the GameManager script

    void OnTriggerEnter(Collider other)
    {
        // Check if the player steps on the grid cell
        if (other.CompareTag("Player"))
        {
            gameManager.CheckPlayerAnswer(gridIndex);
        }
    }
}

