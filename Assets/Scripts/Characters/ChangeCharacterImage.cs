using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacterImage : MonoBehaviour
{

    public float speedFading;
    public GameObject svetlanaSittingCG;
    public GameObject svetlanaStandingCG;
    public GameObject svetlanaWalking0;
    public GameObject svetlanaWalking1;
    

    public void FadeInCharacter(GameObject character)
    {
        CanvasGroup cg = character.GetComponent<CanvasGroup>();
        cg.alpha = Mathf.Lerp(cg.alpha, 1, Time.deltaTime*speedFading);
    }
    
    public void FadeOutCharacter(GameObject character)
    {
        CanvasGroup cg = character.GetComponent<CanvasGroup>();
        cg.alpha = Mathf.Lerp(cg.alpha, 0, Time.deltaTime*speedFading);
    }
}
