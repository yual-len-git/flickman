using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockLevels : MonoBehaviour
{
    public GameObject[] locked;
    public GameObject[] unlocked;

    // Start is called before the first frame update
    void Start()
    {
        locked[0].SetActive(true);
        locked[1].SetActive(true);
        locked[2].SetActive(true);
        locked[3].SetActive(true);
        unlocked[0].SetActive(false);
        unlocked[1].SetActive(false);
        unlocked[2].SetActive(false);
        unlocked[3].SetActive(false);

        // if previous level has been completed
        for (int i = 0; i <= LevelCounter.levelNum; i++) {
            // remove greyed out image
            locked[i].SetActive(false);
            // enable level button
            unlocked[i].SetActive(true);
        }
    }
}
