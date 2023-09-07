using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleCanvas : MonoBehaviour
{
    public CanvasGroup canvasGroupO;
    public CanvasGroup canvasGroupP;
    private bool oisActive = true;
    private bool pisActive = false;

    private void Update()
    {

        if (Keyboard.current.oKey.wasPressedThisFrame && !oisActive && !pisActive){
            canvasGroupO.alpha = 1;
            oisActive = true;
        }
        else if (Keyboard.current.oKey.wasPressedThisFrame && oisActive){
            canvasGroupO.alpha = 0;
            oisActive = false;
        }
        else if (Keyboard.current.pKey.wasPressedThisFrame && !pisActive && !oisActive){
            canvasGroupP.alpha = 1;
            pisActive = true;
        }
        else if (Keyboard.current.pKey.wasPressedThisFrame && pisActive){
            canvasGroupP.alpha = 0;
            pisActive = false;
        }
    }
}
