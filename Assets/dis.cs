using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dis : MonoBehaviour
{
    public GameObject selff;
    public float i = 0; 
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if(i>5){
            Destroy(selff); 
        }
        if(Input.GetKeyDown("l")){
            i++; 
        }
    }
}
