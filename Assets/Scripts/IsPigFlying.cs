using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPigFlying : MonoBehaviour
{
    public GameObject pig;
    public GameObject box; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if(pig.transform.position.y> 3){
            box.SetActive(true); 
            box.transform.position = pig.transform.position; 
        } 
        else {
            if(box.activeSelf == true){
                box.SetActive(false); 
            }
        }
        
    }
}
