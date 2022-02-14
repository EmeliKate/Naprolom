using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputObject : GameEvent
{
    public GameObject wallQuest;
   
    public override void TriggerEvent()
    {
        wallQuest.GetComponent<WallText>().Update();
    }
}
