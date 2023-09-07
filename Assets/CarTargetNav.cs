using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarTargetNav : MonoBehaviour
{
    public NavMeshAgent nav;
    public Transform[] targets;
    private int i;
    private int targetNumber;
    // Start is called before the first frame update
    void Start()
    {
        targetNumber = targets.Length;
        i = 0;
        nav.SetDestination(targets[i].position);
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(targets[i].position, transform.position);
        if (dist < 2)
        {
            if (i == (targetNumber - 1))
            {
                i = 0;
                nav.SetDestination(targets[i].position);
            } else
            {
                i += 1;
            }
            nav.SetDestination(targets[i].position);
        }
    }
}
