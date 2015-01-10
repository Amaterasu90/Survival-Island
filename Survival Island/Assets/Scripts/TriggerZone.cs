using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class TriggerZone : MonoBehaviour {
	
	bool doorIsOpen = false;
	float doorTimer = 0.0f;
	public float doorOpenTime = 3.0f;
	public AudioClip doorOpenSound;
	public AudioClip doorShutSound;
	public int energyDebt = 4;
	public AudioClip lockedSound;
	public Light doorLight;
	
	void PlayAnimation(string name)
	{
		transform.parent.animation.Play (name);
	}
	
	void SetDoorState(bool state)
	{
		doorIsOpen = state;
	}
	
	void Door(string animationName,AudioClip clip,bool state)
	{
		PlayAnimation (animationName);
		PlayOne (clip);
		SetDoorState (state);
	}
	
	void DoorOpening()
	{
		if (!doorIsOpen)
			Door ( "dooropen",doorOpenSound, true);
	}
	
	void DoorClosing()
	{
		if (doorIsOpen) {
			doorTimer += Time.deltaTime;
			
			if(doorTimer>doorOpenTime){
				Door ("doorclose",doorShutSound,false);
				doorTimer = 0.0f;
			}
		}
	}
	
	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag.Equals ("Player"))
			if (Inventory.charge == energyDebt) {
				DoorOpening ();
				if (GameObject.FindWithTag ("powerGUI")) {
					Destroy (GameObject.FindWithTag ("powerGUI"));
				}
			}
			else if (Inventory.charge > 0 && Inventory.charge < 4) {
				PlayOne (lockedSound);
				transform.parent.SendMessage ("MorePower");
			}
			else {
				PlayOne (lockedSound);
				collider.gameObject.SendMessage ("HUDon");
				transform.parent.SendMessage ("Closed");
		}
	}

	
	void PlayOne(AudioClip sound)
	{
		transform.audio.PlayOneShot (sound);
	}
	
	void Start () {
		doorTimer = 0.0f;
	}
	
	void Update () {
		if (Inventory.charge == energyDebt)
			doorLight.color = Color.green;
		DoorClosing ();
	}
}
