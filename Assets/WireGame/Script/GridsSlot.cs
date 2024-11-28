using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSlot : MonoBehaviour
{
    public Color requiredColor;
    private bool isOccupied = false;
    private bool isCompleted = false; // New flag to check if the slot is already filled
    private Renderer slotRenderer;

    void Start()
    {
        slotRenderer = GetComponent<Renderer>();
        slotRenderer.material.color = requiredColor;
    }

    void OnTriggerEnter(Collider other)
    {
        // If the slot is already filled, do nothing
        if (isCompleted) return;

        ColorBlock colorBlock = other.GetComponent<ColorBlock>();
        if (colorBlock != null && colorBlock.blockColor == requiredColor)
        {
            isOccupied = true;
            isCompleted = true;  // Mark this slot as completed
            colorBlock.SetInPlace(true);
            Debug.Log($"Slot {gameObject.name} filled with {colorBlock.blockColor}. IsOccupied: {isOccupied}");
        }
    }

    void OnTriggerExit(Collider other)
    {
        // If the slot is already filled, do nothing
        if (isCompleted) return;

        ColorBlock colorBlock = other.GetComponent<ColorBlock>();
        if (colorBlock != null)
        {
            isOccupied = false;
            colorBlock.SetInPlace(false);
            Debug.Log($"Slot {gameObject.name} cleared. IsOccupied: {isOccupied}");
        }
    }

    public bool IsOccupied()
    {
        return isOccupied;
    }
}
