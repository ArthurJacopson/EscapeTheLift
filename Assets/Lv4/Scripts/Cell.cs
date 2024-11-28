using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    public int gridIndex; // Unique grid index (1-9)
    public RiddleGameManager gameManager; // Reference to the RiddleGameManager script

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.name); // Log which object is triggering

        if (other.CompareTag("Player"))
        {
            gameManager.CheckPlayerAnswer(gridIndex);
        }
    }
}
