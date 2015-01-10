using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BaseManager : MonoBehaviour {
	private GameObject canvasGUI;

	void Closed()
	{
		canvasGUI.SendMessage ("ShowHint", "This door seems locked... maybe that generator needs power...");
	}

	void MorePower()
	{
		canvasGUI.SendMessage ("ShowHint", "This door won't budge... guess it needs fully charging - maybe more power cells will help...");
	}

	void Start () {
		canvasGUI = GameObject.Find("GUI");
	}

	void Update () {
	
	}
}
