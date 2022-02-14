using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlatObject : GameEvent
{
    private Button button;
    void Start()
    {
        if (GetComponentInChildren<Button>())
        {
            button = GetComponentInChildren<Button>();
            button.onClick.AddListener(TaskOnClick);
        }
    }
    public override void TriggerEvent()
    {
        if (button)
        {
            button.onClick.AddListener(TaskOnClick);
        }
    }
    void TaskOnClick()
    {
        eventTrigger.Invoke();
    }
}