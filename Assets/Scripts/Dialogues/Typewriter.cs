using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Typewriter : MonoBehaviour
{
    private TextMeshProUGUI text;
    private string story;
    
    public void Start() 
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        
        story = text.text;

        StartCoroutine(PlayText(story));
    }

    IEnumerator PlayText(string story)
    {
        text.text = "";
        foreach (char c in story) 
        {
            text.text += c;
            yield return new WaitForSeconds (0.0125f);
        }
    }

}
