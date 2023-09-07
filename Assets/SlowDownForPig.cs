using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlowDownForPig : MonoBehaviour
{
    public Transform pigObj;
    public float slowDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - pigObj.position).magnitude > slowDistance)
        {
            GetComponent<NavMeshAgent>().speed -= 0.1f;
        }
        else if ((transform.position - pigObj.position).magnitude < slowDistance)
        {
            GetComponent<NavMeshAgent>().speed += 0.1f;
        }
        if (GetComponent<NavMeshAgent>().speed > 10)
        {
            GetComponent<NavMeshAgent>().speed = 10;
        }    
    }
}
