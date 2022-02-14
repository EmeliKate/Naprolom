using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterStages : MonoBehaviour
{
    public virtual void DisableState()
    {
        //
    }

    public void EnableState()
    {
        //
    }
}

public class SvetlanaStage : CharacterStages
{
    
    
    public override void DisableState()
    {
        base.DisableState();
    }
}
