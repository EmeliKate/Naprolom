using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    private Selectable selected;
    private Camera camera;
    
    [HideInInspector]
    public bool IsSelected;

    public CanvasSelectable[] canvases;

    public CinemachineVirtualCamera cm;

    void Start()
    {
        camera = Camera.current;
        IsSelected = false;
    }
}