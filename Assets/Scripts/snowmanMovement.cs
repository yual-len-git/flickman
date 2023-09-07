using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowmanMovement : MonoBehaviour
{
    public static bool snowmanOnLift = false;
    public GameObject sled;
    GameObject attachedTo;
    private bool onLift;

    // Start is called before the first frame update
    void Start()
    {
        onLift = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (onLift) {
            snowmanOnLift = true;
            //match lift speed, position, and rotation
            transform.rotation = attachedTo.transform.rotation;
            Vector3 pos = attachedTo.transform.position + 0.4f * attachedTo.transform.forward;
            pos.y -= 3.65f;
            transform.position = pos;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("chair") && !onLift) {
            onLift = true;
            attachedTo = collision.gameObject;
            sled.SetActive(false);
        }
    }
}
