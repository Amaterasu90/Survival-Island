using UnityEngine;
using System.Collections;

public class ThrowTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag.Equals("Player"))
		{
			CoconutThrower.canThrow = true;
		}
	}

	void OnTriggerExit(Collider col)
	{
		if(col.gameObject.tag.Equals("Player"))
		{
			CoconutThrower.canThrow = false;
		}
	}

	void Start () {
	
	}


	void Update () {
	
	}
}
