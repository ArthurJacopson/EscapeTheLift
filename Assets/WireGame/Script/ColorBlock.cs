using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class ColorBlock : MonoBehaviour
{
    public Color blockColor;  // color of the cube
    private bool isInPlace = false;  

    public void SetInPlace(bool status)
    {
        isInPlace = status;
    }

    public bool IsInPlace()
    {
        return isInPlace;
    }
}