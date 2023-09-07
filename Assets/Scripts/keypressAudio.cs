using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keypressAudio : MonoBehaviour
{
    public AudioSource playSound;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Space"))
        {
            playSound.Play();
        }
    }
}
