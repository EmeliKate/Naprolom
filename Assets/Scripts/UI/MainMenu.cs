using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject notepad;
    private Image notepadImage;
    private Button notepadButton;
    
    private Image[] menuImages;
    private Button[] menuButtons;
    
    void Start()
    {
        menuImages = menu.GetComponentsInChildren<Image>();
        menuButtons = menu.GetComponentsInChildren<Button>();

        notepadImage = notepad.GetComponent<Image>();
        notepadButton = notepad.GetComponent<Button>();
    }
    public void PlayGame()
    {
        if (notepadImage)
        {
            notepadImage.enabled = true;
        }
        if (notepadButton)
        {
            notepadButton.enabled = true;
        }
        for (int i = 0; i < menuImages.Length; i++)
        {
            menuImages[i].enabled = false;
        }
        
        for (int j = 0; j < menuButtons.Length; j++)
        {
            menuButtons[j].enabled = false;
        }
    }

    public void ExitGame()
    {
        Debug.Log("Game end");
        Application.Quit();
    }

    public void LoadMenu()
    {
       
        if (notepadImage)
        {
            notepadImage.enabled = false;
        }
        if (notepadButton)
        {
            notepadButton.enabled = false;
        }
        for (int i = 0; i < menuImages.Length; i++)
        {
            menuImages[i].enabled = true;
        }
        
        for (int j = 0; j < menuButtons.Length; j++)
        {
            menuButtons[j].enabled = true;
        }
    }
}
