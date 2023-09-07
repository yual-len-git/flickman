using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
public class shopEnterHannah : MonoBehaviour
{
    public float price;
    public GameObject shop;
    public GameObject ski_goR;
    public GameObject ski_goL;
    public GameObject snow_go;
    public GameObject donutObject;
    public Animator animator;
    public bool skis;
    public bool snowboards;
    public bool noItem;
    public bool donuts;
    AudioSource audioData;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    void Update() {
        if (shop.activeSelf) {
            if (price > loadScenes.globalBalance && !noItem) {
                print("insufficient funds");
            }
            else if (Keyboard.current.enterKey.wasPressedThisFrame){
                loadScenes.globalBalance -= price;
                audioData.Play();
                if (skis) {
                    animator.SetBool("snowboarder", false);
                    animator.SetBool("onSkis", true);
                    snow_go.SetActive(false);
                    ski_goR.SetActive(true);
                    ski_goL.SetActive(true);
                }
                
                else if (snowboards) {
                    animator.SetBool("onSkis", false);
                    animator.SetBool("snowboarder", true);
                    ski_goR.SetActive(false);
                    ski_goL.SetActive(false);
                    snow_go.SetActive(true);
                }

                else if (donuts)
                {
                    Instantiate(donutObject);
                    donutObject.transform.position = transform.position;
                }

                else if (noItem)
                {
                    
                }

                else {
                    PlayerMovement.hasLiftTicket = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "player") {
            shop.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "player") {
            shop.SetActive(false);
        }
    }
}
