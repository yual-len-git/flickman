using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

public class WanderState : State
{
    public float wanderTime = -1f;
    public float wanderRadius = 10f;
    public float minWaitBetweenWander = 0f;
    public float maxWaitBetweenWander = 10f;

    private float stoppingDistance = 1f;
    private Vector3 startingPos;
    private bool wandering = false;

    public override void OnEnable()
    {
        base.OnEnable();
        complete = false;
        navAgent.isStopped = false;
        wandering = false;
        startingPos = navAgent.transform.position;
        navAgent.stoppingDistance = stoppingDistance;
        StartCoroutine(RetargetAfterTime(Random.Range(minWaitBetweenWander, maxWaitBetweenWander)));
        if (wanderTime > 0)
        {
            StartCoroutine(CompleteAfterTime());
        }
    }
    IEnumerator CompleteAfterTime()
    {
        Assert.IsTrue(wanderTime > 0);
        yield return new WaitForSeconds(wanderTime);
        complete = true;
    }

    IEnumerator RetargetAfterTime(float t)
    {
        Assert.IsTrue(t > 0);
        yield return new WaitForSeconds(t);
        SetWanderTarget();
    }

    public override void Update()
    {
        base.Update();
        if (!complete && wandering)
        {
            if (NavDone())
            {
                wandering = false;
                StartCoroutine(RetargetAfterTime(Random.Range(minWaitBetweenWander, maxWaitBetweenWander)));
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

    private void SetWanderTarget()
    {
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += startingPos;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, wanderRadius, 1);
        navAgent.SetDestination(hit.position);
        wandering = true;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawWireSphere(startingPos, wanderRadius);
    }
}
