using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GridSlot[] gridSlots;  

    void Update()
    {
    
        if (CheckWinCondition())
        {
            Debug.Log("You win!");
        }
    }

    private bool CheckWinCondition()
    {
        foreach (GridSlot slot in gridSlots)
        {
            if (!slot.IsOccupied())
            {
                return false; 
            }
        }
        return true;  
    }



}