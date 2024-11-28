using UnityEngine;

public class GridTrigger : MonoBehaviour
{
    public int gridIndex;  // Grid index for identifying the grid cell
    public RiddleGameManager gameManager; // Reference to the GameManager script

    // Flag for whether this grid has been triggered
    private bool isTriggered = false;

    // This function will be called when something enters the trigger collider
    void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the grid cell's trigger
        if (other.CompareTag("Player") && !isTriggered)
        {
            // Flag this grid as triggered
            isTriggered = true;

            // Log for debugging
            Debug.Log("Player triggered grid " + gridIndex);

            // Call the GameManager method to check the player's answer
            gameManager.CheckPlayerAnswer(gridIndex);
            ResetFlag();
        }
    }

    // Optionally, you can reset the flag if needed after a delay or some condition
    public void ResetFlag()
    {
        isTriggered = false;
    }
}
