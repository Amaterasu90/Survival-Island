using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextHints : MonoBehaviour {
	public float lifeTime = 3.0f;
	private Text textMessage;
	private RawImage crosshair;

	IEnumerator ClearText()
	{
		yield return new WaitForSeconds (lifeTime);
		textMessage.text = "";
	}
	void ShowHint(string message)
	{
		textMessage.text = message;
		StartCoroutine ("ClearText");
		Debug.Log ("showhints");
	}

	void CrosshairOn()
	{
		crosshair.enabled = true;
	}

	void CrosshairOff()
	{
		crosshair.enabled = false;
	}
	
	void Start () {
		Text[] textValue = GetComponentsInChildren<Text>();
		textMessage = textValue [0];
		RawImage[] rawImage = GetComponentsInChildren<RawImage> ();
		crosshair = rawImage [1];
	}
	void Update () {
		
	}
}
