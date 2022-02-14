using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorOnObject : MonoBehaviour
{
   
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    
    public void SetCursor()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    public void SetCursorBack()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

    public void OnMouseEnter()
    {

        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        
    }

    public void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
