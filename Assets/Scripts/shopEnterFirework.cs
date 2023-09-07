using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class shopEnterFirework : MonoBehaviour
{
    public GameObject shop;
    public GameObject shop2;
    public GameObject fireworkObject;
    public Animator animator;
    public bool nextDialogue;

    void Update() {
        if (shop.activeSelf) 
        {
            if (Keyboard.current.enterKey.wasPressedThisFrame){
                if (nextDialogue)
                {
                    Instantiate(fireworkObject);
                    fireworkObject.transform.position = transform.position;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Man.003")
        {
            shop = shop2;
            nextDialogue = true;
        }
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
