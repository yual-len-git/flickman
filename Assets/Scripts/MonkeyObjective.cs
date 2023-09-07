using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyObjective : Objective
{
    public Transform closeObj;
    [SerializeField]
    private int weight = 1;
    [SerializeField]
    private string description;
    public override int Weight { get { return weight; } set { weight = value; } }
    public override string Description { get { return description; } set { description = value; } }

    public override bool CheckValid()
    {
        return Vector3.Distance(this.transform.position, closeObj.position) < 10;
    }
}
