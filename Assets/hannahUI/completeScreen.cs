using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class completeScreen : MonoBehaviour
{
    public GameObject[] screens;
    public float[] levelCommissions;
    public TMP_Text percentage;
    public TMP_Text commission;

    // Start is called before the first frame update
    void Start()
    {
        screens[0].SetActive(false);
        screens[1].SetActive(false);
        screens[2].SetActive(false);
        screens[3].SetActive(false);

        float commissionRecieved = GoalController.percentageScore/100 * levelCommissions[LevelCounter.levelNum];

        // must repeat level
        if (GoalController.percentageScore == 0) {
            screens[0].SetActive(true);
        }
        else if (GoalController.percentageScore <= 33.3) {
            screens[1].SetActive(true);
        }
        // proceed to next level
        else if (GoalController.percentageScore <= 66.6) {
            screens[2].SetActive(true);
            if (GoalController.lastSceneName != "Zoo")
                LevelCounter.levelNum ++;
        }
        else {
            screens[3].SetActive(true);
            if (GoalController.lastSceneName != "Zoo")
                LevelCounter.levelNum ++;
        }

        percentage.text = $"{GoalController.percentageScore}" + "%";
        commission.text = $"{commissionRecieved}";
        loadScenes.globalBalance += commissionRecieved;
    }
}
