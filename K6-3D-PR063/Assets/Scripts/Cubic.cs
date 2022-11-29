using System.Collections;
using System.Collections.Generic;
using NRKernal;
using UnityEngine;
using UnityEngine.EventSystems;
//Used in HandTrakinPrefab scene on cube
public class Cubic : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private MeshRenderer cubeMeshRender;

    void Awake()
    {
        cubeMeshRender = transform.GetComponent<MeshRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        //get controller rotation, and set the value to the cube transform
        transform.rotation = NRInput.GetRotation();
    }

    //when pointer click, set the cube color to random color
    public void OnPointerClick(PointerEventData eventData)
    {
        cubeMeshRender.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    //when pointer hover, set the cube color to green
    public void OnPointerEnter(PointerEventData eventData)
    {
        cubeMeshRender.material.color = Color.red;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        cubeMeshRender.material.color = Color.white;
    }
}
