using System;
using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject textBubblePrefab;
    public GameObject textBubblePrefabMirrowed;
    
    public GameObject nameButton;
    public TextMeshProUGUI nameOnAButton;
    public CanvasGroup nameButtonCG;
    public Dialogue[] dialogues;
    private int currentDialogueIndex;

    public Vector3 bubbleLocation;
    public float bubbleScale;

    private int currentSentenceIndex;
    private bool isGoing;
    private TextBubbleManager textBubbleManager;
    private GameObject currentBubble;
    private GameObject currentPrefab;
    
    void Start()
    {
        isGoing = false;
        textBubbleManager = GetComponent<TextBubbleManager>();
    }

    public void StartDialogue(int index)
    {
        
        Debug.Log("dialogue started " + index);
        if (isGoing) return;
        
        currentDialogueIndex = index;
        currentSentenceIndex = 0;
        
        if (currentBubble) textBubbleManager.RemoveTextBubble(currentBubble, null, false);
        
        GenerateSuitableTextBubble(index);
        isGoing = true;
    }

    public void GenerateSuitableTextBubble(int dialogueIndex)
    {
        if (dialogues[dialogueIndex].playerStarted)
        {
            currentPrefab = currentSentenceIndex % 2 == 0 ? textBubblePrefabMirrowed : textBubblePrefab;
        }
        else 
        {
            currentPrefab = currentSentenceIndex % 2 == 0 ? textBubblePrefab : textBubblePrefabMirrowed;
        }
        currentBubble = textBubbleManager.GenerateTextBubble(currentPrefab, dialogues[dialogueIndex].sentences[currentSentenceIndex], 
            bubbleLocation, bubbleScale);
    } 
    public void ProcessDialogue(int index)
    {
        Debug.Log("dialogue started: " + index);
        if (!isGoing)
        {
            StartDialogue(index);
            return;
        }

        LoadNextSentences(currentDialogueIndex);
    }
    
    public void LoadNextSentences(int dialogueIndex)
    {
        
        textBubbleManager.RemoveTextBubble(currentBubble, null, false);
        
        if (currentSentenceIndex >= dialogues[dialogueIndex].sentences.Length - 1)
        {
            dialogues[dialogueIndex].dialogueCompleted = true;
            isGoing = false;
            return;
        }
        
        currentSentenceIndex++;
        GenerateSuitableTextBubble(dialogueIndex);
    }

    /*public bool CheckIfCompleted(int dialogueIndex)
    {
        return dialogues[dialogueIndex].dialogueCompleted;
        
        if (dialogues[dialogueIndex].dialogueCompleted)
        {
            return true;
        }
        else
        {
            return false;
        }
    }*/

    public void Update()
    {
    }
} 
