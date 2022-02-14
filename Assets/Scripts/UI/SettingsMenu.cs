using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    private Image[] menuImages;
    private Button[] menuButtons;
    private Slider slider;
    void Start()
    {
        menuImages = GetComponentsInChildren<Image>();
        menuButtons = GetComponentsInChildren<Button>();
        slider = GetComponentInChildren<Slider>();
    }
    
    public void SettingMenuOn()
    {
        for (int i = 0; i < menuImages.Length; i++)
        {
            menuImages[i].enabled = true;
        }
        
        for (int j = 0; j < menuButtons.Length; j++)
        {
            menuButtons[j].enabled = true;
        }
        slider.enabled = true;
    }
    
    public void SettingMenuOff()
    {
        for (int i = 0; i < menuImages.Length; i++)
        {
            menuImages[i].enabled = false;
        }
        
        for (int j = 0; j < menuButtons.Length; j++)
        {
            menuButtons[j].enabled = false;
        }
        slider.enabled = false;
    }
}
