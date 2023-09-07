using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitState : State
{
    public float waitTime = 1.0f;
    public override void OnEnable()
    {
        base.OnEnable();
        complete = false;
        StartCoroutine(CompleteAfterTime());
    }

    IEnumerator CompleteAfterTime()
    {
        yield return new WaitForSeconds(waitTime);
        complete = true;
    }
}
