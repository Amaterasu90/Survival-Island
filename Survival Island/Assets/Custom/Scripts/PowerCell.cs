using UnityEngine;
using System.Collections;

public class PowerCell : MonoBehaviour {
	public float rotationSpeed = 100.0f;

	void Start () {
	
	}

	void OnTriggerEnter(Collider guest)
	{
		if(guest.gameObject.tag.Equals("Player"))
		{
			guest.gameObject.SendMessage("CellPickUp");
			DestroyObject(gameObject);
		}
	}

	void Update () {
		transform.Rotate(new Vector3(0,rotationSpeed * Time.deltaTime,0));
	}
}
