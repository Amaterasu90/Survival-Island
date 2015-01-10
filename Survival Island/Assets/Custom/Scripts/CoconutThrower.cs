using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class CoconutThrower : MonoBehaviour {

	public AudioClip throwSound;
	public Rigidbody coconutPrefab;
	public float throwSpeed = 30.0f;
	public static bool canThrow = false;

	void Start () {
	
	}

	void Update () {
		if(networkView.isMine)
		{
			if (Input.GetButtonDown ("Fire1")&&canThrow) {
				PlayOne(throwSound);
				NetworkViewID missleViewId = Network.AllocateViewID();
				networkView.RPC("Create",RPCMode.All,null);
			}
		}
	}

	void PlayOne(AudioClip sound)
	{
		audio.PlayOneShot (sound);
	}
	[RPC]
	void Create()
	{
		if (transform.parent.parent.networkView.isMine) {

			Rigidbody newCoconut = Network.Instantiate (coconutPrefab, transform.position, transform.rotation, 0) as Rigidbody;
			newCoconut.name = "coconut";
			newCoconut.velocity = transform.forward * throwSpeed;
		}
	}
}
