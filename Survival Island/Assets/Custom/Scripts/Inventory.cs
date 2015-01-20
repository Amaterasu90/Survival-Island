using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Inventory : MonoBehaviour {
	
	public static int charge = 0;
	public AudioClip collectSound;
	public Texture[] hudCharge;
	public RawImage currentChargeHudGUI;
	public Texture2D[] meterCharge;
	private Renderer currentStateMeter;
	
	void Start () {
		charge = 0;

	}
	
	void Update () {
	}

	[RPC]
	void CellPickUp()
	{
		AudioSource.PlayClipAtPoint (collectSound, transform.position);
		currentChargeHudGUI.texture = hudCharge [charge];
		GameObject generatorDisplay = GameObject.FindWithTag ("generator");
		generatorDisplay.renderer.material.mainTexture = meterCharge [charge];
		++charge;
	}
	
	void HUDon(){
		if (!currentChargeHudGUI.enabled) {
			currentChargeHudGUI.enabled = true;
		}
	}
}
