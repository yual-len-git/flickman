using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerandcoin : MonoBehaviour
{

    private void OnTriggerEnter(Collider other){
        if(other.name == "coin"){
            loadScenes.globalBalance += 25;
            Destroy(other.gameObject); 
        } 
    }
}
