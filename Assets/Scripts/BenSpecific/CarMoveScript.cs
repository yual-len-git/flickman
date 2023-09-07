using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMoveScript : MonoBehaviour
{
    public Transform moveTarget;
    public Transform carPos;
    public Rigidbody car;
    public float carVelocity = 1;
    public bool pig;
    public CarMoveScript thisScript;

    // Start is called before the first frame update
    void Start()
    {
        if (pig)
        {
            InvokeRepeating("Bounce", 1f, 1f);
        }
    }

    private void Update()
    {
        transform.LookAt(new Vector3(moveTarget.position.x, 0, moveTarget.position.z));
    }

    void Bounce()
    {
        if (thisScript.enabled == true)
        {
            car.velocity += new Vector3(0, 5, 0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        car.velocity = (new Vector3(transform.forward.x * carVelocity, car.velocity.y, transform.forward.z * carVelocity));
    }
}
