using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToLocationState : State
{
    public Transform targetLocation;
    public float stoppingDistance = 1;

    public override void OnEnable()
    {
        base.OnEnable();
        complete = false;
        navAgent.isStopped = false;

        navAgent.stoppingDistance = stoppingDistance;
        navAgent.SetDestination(targetLocation.position);
    }

    public override void Update()
    {
        base.Update();
        if(!complete)
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
