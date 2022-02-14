using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IQuestStage
{
    public string Name();

    public void Initialize();

    public bool CheckDone();

    public void Destroy();
}