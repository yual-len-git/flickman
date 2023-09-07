using UnityEngine;
using System.Collections;

public class Doors1 : MonoBehaviour {

	Animator animator;
	bool doorOpen;

	void Start()
	{
		doorOpen = false;
		animator = GetComponent<Animator>();
	}

	void OnTriggerEnter(Collider col)
	{
		if ((col.gameObject.tag == "officer") || (col.gameObject.tag == "bKey") || (col.gameObject.tag == "gKey") || (col.gameObject.tag == "sKey"))
		{
	
			doorOpen = true;
			DoorControl ("Open");
		}
	
	}
	void OnTriggerExit(Collider col)
	{
		if (doorOpen) 
		{
			doorOpen = false; 
			DoorControl ("Close");
		}
	}
	void DoorControl(string direction)
	{
		animator.SetTrigger(direction);
	}

}