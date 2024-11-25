using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class GridSlot : MonoBehaviour
{
    public Color requiredColor; 
    private bool isOccupied = false;  
    private Renderer slotRenderer;

    void Start()
    {
        slotRenderer = GetComponent<Renderer>();
        slotRenderer.material.color = requiredColor;  
    }

    void OnTriggerEnter(Collider other)
    {
        
        ColorBlock colorBlock = other.GetComponent<ColorBlock>();
        if (colorBlock != null && colorBlock.blockColor == requiredColor)
        {
            isOccupied = true;  
            colorBlock.SetInPlace(true); 
        }
    }

    void OnTriggerExit(Collider other)
    {
       
        ColorBlock colorBlock = other.GetComponent<ColorBlock>();
        if (colorBlock != null)
        {
            isOccupied = false;
            colorBlock.SetInPlace(false);
        }
    }

    public bool IsOccupied()
    {
        return isOccupied;
    }
}
