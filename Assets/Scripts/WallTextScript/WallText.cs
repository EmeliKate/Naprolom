using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using TMPro;
using System.Text;
using System.Globalization;


public class WallText : MonoBehaviour
{
    public string[] textsRequired;
    public TMP_InputField[] textInputFields;

    public GameObject[] inputFields;

    public GameObject[] textsToAppear;
    public float speedFading;

    public GameObject key;
    private Button keyButton;
    private Image keyImage;
    
    public GameObject svetlana;
    private Button svetlanaButton;
    private Image svetlanaImage;
    void Start()
    {
        SetCaretVisible(10);

        keyButton = key.GetComponent<Button>();
        keyImage = key.GetComponent<Image>();
        
        svetlanaButton = svetlana.GetComponent<Button>();
        svetlanaImage = svetlana.GetComponent<Image>();
    }
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadFurtherText(new []{textsToAppear[0], textsToAppear[1], textsToAppear[2]}, 0, 0);
            LoadFurtherText(new []{textsToAppear[3], textsToAppear[4], textsToAppear[5]}, 1, 1);
            LoadFurtherText(new []{textsToAppear[6], textsToAppear[7]}, 2, 2);
            LoadFurtherText(new []{textsToAppear[8], textsToAppear[9]}, 3, 3);
            LoadFurtherText(new []{textsToAppear[10]}, 4, 4);
        }
    }
    
    void SetCaretVisible(int pos)
    {
        TMP_InputField inputField = GetComponent<TMP_InputField>();
        inputField.caretPosition = pos; 

        inputField.GetType().GetField("m_AllowInput", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(inputField, true);
        inputField.GetType().InvokeMember("SetCaretVisible", BindingFlags.NonPublic | BindingFlags.InvokeMethod | BindingFlags.Instance, 
            null, inputField, null);
    }

    bool CheckIfCorrect(int textRequiredIndex, int textInputFieldIndex)
    {
        var comparer = StringComparer.Create(CultureInfo.GetCultureInfo("ru-RU"), true);
        if  (String.Compare(textInputFields[textInputFieldIndex].text, textsRequired[textRequiredIndex]) == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    

    void LoadFurtherText(GameObject[] textsToAppearAtThisStage, int textRequiredIndex, int textInputFieldIndex)
    {
        
        if (CheckIfCorrect(textRequiredIndex, textInputFieldIndex))
        {
            for (int i = 0; i < textsToAppearAtThisStage.Length; i++)
            {
               
                CanvasGroup textCG = textsToAppearAtThisStage[i].GetComponent<CanvasGroup>();
                float start = textCG.alpha ;
                float end = 1;
                textsToAppearAtThisStage[i].GetComponent<CanvasGroup>().alpha = Mathf.Lerp(start, end, Time.deltaTime*speedFading);
                if (textInputFieldIndex >= textInputFields.Length-1)
                {
                    ShowKey();
                }
            }
        }
        else
        {
            TMP_InputField input = inputFields[textInputFieldIndex].GetComponent<TMP_InputField>();
            input.text = "";
        }
    }

    void ShowKey()
    {
        keyButton.enabled = true;
        keyImage.enabled = true;
    }
}
