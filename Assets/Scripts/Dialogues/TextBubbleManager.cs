using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextBubbleManager : MonoBehaviour
{
    private GameObject textBubble;
    private CanvasGroup uiElement;
    private Coroutine currentTextBubbleCoroutine;

    void Start()
    {
        //GenerateTextBubble("text text text 123456789", new Vector3 (0,0,0), 0.1f);
    }
    public GameObject GenerateTextBubble(GameObject textBubblePrefab, string textToGenerate,  Vector3 location, float canvasScaler)
    {
        textBubble = Instantiate(textBubblePrefab);
        uiElement = textBubble.GetComponent<CanvasGroup>();
        textBubble.transform.position = location;
        textBubble.GetComponent<CanvasScaler>().scaleFactor = canvasScaler;
        textBubble.GetComponentInChildren<TextMeshProUGUI>().text = textToGenerate;
        
        currentTextBubbleCoroutine = StartCoroutine(FadeUIObject(textBubble, uiElement, uiElement.alpha, 1));
        
        return textBubble;
    }

    public void RemoveTextBubble(GameObject textBubble, CanvasGroup uiElement, bool animated = true)
    {
        if (animated)
        {
            currentTextBubbleCoroutine = StartCoroutine(FadeUIObject(textBubble, uiElement, uiElement.alpha, 0));
            Destroy(textBubble, 500);
            return;
        }
       
        if (currentTextBubbleCoroutine != null) StopCoroutine(currentTextBubbleCoroutine); 
        Destroy(textBubble);
    }
    
    public IEnumerator FadeUIObject(GameObject textBubble, CanvasGroup fadingObjCG, float start, float end, float lerpTime = 0.5f)
    {
        float timeStartedFading = Time.time;
        float timeSinceStarted = Time.time - timeStartedFading;
        float percentageCompleted = timeSinceStarted / lerpTime;

        while (percentageCompleted < 1)
        {
            timeSinceStarted = Time.time - timeStartedFading;
            percentageCompleted = timeSinceStarted / lerpTime;
            float currentValue = Mathf.Lerp(start, end, percentageCompleted);
            fadingObjCG.alpha = currentValue;
            if (percentageCompleted >= 1)
            {
                if (fadingObjCG.alpha <= 0.01f)
                {
                    Destroy(textBubble);
                }
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
