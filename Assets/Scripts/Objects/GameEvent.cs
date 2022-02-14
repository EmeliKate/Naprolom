using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public abstract class GameEvent : MonoBehaviour
{

    public UnityEvent eventTrigger;
    
    public abstract void TriggerEvent();
}




