using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class CanvasSelectable 
{
    [TextArea(3,10)]
    public string textOnObject;
    public Vector3 eulerAnglesForCanvas;
    public Vector3 offsetsForCanvas;
    public float fontSize;
    public Vector3 scale;
}
