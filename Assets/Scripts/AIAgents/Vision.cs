using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    public string targetTag = "Player";
    public Agent agentData;
    public bool ignoreSightline = false;

    private void Awake()
    {
        agentData = GetComponentInParent<Agent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject target = other.gameObject;

        string tag = target.tag;
        if(tag.Equals(targetTag) == false)
        {
            return;
        }

        bool canSee = ignoreSightline;
        if (!ignoreSightline)
        {
            Vector3 agentPosition = gameObject.transform.position;
            Vector3 targetPosition = target.transform.position;
            Vector3 direction = targetPosition - agentPosition;

            Ray ray = new Ray(agentPosition, direction.normalized);
            RaycastHit hit;

            if (!ignoreSightline && Physics.Raycast(ray, out hit, direction.magnitude))
            {
                if (hit.collider.gameObject.tag.Equals(targetTag))
                {
                    canSee = true;
                }
            }
        }
        if(canSee)
        {
            agentData.target = target;
            agentData.AcceptEvent(AgentEvent.TargetAquired, target);
            return;
        }

        agentData.target = null;
        agentData.AcceptEvent(AgentEvent.TargetAquired, null);

    }

    private void OnTriggerExit(Collider other)
    {
        if(agentData.target != null && other.gameObject == agentData.target)
        {
            agentData.target = null;
            agentData.AcceptEvent(AgentEvent.TargetLost, null);
        }
    }
}
