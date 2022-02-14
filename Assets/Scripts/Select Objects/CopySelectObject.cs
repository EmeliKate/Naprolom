using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Cinemachine;

public class CopySelectObject : MonoBehaviour
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
        Select();
        InteractWithObject();
    }


    public void Select()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            textAppearingOnObjects.RemoveTextFromObjects();
            anyObjectSelected = false;
            
            if (Physics.Raycast(ray, out hit))
            {
                Selectable selectableComponent;

                if (selectedObject)
                {
                    Debug.Log("selectedObject");
                    selectedObject.TryGetComponent(out selectableComponent);
                        
                    selectableComponent.IsSelected = false;
                    selectedObject = null;
                }
                
                if (hit.collider.gameObject.TryGetComponent(out selectableComponent))
                {
                    Debug.Log("hit.collider");
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
    }

    public void InteractWithObject()
    {
        
        if (anyObjectSelected)
        {
            mainCM.enabled = false;
            selectedObject.GetComponent<Selectable>().cm.enabled = true;

            if (!allCanvasesAdded)
            {
                int canvasesQuantity = selectedObject.GetComponent<Selectable>().canvases.Length;
                for (int i = 0; i < canvasesQuantity; i++)
                {
                    string textToAppear = selectedObject.GetComponent<Selectable>().canvases[i].textOnObject;
                    float textSizeCoefficient = selectedObject.GetComponent<Selectable>().canvases[i].fontSize;
                    Vector3 canvasRotation = selectedObject.GetComponent<Selectable>().canvases[i].eulerAnglesForCanvas;
                    Vector3 canvasLocalPosition = selectedObject.GetComponent<Selectable>().canvases[i].offsetsForCanvas;
                    Vector3 canvasScale = selectedObject.GetComponent<Selectable>().canvases[i].scale;
                    GetComponent<TextAppearingOnObjects>().AddTextOnObject(selectedObject, textToAppear, textSizeCoefficient,
                        0.5f, canvasRotation, canvasLocalPosition, canvasScale);

                    if (i == canvasesQuantity - 1)
                    {
                        allCanvasesAdded = true;
                    }
                }
            }
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
        
    }
}
