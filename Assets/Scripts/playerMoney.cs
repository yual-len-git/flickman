using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class playerMoney : MonoBehaviour
{
    public float money = 100; 
    public TMP_Text score; 
    public GameObject stickbutton; 
    public GameObject stick; 
    public static int i = 3; 
   
    // Start is called before the first frame update
    void Start()
    {
        //score.text = "$"+money.ToString(); 
        //stickbutton.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other){
        if(other.name == "coin"){
            Destroy(other.gameObject); 
            money+=50; 
            score.text = "$"+money.ToString(); 
        } else if(other.name == "SM_Bld_Apartment_03"){
            stickbutton.SetActive(true);
            if(money>=50){
                money = (float) money - 50; 
                score.text = "$"+money.ToString(); 
                Instantiate(stick, new Vector3(23+ i, 1, -29+i), Quaternion.identity); 
                i+=3;
            }
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.name == "SM_Bld_Apartment_03"){
            stickbutton.SetActive(false);
        }
 
    }  
}
