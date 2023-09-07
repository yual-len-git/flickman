using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dis : MonoBehaviour
{
    public GameObject selff;
    public GameObject other;
    public float i = 0; 
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if(i>3){
            selff.SetActive(false); 
            other.SetActive(true); 

        }
        if(Input.GetKeyDown("l")){
            i++; 
        }
    }
}
