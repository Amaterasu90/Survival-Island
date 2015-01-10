using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextHints : MonoBehaviour {
	public float lifeTime = 3.0f;
	private Text textMessage;

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
	
	void Start () {
		Text[] textValue = GetComponentsInChildren<Text>();
		textMessage = textValue [0];
	}
	void Update () {
		
	}
}
