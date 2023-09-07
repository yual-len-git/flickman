using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfInterest : MonoBehaviour
{
    public bool open = true;
    public float time = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(open);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "closed")
        {
            open = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "closed")
        {
            Debug.Log("enabled");
            open = true;
        }
    }
}
