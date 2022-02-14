using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CursorOnWall : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public GameObject hint;
    public Image hintImage;
    public TextMeshProUGUI hintText;
    public Button hintButton;
    public GameObject timelineObject;
    private Timeline timeline;
    private bool hintShown = false;
    
    void Start()
    {
        timeline = timelineObject.GetComponent<Timeline>();
    }
    
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
        if (timeline.textShown)
        {
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            if (!hintShown)
            {
                hintImage.enabled = true;
                hintText.enabled = true;
                hintButton.enabled = true;
                hintShown = true;
            }
        }
    }

    public void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
