using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThoughtsTextManager : MonoBehaviour
{
   public GameObject thoughtsTextPrefab;
   private CanvasGroup thoughtsTextCG;
   private Dialogue[] dialogues;
   private GameObject thoughtsText;

   public Vector3 textLocation;
   public float speedFading;

   [HideInInspector]
   public bool initialTextShown = false;

   public int stringIndex;
   [TextArea(3,10)]
   public string[] thoughtTexts;

   void Start()
   {
      dialogues = GetComponent<DialogueManager>().dialogues;

      //GenerateThoughtText(thoughtTexts[stringIndex]);
   }
   
   public void GenerateThoughtText(string textToAppear)
   {
      Destroy(GameObject.FindGameObjectWithTag("ThoughtText"));
      thoughtsText = Instantiate(thoughtsTextPrefab);
      thoughtsText.transform.localPosition = textLocation;
      thoughtsText.GetComponentInChildren<TextMeshProUGUI>().text = textToAppear;
      thoughtsTextCG = thoughtsText.GetComponentInChildren<CanvasGroup>();
      StartCoroutine(FadeUIObject(thoughtsText, thoughtsTextCG, thoughtsTextCG.alpha, 1));
      initialTextShown = true;
   }

   public void RemoveLastText()
   {
      Destroy(GameObject.FindGameObjectWithTag("ThoughtText"));
      initialTextShown = false;
   }
   public IEnumerator FadeUIObject(GameObject textBubble, CanvasGroup fadingObjCG, float start, float end, float lerpTime = 3.5f)
   {
      float timeStartedFading = Time.time;
      float timeSinceStarted = Time.time - timeStartedFading;
      float percentageCompleted = timeSinceStarted / lerpTime;

      while (true)
      {
         timeSinceStarted = Time.time - timeStartedFading;
         percentageCompleted = timeSinceStarted / lerpTime;
         float currentValue = Mathf.Lerp(start, end, percentageCompleted);
         fadingObjCG.alpha = currentValue;
         if (percentageCompleted >= 1)
         {
            break;
         }
         yield return new WaitForEndOfFrame();
      }
   }
}
