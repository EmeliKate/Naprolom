using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Cinemachine;

public class SelectObject : MonoBehaviour
{
    [HideInInspector] public GameObject selectedObject;
    [HideInInspector] public bool anyObjectSelected;
    public GameObject mainCamera;
    private Camera camera;
    public CinemachineVirtualCamera mainCM;
    private ZoomObject zoomObject;
    private TextAppearingOnObjects textAppearingOnObjects;
    public CinemachineVirtualCamera[] objectCMs;
    private bool allCanvasesAdded;
    
    void Start()
    {
        camera = mainCamera.GetComponent<Camera>();
        anyObjectSelected = false;
        
        textAppearingOnObjects = GetComponent<TextAppearingOnObjects>();

        allCanvasesAdded = false;
    }

    private void Update()
    {
        InteractWithObject();
        if (Input.GetMouseButtonDown(0))
        {
            Select();
        }
    }


    public void Select()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        textAppearingOnObjects.RemoveTextFromObjects();
        anyObjectSelected = false;
            
        if (Physics.Raycast(ray, out hit))
        {
            Selectable selectableComponent;

            if (selectedObject)
            {
                
                selectedObject.TryGetComponent(out selectableComponent);
                        
                selectableComponent.IsSelected = false;
                selectedObject = null;
            }
                
            if (hit.collider.gameObject.TryGetComponent(out selectableComponent))
            {
                selectedObject = hit.collider.gameObject;
                selectableComponent.IsSelected = true;
            }
                    
            anyObjectSelected = selectedObject != null;
        }
        else
        {
            selectedObject = null;
            anyObjectSelected = false;
        }
    }

    public void InteractWithObject()
    {
        
        if (anyObjectSelected)
        {
            mainCM.enabled = false;
            selectedObject.GetComponent<Selectable>().cm.enabled = true;

            GetComponent<TextAppearingOnObjects>().AddAllTexts(selectedObject);
        }
        else
        {
            DeselectAllObjects();
        }
    }

    public void DeselectAllObjects()
    {
        allCanvasesAdded = false;
        for (int i = 0; i < objectCMs.Length; i++)
        {
            objectCMs[i].enabled = false;
        }
        mainCM.enabled = true;
        Debug.Log("deselect");
        GetComponent<TextAppearingOnObjects>().RemoveTextFromObjects();
    }
}