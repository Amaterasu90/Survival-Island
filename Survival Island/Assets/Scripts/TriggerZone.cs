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
	public GameObject energyGUI;

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
			if (Inventory.charge == energyDebt)
			{
				DoorOpening ();
				if(GameObject.Find("PowerGUI")){
					Destroy(GameObject.Find("PowerGUI"));
					doorLight.color = Color.green;
				}
			}
			else {
				PlayOne (lockedSound);
				collider.gameObject.SendMessage("HUDon");
			Text text = energyGUI.GetComponent<Text>();
			text.SendMessage("ShowHint","This door seems locked... maybe that generator needs power...");
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
		DoorClosing ();
	}
}
