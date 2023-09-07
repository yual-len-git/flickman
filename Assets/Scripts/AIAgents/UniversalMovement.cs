using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class UniversalMovement : MonoBehaviour
{
    public CharacterController controller;
    protected Animator animator;
    public float speed = 10f;
    public float rotationTime = .5f;

    protected virtual void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    
    public virtual void Move(Vector3 globalDirection)
    {
    }
}
