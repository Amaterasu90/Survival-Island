using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ThrowTrigger : MonoBehaviour {
	private GameObject GUIImage;
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag.Equals("Player"))
		{
			if(!CoconutWin.haveWon){
				GUIImage.SendMessage("ShowHint","There's a power cell attached to this game, maybe I'll win if I can knock down all the targets");
			}
			CoconutThrower.canThrow = true;
			GUIImage.SendMessage("CrosshairOn");
		}
	}

	void OnTriggerExit(Collider col)
	{
		if(col.gameObject.tag.Equals("Player"))
		{
			CoconutThrower.canThrow = false;
			GUIImage.SendMessage("CrosshairOff");
		}
	}

	void Start () {
		GUIImage = GameObject.Find ("GUI");
	}


	void Update () {
	
	}
}
