using UnityEngine;
using System.Collections;

public class TidyObject : MonoBehaviour {
	public float revolveTime = 3.0f;
	void Start () {
		Destroy (gameObject, revolveTime);
	}
	
	void Update () {
	
	}
}
