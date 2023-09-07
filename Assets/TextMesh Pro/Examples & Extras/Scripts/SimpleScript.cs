using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TMPro.Examples
{
    
    public class SimpleScript : MonoBehaviour
    {
        public GameObject go; 
        public float i = 0; 
        public float l = 0; 


        void Start()
        {
            TextMeshPro m_textMeshPro = GetComponent<TextMeshPro>(); 
            m_textMeshPro.SetText("Welcome to FlikMan -tutorial-");
        }


        void Update()
        {
            TextMeshProUGUI m_textMeshPro = go.GetComponent<TextMeshProUGUI>(); 
            if(Input.GetKeyDown("l")){
                if(i==0){
                    m_textMeshPro.text = "Welcome to FlikMan!\n-tutorial-"; 
                    i++;
                } else if (i==1){
                    m_textMeshPro.text ="Use WASD Keys to move";
                    i++;
                } else if(i==2){
                    m_textMeshPro.text = "Move your mouse to change the camera angle";
                    i++;
                } else if(i==3){
                    m_textMeshPro.text = "click 'o' to open and close game objectives screen"; 
                    i++;
                } 
                else if(i==4){
                    m_textMeshPro.text = "left click to pull up your camera and right click at the same time to take the photo"; 
                    i++; 
                } else if(i==5){
                    m_textMeshPro.text = "press 'P' to view your last photo";
                    i++; 
                } 
                else {
                    Destroy(go); 
                }
            }
        }

    }
}
