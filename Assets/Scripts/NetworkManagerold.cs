using UnityEngine;
using System.Collections;

public class NetworkManagerold : MonoBehaviour {
	public int playerSpawn = 0;
	private const string typeName = "Game Name";
	private const string gameName = "room name";
	public int mf;

	private HostData[] hostList;
	public GameObject placeholdF;
	public GameObject placeholdB;
	public GameObject placeholdR;
	public GameObject placeholdL;
	public GameObject playerPrefab;
	public GameObject playerPrefab1;
	public GameObject playerPrefab2;
	public GameObject playerPrefab3;
	public GameObject playerPrefabf;
	public GameObject playerPrefab1f;
	public GameObject playerPrefab2f;
	public GameObject playerPrefab3f;
	private void StartServer()
	{
		Network.InitializeServer (2, 8200, !Network.HavePublicAddress());
		MasterServer.RegisterHost (typeName, gameName);
	}


	void OnServerInitialized(){
		Debug.Log ("Server Started");
		Debug.Log(playerSpawn);
//		if (GUI.Button(new Rect(100,100,250,100), "ADD PLAYER"))
//		{
			SpawnPlayer ();
		//playerSpawn++;
		Debug.Log(playerSpawn);
			
	//	}

	}

	void OnConnectedToServer()
	{
		SpawnPlayer ();
		Debug.Log ("Connected");
			
	}

	private void SpawnPlayer()
	{
//		if (GUI.Button(new Rect(100,100,250,100), "add male"))
//		{
//			mf = 1;
//		
//			Debug.Log ("spawning new player2" + playerSpawn);
//			
//		}
		
	
		if (playerSpawn > 3 )
		{
			Debug.Log(playerSpawn+"breste");
			playerSpawn = 0;
			Debug.Log(playerSpawn+"rester ");
		}
		if (playerSpawn == 0&& mf == 1)
		{

			GameObject playerObj = Network.Instantiate (playerPrefab, new Vector3 (0f, 5f, 0f), Quaternion.Euler(0, 90, 0), 0) as GameObject;
		//	GameObject playerObj1 = Network.Instantiate (placeholdF, new Vector3 (1f, 5f, 0f), Quaternion.Euler(0, 90, 0), 0) as GameObject;


			//	playerObj.GetComponent<Player>().playerTeam = 1;
			Debug.Log(playerSpawn+"p0");
			 
		}
		if (playerSpawn == 1 && mf == 1)
		{
			Debug.Log(playerSpawn+"bp1");
			GameObject playerObj = Network.Instantiate (playerPrefab1, new Vector3 (0f, 5f, 0f), Quaternion.Euler(0, 90, 0), 0) as GameObject;
//			playerObj.GetComponent<Player>().playerTeam = 2;
			Debug.Log(playerSpawn+"p1");
		 
		}
		if (playerSpawn == 2&& mf == 1)
		{
			Debug.Log(playerSpawn+"bp2");
			GameObject playerObj = Network.Instantiate (playerPrefab2, new Vector3 (0f, 5f, 0f), Quaternion.Euler(0, 90, 0), 0) as GameObject;
		//	playerObj.GetComponent<Player>().playerTeam = 3;
			Debug.Log(playerSpawn+"p2");
			 
		}
		if (playerSpawn == 3&& mf == 1)
		{
			Debug.Log(playerSpawn+"bp3");
			GameObject playerObj = Network.Instantiate (playerPrefab3, new Vector3 (0f, 5f, 0f), Quaternion.Euler(0, 90, 0), 0) as GameObject;
	//		playerObj.GetComponent<Player>().playerTeam = 4;
			Debug.Log(playerSpawn+"p3");
			 
		}
		if (playerSpawn == 0&& mf == 2)
		{
			GameObject playerObj = Network.Instantiate (playerPrefabf, new Vector3 (0f, 5f, 0f), Quaternion.Euler(0, 90, 0), 0) as GameObject;
			//	playerObj.GetComponent<Player>().playerTeam = 1;
			Debug.Log(playerSpawn+"p0");
			
		}
		if (playerSpawn == 1 && mf == 2)
		{
			Debug.Log(playerSpawn+"bp1");
			GameObject playerObj = Network.Instantiate (playerPrefab1f, new Vector3 (0f, 5f, 0f), Quaternion.Euler(0, 90, 0), 0) as GameObject;
			//			playerObj.GetComponent<Player>().playerTeam = 2;
			Debug.Log(playerSpawn+"p1");
			
		}
		if (playerSpawn == 2&& mf == 2)
		{
			Debug.Log(playerSpawn+"bp2");
			GameObject playerObj = Network.Instantiate (playerPrefab2f, new Vector3 (0f, 5f, 0f), Quaternion.Euler(0, 90, 0), 0) as GameObject;
			//	playerObj.GetComponent<Player>().playerTeam = 3;
			Debug.Log(playerSpawn+"p2");
			
		}
		if (playerSpawn == 3&& mf == 2)
		{
			Debug.Log(playerSpawn+"bp3");
			GameObject playerObj = Network.Instantiate (playerPrefab3f, new Vector3 (0f, 5f, 0f), Quaternion.Euler(0, 90, 0), 0) as GameObject;
			//		playerObj.GetComponent<Player>().playerTeam = 4;
			Debug.Log(playerSpawn+"p3");
			
		}
		playerSpawn++;
	}

	void OnGUI()
	{
		if (Network.isClient || Network.isServer) 
		{
//		if (GUI.Button(new Rect(300,100,250,100), "ADD PLAYER"))
//		{
//				 
//				if (GUI.Button(new Rect(100, 250, 250, 100), "Refresh")){
//					RefreshHostList();
//				}
////								if (GUI.Button(new Rect(100, 250, 250, 100), "add female")){
//				mf = 2;
//					SpawnPlayer ();
//				Debug.Log ("spawning new player2" + playerSpawn);
//			}

		//		Debug.Log ("spawning new playerbbbb" + playerSpawn);
			 
//			}	
		}

		if (!Network.isClient && !Network.isServer) 
		{
			if (GUI.Button(new Rect(100,100,250,100), "start"))
			{
				StartServer();

			}

			if (GUI.Button(new Rect(100, 250, 250, 100), "Refresh")){
				RefreshHostList();
			}
			if (hostList != null)
			{
				for (int i = 0; i < hostList.Length; i++) {
					if (GUI.Button(new Rect(400, 100+ (110* i), 300, 100), hostList[i].gameName))
					{
						JoinServer(hostList[i]);
					}
				}


			}


		}

		
	}
	private void RefreshHostList(){

		MasterServer.RequestHostList (typeName);

	}

	void OnMasterServerEvent(MasterServerEvent msEvent)
	{
		if (msEvent == MasterServerEvent.HostListReceived) {
			hostList = MasterServer.PollHostList();
				}
	}

	private void JoinServer(HostData hostData)
	{
		Network.Connect (hostData);
		}




}
