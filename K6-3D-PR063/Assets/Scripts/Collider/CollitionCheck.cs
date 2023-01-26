using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CollitionCheck : MonoBehaviour
{
    public GameObject T_cube;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("<color=yellow>entered</color> the trigger");
        ChangeCubeColor(Color.yellow);
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("<color=green>is withing</color> the trigger");
        ChangeCubeColor(GenerateRandomColor());
    }


    
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("<color=orange>exited</color> the trigger");
        ChangeCubeColor(Color.red);
    }

    private void ChangeCubeColor(Color c_color)
    {
        T_cube.transform.GetComponent<MeshRenderer>().material.color = c_color;
    }
    private Color GenerateRandomColor()
    {
        Color background = new Color(
        Random.Range(0f, 1f),
        Random.Range(0f, 1f),
        Random.Range(0f, 1f)
        );
        return background;
    }
}
