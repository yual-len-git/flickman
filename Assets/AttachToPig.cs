using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToPig : MonoBehaviour
{
    private FixedJoint temp;
    public Rigidbody objectToAttach;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>() != null && collision.rigidbody.name == "Pig_Rig")
        {
            temp = gameObject.AddComponent<FixedJoint>();
            temp.connectedBody = objectToAttach;
            StartCoroutine(ReleaseIn(7.01f));
        }
    }

    IEnumerator ReleaseIn(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(temp);
    }
}
