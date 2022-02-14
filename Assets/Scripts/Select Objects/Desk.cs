using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Desk : MonoBehaviour
{
    public GameObject desk;
    public Vector3 posOnOpen;
    private Vector3 posClosed;
    private Selectable selectable;
    private bool opened = false;

    void Start()
    {
        posClosed = desk.transform.localPosition;
        selectable = GetComponent<Selectable>();
    }
    void Open()
    {
        desk.transform.localPosition = posOnOpen;
        opened = true;
    }
    
    void Close()
    {
        desk.transform.localPosition = posClosed;
        opened = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (selectable.IsSelected)
            {
                if (!opened)
                {
                    selectable.canvases[0].fontSize = 0;
                    Open();
                }
                else
                {
                    Close();
                }
                
            }
        }
    }
}
