using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToRandomLocationState : State
{
    public List<Transform> targetLocations;
    public float stoppingDistance = 1;

    public override void OnEnable()
    {
        base.OnEnable();
        complete = false;
        navAgent.isStopped = false;

        navAgent.stoppingDistance = stoppingDistance;
        Vector3 loc = targetLocations[Random.Range(0, targetLocations.Count)].position;
        navAgent.SetDestination(loc);
    }

    public override void Update()
    {
        base.Update();
        if (!complete)
        {
            if (NavDone())
            {
                navAgent.isStopped = true;
                complete = true;
            }
        }
    }

    private bool NavDone()
    {
        if (!navAgent.pathPending)
        {
            if (navAgent.remainingDistance <= navAgent.stoppingDistance)
            {
                if (!navAgent.hasPath || navAgent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
