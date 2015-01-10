using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public  Vector3 offset;

	void Start () {
		transform.position = transform.position + offset;
	}

	void Update () {
	}
}
