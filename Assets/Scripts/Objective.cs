
using UnityEngine;

public abstract class Objective : MonoBehaviour
{
    public abstract int Weight
    {
        get;
        set;
    }

    public abstract string Description
    {
        get;
        set;
    }
    public abstract bool CheckValid();
}