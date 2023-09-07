using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spon : MonoBehaviour
{
    public GameObject stickbutton; 
    public GameObject player; 
    public GameObject stick; 
    
    void update(){
        if(Input.GetKey("b")){
            player.GetComponent<playerMoney>().money -= 50; 
            Instantiate(stick, new Vector3(0, 0, 0), Quaternion.identity); 
        }
    }

    // public void purchasestick(){
    //     if(money>50){
    //         money -= 50; 
    //         Instantiate(stick, new Vector3(0, 0, 0), Quaternion.identity); 
    //     }
    // }


    // Start is called before the first frame update
    void Start()
    {
        
    }

}
