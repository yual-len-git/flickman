// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;

// public class balance : MonoBehaviour
// {
//     public static float worldBalance;
//     public float levelStartingBalance;
//     public TMP_Text balanceText;

//     // Start is called before the first frame update
//     void Start()
//     {
//         worldBalance += levelStartingBalance;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         balanceText.text = $"{worldBalance}";
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class balance : MonoBehaviour
{
    public TMP_Text balanceText;

    // Update is called once per frame
    void Update()
    {
        balanceText.text = $"{(float)Math.Round(loadScenes.globalBalance * 100f) / 100f}";
    }


}
