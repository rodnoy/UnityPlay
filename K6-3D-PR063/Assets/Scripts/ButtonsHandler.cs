using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Used in HandTrakinPrefab scene on buttons
public class ButtonsHandler : MonoBehaviour
{
    int n;
    public void OnIconButtonPress()
    {
        n++;
        Debug.Log("Button clicked " + n + " times.");
    }
}
