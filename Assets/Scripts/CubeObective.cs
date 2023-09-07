using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObective : Objective
{
    [SerializeField]
    private int weight = 1;
    [SerializeField]
    private string description;
    public override int Weight { get { return weight; } set { weight = value; } }
    public override string Description { get { return description; } set { description = value; } }

    public override bool CheckValid()
    {
        float xDeg = Mathf.Abs(this.transform.localEulerAngles.x);
        float zDeg = Mathf.Abs(this.transform.localEulerAngles.z);
        return (zDeg > 80 && zDeg < 100) ||
            (xDeg > 80 && xDeg < 100);
    }
}
