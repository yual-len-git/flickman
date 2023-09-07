using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPOIState : State
{
    public List<PointOfInterest> targetLocation;
    public float stoppingDistance = 1;

    private int index = 0;
    private float fadeTime = .5f;
    public override void OnEnable()
    {
        base.OnEnable();
        complete = false;
        navAgent.isStopped = false;

        navAgent.stoppingDistance = stoppingDistance;
        navAgent.SetDestination(targetLocation[index].gameObject.transform.position);
    }

    public override void Update()
    {
        base.Update();
        if(!complete)
        {
            if (NavDone())
            {
                if(targetLocation[index].open)
                {
                    StartCoroutine(performAction());
                } else
                {
                    index = (index + 1) % targetLocation.Count;
                    navAgent.SetDestination(targetLocation[index].gameObject.transform.position);
                }
            }
        }
    }

    IEnumerator performAction()
    {
        ObjectHolder oh = this.gameObject.GetComponent<ObjectHolder>();
        if(oh)
        {
            oh.StopHolding();
        }
        LeanTween.alpha(gameObject, 0f, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        yield return new WaitForSeconds(targetLocation[index].time);
        LeanTween.alpha(gameObject, 1f, fadeTime);
        complete = true;
        GetComponent<Agent>().AcceptEvent(AgentEvent.Complete, gameObject);
        if (oh)
        {
            oh.StartHolding();
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
