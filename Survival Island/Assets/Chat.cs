using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chat : MonoBehaviour {

	List<string> history = new List<string>();
	string currentMessage = string.Empty;

	private void OnGUI()
	{
		history.Add ("Arek");
		history.Add ("Arek1");

	}
}
