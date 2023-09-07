using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class shopStick : MonoBehaviour
{
    public float price;
    public GameObject shopUI;
    public GameObject stick; 
    AudioSource audioData;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    void Update() {
        if (shopUI.activeSelf) {
            if (price > loadScenes.globalBalance) {
                print("insufficient funds");
            }
            else if (Keyboard.current.enterKey.wasPressedThisFrame){
                loadScenes.globalBalance -= price;
                audioData.Play();
                if(stick.activeSelf==false){
                    stick.SetActive(true);
                } else{
                    Instantiate(stick);
                }
            }
                
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "player") {
            shopUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "player") {
            shopUI.SetActive(false);
        }
    }
}
