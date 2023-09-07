using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysTruePig : Objective
{
    [SerializeField]
    private int weight = 1;
    public GameObject pig;
    [SerializeField]
    private string description;
    public override int Weight { get { return weight; } set { weight = value; } }
    public override string Description { get { return description; } set { description = value; } }


    public override bool CheckValid()
    {
        if(pig.transform.position.y>5){
            return true;
        }
        else {
            return false; 
        }
    }
}
