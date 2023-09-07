using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlanState : State
{
    public bool loop = false;
    public List<State> states;

    private int currentState = 0;

    public override void OnEnable()
    {
        base.OnEnable();
        if(states[currentState] && !complete)
            states[currentState].enabled = true;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        if (states[currentState] && !complete)
            states[currentState].enabled = false;
    }

    public override void Update()
    {
        if(states.Count == 0 || complete)
        {
            complete = true;
            return;
        }
        if(states[currentState].complete)
        {
            states[currentState].enabled = false;
            currentState++;
            if(currentState >= states.Count)
            {
                if(!loop)
                {
                    complete = true;
                    return;
                }
                currentState = currentState % states.Count;
            }
            states[currentState].enabled = true;
        }
    }
}
