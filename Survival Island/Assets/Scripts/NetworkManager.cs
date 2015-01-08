using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	public float buttonX;
	public float buttonY;
	public float buttonWidth;
	public float buttonHeight;
	public string gameNameType = "CGCookie_Tutorial_Networking";
	public string gameName="Tutorial_Game_Name";
	private bool _refreshing;
	private HostData[] _hostData;
	public GameObject playerPrefab;
	public GameObject enemyPrefab;
	public Transform spawnPosition;
	
	
	
	void StartServer(){
		Network.InitializeServer (32, 25001,!Network.HavePublicAddress());
		MasterServer.RegisterHost (gameNameType, gameName, "This is a tutorial game");
	}
	
	void RefreshHostList ()
	{
		MasterServer.RequestHostList(gameNameType);
		_refreshing = true;
	}
	
	void spawnPlayer (GameObject player)
	{
		Network.Instantiate (player, spawnPosition.position, Quaternion.identity, 0);
		SetCameras();
	}

	void SetCameras()
	{
		SetCamera ("MainCamera", false);
		SetCamera ("camera", true);
	}

	void SetCamera(string tagName, bool enable)
	{
		GameObject camera = GameObject.FindWithTag (tagName);
		camera.SetActive (enable);
	}
	
	void OnServerInitialized(){
		Debug.Log ("Server initialized and ready");
		spawnPlayer (playerPrefab);
	}
	
	void OnConnectedToServer(){
		spawnPlayer (enemyPrefab);
	}
	
	void OnGUI(){
		if(!Network.isClient && !Network.isServer){
			if (GUI.Button (new Rect (buttonX, buttonY, buttonWidth, buttonHeight), "Start Server")) {
				Debug.Log ("Starting Server!");
				StartServer();
			}
			if (GUI.Button (new Rect (buttonX, buttonY * 1.2f + buttonHeight, buttonWidth, buttonHeight), "Refresh Host")) {
				Debug.Log ("Refreshing");
				RefreshHostList();
			}
			
			if(_hostData != null){
				for (int i=0;i<_hostData.Length;i++) {
					if(GUI.Button (new Rect(buttonX * 1.5f +buttonWidth,buttonY*1.2f+(buttonHeight*i),buttonWidth*3f,buttonHeight*0.5f),_hostData[i].gameName)){
						Network.Connect(_hostData[i]);
						Debug.Log("Connect"+_hostData[i].gameName.ToString());
					}
				}
			}
		}
	}
	
	void OnMasterServerEvent(MasterServerEvent masterServerEvent){
		if (masterServerEvent == MasterServerEvent.RegistrationSucceeded) {
			Debug.Log("Registred Server!");
		}
	}
	
	void Start () {
		buttonX = Screen.width * 0.1f;
		buttonY = Screen.height * 0.1f;
		buttonWidth = Screen.width * 0.15f;
		buttonHeight = Screen.height * 0.05f;
	}
	
	void Update () {
		if (_refreshing) {
			if(MasterServer.PollHostList().Length > 0)
			{
				_refreshing = false;
				Debug.Log(MasterServer.PollHostList().Length);
				_hostData = MasterServer.PollHostList();
			}
		}
	}
}
