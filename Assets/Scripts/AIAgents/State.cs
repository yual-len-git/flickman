using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/*
 * State Machine Adapted from these tutorials:
 *  https://www.youtube.com/playlist?list=PLcRSafycjWFdoYKNUGn9J2llIDrTZVSJg
 */
[RequireComponent(typeof(Agent))]

public abstract class State : MonoBehaviour, IEventObserver
{
    public Agent agent;
    public List<Transition> transitions = new List<Transition>();
    protected NavMeshAgent navAgent;

    private bool _complete;
    public bool complete
    {
        get { return _complete; }
        set { _complete = value; }
    }

    private void Awake()
    {
        agent = GetComponent<Agent>();
        navAgent = GetComponent<NavMeshAgent>();
    }

    public virtual void OnEnable()
    {
        agent.Attach(this);
    }

    public virtual void OnDisable()
    {
        agent.Detach(this);
    }

    public virtual void Update()
    {

    }

    public void AcceptEvent(AgentEvent e, GameObject emitter)
    {
        foreach(Transition transition in transitions)
        {
            if(e.Equals(transition.triggerEvent))
            {
                transition.target.enabled = true;
                this.enabled = false;
                return;
            }
        }
    }

    [Serializable]
    public struct Transition
    {
        public AgentEvent triggerEvent;
        public State target;
    }
}
