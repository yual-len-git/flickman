using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI ObjectiveText;
    [SerializeField]
    private List<Objective> objectives;
    [SerializeField]
    private Camera photoCamera;
    // Start is called before the first frame update
    [SerializeField]
    private int playerLayer = 5;
    public LayerMask IgnoreLayer;
    public static float percentageScore = 0;
    public static string lastSceneName = "";

    private void Start()
    {
        percentageScore = 0;
        ObjectiveText.text = "Photo Objectives: \n";
        objectives.ForEach(o =>
        {
            ObjectiveText.text += o.Description + "\n";
        });
    }

    public void CheckObjectives()
    {
        int score = 0;
        int total = 0;
        //Debug.Log("Checking objectives");
        ObjectiveText.text = "Photo Objectives: \n";
        objectives.ForEach(o =>
        {
            total += o.Weight;
            String newText = "NO - " + o.Description + "\n";

            Debug.Log(o);

            RaycastHit hit;
            // Calculate Ray direction
            Vector3 direction = photoCamera.transform.position - o.transform.position;
            if (photoCamera.IsObjectVisible(o.gameObject.GetComponent<Renderer>())) {
                if (Physics.Raycast(o.transform.position, direction, out hit, 1000f, ~IgnoreLayer))
                {
                    if (hit.collider.tag != "MainCamera" && hit.collider.gameObject.name != "DragLocation") //hit something else before the camera
                    {
                        Debug.Log("View Obstructed");
                        Debug.Log(hit.collider);
                    }
                    else
                    {
                        if (o.CheckValid())
                        {
                            Debug.Log("Visible: Valid");
                            score += o.Weight;
                            newText = "YES - " + o.Description + "\n";
                        }
                        else
                        {
                            Debug.Log("Visible: Invalid");
                            
                        }
                    }
                } else
                {
                    Debug.Log("No hit");
                   
                }
            }
            else
            {
                Debug.Log("Not in view");
                
            }
            ObjectiveText.text += newText;
        });
        if(total > 0)
        {
            Debug.Log("Score: " + (int)((score / (float)total) * 100));
        }
        percentageScore = (float)((score / (float)total) * 100);
        lastSceneName = SceneManager.GetActiveScene().name;
        ObjectiveText.text += "Score: " + (int)((score / (float)total) * 100) + "%";

        if (percentageScore == 100) {
            SceneManager.LoadScene("level complete");
        }
    }
}
