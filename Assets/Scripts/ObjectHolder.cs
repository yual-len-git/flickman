using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolder : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform holdLocation;
    public bool rotate = false;

    private bool shouldHold = true;
    private Collider holding = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(UnityEngine.Collider other)
    {
        DragObject dragO = other.gameObject.GetComponent<DragObject>();
        if (shouldHold && dragO && (holding == other || !dragO.held))
        {
            if (!dragO.IsAttached()) {
                if (other.tag == "sKey")
                {
                    Destroy(other.gameObject);
                    //TODO play munch
                    Agent a = GetComponent<Agent>();
                    if (a)
                    {
                        a.AcceptEvent(AgentEvent.AteHotdog, gameObject);
                    }
                    return;
                }
                dragO.held = true;
                dragO.GetComponent<Rigidbody>().useGravity = false;
                holding = other;
                dragO.transform.position = holdLocation.position;
                if (rotate)
                {
                    dragO.transform.rotation = holdLocation.rotation;
                }
                else
                {
                    dragO.transform.rotation = Quaternion.identity;
                }
            } else
            {
                if(holding == other)
                {
                    holding = null;
                    dragO.held = false;
                    dragO.GetComponent<Rigidbody>().useGravity = true;
                }
            }
        }
    }

    public void StopHolding()
    {
        this.shouldHold = false;
    }
    public void StartHolding()
    {
        this.shouldHold = true;
    }
}
