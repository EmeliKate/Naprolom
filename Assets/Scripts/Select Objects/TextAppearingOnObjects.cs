using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextAppearingOnObjects : MonoBehaviour
{
    public float lerpTime = 0.5f;
    public float lerpTimeB = 0.5f;
    public GameObject canvasPrefab;
    public bool addBackground;
    public float backgroundTransparency;
    public CanvasGroup cgBackgound;
    public float speedFading;
    public float speedFadingObjects = 2.5f;
    
    private CanvasGroup cgText;
    private GameObject textObject;

    private GameObject[] canvases;

    private Vector3 playerToObjDirection;
    
    [HideInInspector]
    public bool canvasesAdded = false;
    
   
    public void AddTextOnObject(GameObject objectToPlaceTextOn, string textToAdd, float textSizeCoefficient, float yAxisPivot, 
        Vector3 canvasRotation, Vector3 canvasLocalPosition, Vector3 canvasScale)
    {
        GameObject canvas = Instantiate(canvasPrefab);
        canvas.transform.parent = objectToPlaceTextOn.transform;
        canvas.transform.localEulerAngles = canvasRotation;
        textObject = canvas.transform.GetChild(0).gameObject;
        cgText = canvas.GetComponent<CanvasGroup>();

        textObject.GetComponent<RectTransform>().pivot = new Vector2(0.5f, yAxisPivot);
        canvas.GetComponent<RectTransform>().localPosition = canvasLocalPosition;
        canvas.GetComponent<RectTransform>().localEulerAngles = canvasRotation;
        canvas.GetComponent<RectTransform>().localScale = canvasScale;

        textObject.GetComponent<TextMeshProUGUI>().fontSize = textSizeCoefficient;

        textObject.GetComponent<TextMeshProUGUI>().text = textToAdd;
    }

    public void AddAllTexts(GameObject objectToPlaceTextOn)
    {
        RemoveTextFromObjects();
        int canvasQuantity = objectToPlaceTextOn.GetComponent<Selectable>().canvases.Length;
        for (int i = 0; i < canvasQuantity; i++)
        {
            string textToAppear = objectToPlaceTextOn.GetComponent<Selectable>().canvases[i].textOnObject;
            float textSizeCoefficient = objectToPlaceTextOn.GetComponent<Selectable>().canvases[i].fontSize;
            Vector3 canvasRotation = objectToPlaceTextOn.GetComponent<Selectable>().canvases[i].eulerAnglesForCanvas;
            Vector3 canvasLocalPosition = objectToPlaceTextOn.GetComponent<Selectable>().canvases[i].offsetsForCanvas;
            Vector3 canvasScale = objectToPlaceTextOn.GetComponent<Selectable>().canvases[i].scale;
            AddTextOnObject(objectToPlaceTextOn, textToAppear, textSizeCoefficient,
                0.5f, canvasRotation, canvasLocalPosition, canvasScale);

            if (i == canvasQuantity - 1)
            {
                canvasesAdded = true;
            }
        }
    }
    public void RemoveTextFromObjects()
    {
        canvases = GameObject.FindGameObjectsWithTag("TextCanvasPrefab");

        
        for (int i = 0; i < canvases.Length; i++)
        {
            float start = canvases[i].GetComponent<CanvasGroup>().alpha ;
            float end = 0;
            canvases[i].GetComponent<CanvasGroup>().alpha = Mathf.Lerp(start, end, Time.deltaTime*speedFading);
            Destroy(canvases[i]);
        }
        canvasesAdded = false;
            
        if (addBackground)
        {
                cgBackgound.alpha = Mathf.Lerp(cgBackgound.alpha, 0, Time.deltaTime*speedFading);
        }
    }
    
    IEnumerator FadeIn(CanvasGroup cg, float start, float end, float lerpTime = 1.5f)
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
