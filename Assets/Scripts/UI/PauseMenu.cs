using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private bool PauseGame = false;
    public GameObject pauseGameMenu;
    private Image[] pauseImages;
    private Button[] pauseButtons;
    public Button notepadButton;
    public Image notepadImage;
    public TextMeshProUGUI notepadText;
    public TextMeshProUGUI answers;
    public GameObject timelineObject;
    private Timeline timeline;
    
    void Start()
    {
        pauseImages = pauseGameMenu.GetComponentsInChildren<Image>();
        pauseButtons = pauseGameMenu.GetComponentsInChildren<Button>();
        timeline = timelineObject.GetComponent<Timeline>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        if (PauseGame)
        {
            if (!timeline.textShown)
            {
                notepadButton.enabled = false;
                notepadImage.enabled = false;
                notepadText.enabled = false;
                answers.enabled = false;
            }
            for (int i = 0; i < pauseImages.Length; i++)
            {
                pauseImages[i].enabled = false;
            }
        
            for (int j = 0; j < pauseButtons.Length; j++)
            {
                pauseButtons[j].enabled = true;
            }
            Time.timeScale = 1f;
            PauseGame = false;
        }
    }

    public void Pause()
    {
        if (!PauseGame)
        {
            if (timeline.textShown)
            {
                notepadButton.enabled = true;
                notepadImage.enabled = true;
                notepadText.enabled = true;
                answers.enabled = true;
            }
            GameObject bubble = GameObject.FindGameObjectWithTag("TextBubble");
            if (bubble)
            {
                bubble.GetComponentInChildren<Image>().enabled = false;
                bubble.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
            }
        
            for (int i = 0; i < pauseImages.Length; i++)
            {
                pauseImages[i].enabled = true;
            }
        
            for (int j = 0; j < pauseButtons.Length; j++)
            {
                pauseButtons[j].enabled = true;
            }
            Time.timeScale = 0f;
            PauseGame = true; 
        }
    }

    public void PauseButtonOnClick()
    {
        if (PauseGame)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
}
