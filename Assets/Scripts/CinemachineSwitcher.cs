using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineSwitcher : MonoBehaviour
{
    private Animator animator;
    public CanvasGroup thirdPersonUI;
    public CanvasGroup firstPersonUI;
    public float UITransitionTime = .5f;

    private bool firstPerson = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void EnterViewfinder()
    {
        animator.Play("PhotographyCamera");
        Debug.Log("enter viewfinder");
        LeanTween.alphaCanvas(thirdPersonUI, 0f, UITransitionTime / 6).setEase(LeanTweenType.easeOutQuad);
        LeanTween.alphaCanvas(firstPersonUI, 1f, UITransitionTime / 6).setEase(LeanTweenType.easeInQuad);
    }
    
    public void ExitViewfinder()
    {
        Debug.Log("exit viewfinder");
        LeanTween.alphaCanvas(thirdPersonUI, 1f, UITransitionTime / 6).setEase(LeanTweenType.easeInQuad);
        LeanTween.alphaCanvas(firstPersonUI, 0f, UITransitionTime / 6).setEase(LeanTweenType.easeOutQuad);
        animator.Play("3rdPersonCamera");
    }
}
