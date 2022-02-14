using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;
    public bool dialogueStarted = false;
    public bool dialogueCompleted = false;
    public bool playerStarted;

    [TextArea(3,10)]
    public string[] sentences;
}
