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
			guest.networkView.RPC("CellPickUp",RPCMode.All,null);
			Network.Destroy(gameObject);
		}
	}

	void Update () {
		transform.Rotate(new Vector3(0,rotationSpeed * Time.deltaTime,0));
	}
}
