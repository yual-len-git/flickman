using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour, IEventObserver, IEventSubject
{
    public GameObject target;
    private Animator anim;
    private NavMeshAgent agent;

    private List<IEventObserver> observers = new List<IEventObserver>();

    private void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();


    }

    public void Update()
    {
        if(anim)
        {
            anim.SetFloat("Speed", agent.velocity.magnitude);
        }
    }

    public void AcceptEvent(AgentEvent e, GameObject emitter)
    {

        foreach (IEventObserver o in new List<IEventObserver>(observers))
        {
            o.AcceptEvent(e, emitter);
        }
    }

    public void Attach(IEventObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IEventObserver observer)
    {
        observers.Remove(observer);
    }
}
