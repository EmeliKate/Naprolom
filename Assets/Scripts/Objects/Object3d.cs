using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object3d : GameEvent
{
    private Selectable selectable;
    void Start()
    {
        if (GetComponent<Selectable>())
        {
            selectable = GetComponent<Selectable>();
        }
    }
    public override void TriggerEvent()
    {
        if (selectable)
        {
            if (selectable.IsSelected)
            {
                eventTrigger.Invoke();
            }
        }
    }
}
