using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;

public class Timeline : MonoBehaviour
{
    // add scr obj/prefab for dialogues
    public GameObject DialogueManager => dialogueManager;
    [SerializeField]
    private GameObject dialogueManager;
    public GameObject characterImages;
    public GameObject objectSelector;
    private SelectObject selectObject;
    public GameObject mainCameraObject;
    private CinemachineBrain cinemachineBrain;
    public CinemachineVirtualCamera CMMain;
    public CinemachineVirtualCamera wallTextSceneCM;
    public GameObject player;
    private CameraMover cameraMoverScr;
    public CinemachineVirtualCamera[] camerasFollowingSvetlana;
    private Dialogue[] dialogues;
    public GameObject[] SvetlanaStages;
    public GameObject boss;
    private Image bossImage;
    private Button bossButton;
    public GameObject blackScreen;
    private CanvasGroup blackScreenCG;
    private Image blackScreenImage;
    private Button blackScreenButton;
    public CinemachineVirtualCamera bossCM;
    [HideInInspector] 
    public bool textShown = false;
    public GameObject[] audios;
    public GameObject[] digits;
    public GameObject endGame;
    private CanvasGroup endGameCG;
    private Image endGameImage;
    public GameObject exit;
    private Image exitImage;
    private Button exitButton;
    
    //needs to be removed later
    private bool bossSceneOn = false;
    void Start()
    {
        // chnge getcomponent to monobeh
        objectSelector.GetComponent<SelectObject>().enabled = false;
        dialogues = dialogueManager.GetComponent<DialogueManager>().dialogues;

        selectObject = objectSelector.GetComponent<SelectObject>();
        
        cameraMoverScr = player.GetComponent<CameraMover>();
        cameraMoverScr.enabled = false;

        cinemachineBrain = mainCameraObject.GetComponent<CinemachineBrain>();

        blackScreenImage = blackScreen.GetComponent<Image>();
        blackScreenCG = blackScreen.GetComponent<CanvasGroup>();
        blackScreenButton = blackScreen.GetComponent<Button>();
        
        bossImage = boss.GetComponent<Image>();
        bossButton = boss.GetComponent<Button>();

        endGameCG = endGame.GetComponent<CanvasGroup>();
        endGameImage = endGame.GetComponent<Image>();
        
        exitImage = exit.GetComponent<Image>();
        exitButton = exit.GetComponent<Button>();
    }
    
    public void SwitchCamera(int cameraIndex)
    {
        for (int i = 0; i < camerasFollowingSvetlana.Length; i++)
        {
            camerasFollowingSvetlana[i].enabled = false;
        }
        CMMain.enabled = false;
        camerasFollowingSvetlana[cameraIndex].enabled = true;
    }
    public void LoadNextImageOnDialogueCompleted(int dialogueIndex)
    {
        if (dialogues[dialogueIndex].dialogueCompleted)
        {
            SvetlanaStages[dialogueIndex].SetActive(false);
            SvetlanaStages[dialogueIndex + 1].GetComponent<Image>().enabled = true;
            SvetlanaStages[dialogueIndex + 1].GetComponent<Button>().enabled = true;
        }
    }
    public void LoadNextImageOnClick(int currentImageIndex)
    {
        SvetlanaStages[currentImageIndex].SetActive(false);
        SvetlanaStages[currentImageIndex + 1].GetComponent<Image>().enabled = true;
        SvetlanaStages[currentImageIndex + 1].GetComponent<Button>().enabled = true;
    }

    public void SvetlanaWalkingAwayOnDialogueCompleted(int currentImageIndex)
    {
        if (dialogues[currentImageIndex-1].dialogueCompleted)
        {
            SvetlanaStages[currentImageIndex].SetActive(false);
            SvetlanaStages[currentImageIndex+1].GetComponent<Image>().enabled = true;
            SvetlanaStages[currentImageIndex+1].GetComponent<Button>().enabled = true;
            CanvasGroup cg = SvetlanaStages[currentImageIndex+1].GetComponent<CanvasGroup>();
            StartCoroutine(CharacterFade(cg, cg.alpha, 1));
            audios[0].GetComponent<AudioSource>().enabled = true;
        }
    }

    public void SvetlanaWalking(int currentImageIndex)
    {
        SvetlanaStages[currentImageIndex].SetActive(false);
        SvetlanaStages[currentImageIndex+1].GetComponent<Image>().enabled = true;
        SvetlanaStages[currentImageIndex+1].GetComponent<Button>().enabled = true;
        CanvasGroup cg = SvetlanaStages[currentImageIndex+1].GetComponent<CanvasGroup>();
        StartCoroutine(CharacterFade(cg, cg.alpha, 1));
    }
    
    public void RotateCamera(int cameraPosIndex)
    {
        SwitchCamera(cameraPosIndex);
    }

    public void RotateCameraToText(int cameraPosIndex)
    {
        SwitchCamera(cameraPosIndex);
        SvetlanaStages[cameraPosIndex + 2].SetActive(false);
        audios[0].GetComponent<AudioSource>().enabled = false;
        
        CMMain.enabled = false;
        wallTextSceneCM.enabled = true;
        textShown = true;
        StartCoroutine(Wait(3f));
    }
    
    public void SvetlanaWalkingAway(int dialogueIndex)
    {
        if (dialogues[dialogueIndex].dialogueCompleted)
        {
            SvetlanaStages[5].SetActive(false);
            blackScreenImage.enabled = true;
            blackScreenButton.enabled = true;
            StartCoroutine(BlackScreenFade(blackScreenCG.alpha, 1));
            audios[0].GetComponent<AudioSource>().enabled = true;
        }
    }

    public void LoadBossScene()
    {
        audios[0].GetComponent<AudioSource>().enabled = false;
        CMMain.enabled = false;
        bossCM.enabled = false;
        cinemachineBrain.enabled = false;
        mainCameraObject.transform.position = bossCM.transform.position;
        mainCameraObject.transform.eulerAngles = bossCM.transform.eulerAngles;
        selectObject.enabled = false;
        bossImage.enabled = true;
        bossButton.enabled = true;
        digits[0].SetActive(false);
        digits[1].SetActive(false);
        digits[2].GetComponent<RawImage>().enabled = true;
        digits[3].GetComponent<RawImage>().enabled = true;
        //needs to be removed later
        bossSceneOn = true;
    }
    
    //needs to be removed later
    private void Update()
    {
        if (!Input.GetMouseButtonDown(0))
            return;
        if (!bossSceneOn) 
            return;
        
        cameraMoverScr.enabled = false;
        dialogueManager.GetComponent<DialogueManager>().ProcessDialogue(3);
        
        if (!dialogues[3].dialogueCompleted) 
            return;
        
        bossSceneOn = false;
        endGameCG.enabled = true;
        endGameImage.enabled = true;
        StartCoroutine(CharacterFade(endGameCG, endGameCG.alpha, 1));
        exitImage.enabled = true;
        exitButton.enabled = true;
    }


    IEnumerator BlackScreenFade(float start, float end, float lerpTime = 1.5f)
    {
        float timeStartedFading = Time.time;
        float timeSinceStarted = Time.time - timeStartedFading;
        float percentageCompleted = timeSinceStarted / lerpTime;
        
        while (percentageCompleted <= 1)
        {
            timeSinceStarted = Time.time - timeStartedFading;
            percentageCompleted = timeSinceStarted / lerpTime;
            float currentValue = Mathf.Lerp(start, end, percentageCompleted);
            blackScreenCG.alpha = currentValue;
            if (percentageCompleted >= 1)
            {
                if (blackScreenCG.alpha <= 0.01f)
                {
                    blackScreen.SetActive(false);
                }
            }
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator Wait(float waitTime = 1.5f)
    {
        yield return new WaitForSeconds(waitTime);
        CMMain.enabled = true;
        wallTextSceneCM.enabled = false;
        selectObject.enabled = true;
        cameraMoverScr.enabled = true;
    }
    
    
    IEnumerator CharacterFade(CanvasGroup cg, float start, float end, float lerpTime = 2.5f)
    {
        float timeStartedFading = Time.time;
        float timeSinceStarted = Time.time - timeStartedFading;
        float percentageCompleted = timeSinceStarted / lerpTime;
        
        while (percentageCompleted <= 1)
        {
            timeSinceStarted = Time.time - timeStartedFading;
            percentageCompleted = timeSinceStarted / lerpTime;
            float currentValue = Mathf.Lerp(start, end, percentageCompleted);
            cg.alpha = currentValue;
            yield return new WaitForEndOfFrame();
        }
    }
}
