using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class purchase : MonoBehaviour
{
    GameObject mygameObject;
    void start(){
        mygameObject = GameObject.Find("player"); 
        mygameObject.GetComponent<playerMoney>().money -= 4;
    }
    
}
