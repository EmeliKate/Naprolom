using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour  {
        
    public IQuestStage currentStage;
        
    private IQuestStage[] Stages = {
        //new TestStage(),
      
    };

    private void Start() {
        SetStage(Stages[0]);
    }

    private void Update() {
        if (currentStage == null) return;
            
        if (currentStage.CheckDone()) {
            SetNextStage();
        }
    }

    private void SetNextStage() {
        var currentIndex = System.Array.IndexOf(Stages, currentStage);
            
        if (currentIndex < Stages.Length - 1) {
            SetStage(Stages[currentIndex + 1]);
        } else {
            Debug.Log("Quest is over!");
        }
    }
        
    public void SetStage(IQuestStage newStage) {
        currentStage?.Destroy();
        currentStage = newStage;
        currentStage.Initialize();
    }
}