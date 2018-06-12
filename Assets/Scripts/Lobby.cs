using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Lobby : MonoBehaviour 
{
	public playerData pd;
    public GameObject turretBlue;
    public GameObject turretRed;
	public GameObject standred;
	public GameObject standblue;
    EventSystem eventSystem;
    GameObject startButton;
    GameObject createWorldButton;
    Text cwText;
    Text startText;


	public GameObject redcross;
	public GameObject Bluecross;
	public GameObject bluehit;
	public GameObject redhit;

    //GameObject[] redTeam = new GameObject[4];
    //GameObject[] blueTeam = new GameObject[4];
    GameObject[] playerButton = new GameObject[8];

    public GameObject mapUI;
    private GameObject thisUI;


	public GameObject Team1male;
	public GameObject Team1Female;
	public GameObject Team2male;
	public GameObject Team2Female;
	bool isclick = false;
    public GameObject boyButton;
    public GameObject girlButton;
	public bool locker = false;

    int index = -1;
    int slot = -1;
    bool genderButtons = false;
    public	bool isBoy1= false;
    public	bool isGirl1= false;
    string[] redStatus = new string[4];
    string[] blueStatus = new string[4];

	CreateGrid creategrid = new CreateGrid();
	GameManager gamemanager;
	NetworkManager networkmanager = new NetworkManager ();

	public int team = 0 ;
	public GameObject block1; 
		//public GameObject walln;
		//public GameObject wallw;
		//public GameObject walle;
		//public GameObject walls;
	public GameObject wall;
	public int worldWidth  = 50;
	public int worldHeight  = 50;
	
	public float[,] randomLift;
	
	
	
	public float spawnSpeed = 0;

    // Wall/Base Objects

    public GameObject StoneWall1;
    public GameObject StoneWall2;
    public GameObject StoneWall3;

    public GameObject RedBase;
    public GameObject BlueBase;

    float stoneHeight = -5;
    float baseHeight = -0.3f;

    //30 sec Timer
    float timer = -1;
    float timer_length = 3;
    bool timer_lock = true;
	bool unlock;

	void Start () 
    {

		eventSystem = EventSystem.current;

		gamemanager = GameManager.Instance;
		//networkmanager = NetworkManager.Instance;
		 
		startButton = transform.FindChild ("Start_Button").gameObject;
		startButton.GetComponent<Button> ().onClick.AddListener (() => { StartButton (); });

        createWorldButton = transform.FindChild("Create_World").gameObject;
        createWorldButton.GetComponent<Button>().onClick.AddListener(() => { CreateWorldButton(); });

        startText = startButton.transform.FindChild("Text").GetComponent<Text>();

        if (Network.isServer)
        {
            cwText = createWorldButton.transform.FindChild("Text").GetComponent<Text>();
            cwText.text = "Create World";
        }

        playerButton[0] = transform.FindChild("Red_Slot_1").gameObject;
        playerButton[1] = transform.FindChild("Red_Slot_2").gameObject;
        playerButton[2] = transform.FindChild("Red_Slot_3").gameObject;
        playerButton[3] = transform.FindChild("Red_Slot_4").gameObject;

        playerButton[4] = transform.FindChild("Blue_Slot_1").gameObject;
        playerButton[5] = transform.FindChild("Blue_Slot_2").gameObject;
        playerButton[6] = transform.FindChild("Blue_Slot_3").gameObject;
        playerButton[7] = transform.FindChild("Blue_Slot_4").gameObject;

        playerButton[0].GetComponent<Button>().onClick.AddListener(() => { PlayerButton(0); });
        playerButton[1].GetComponent<Button>().onClick.AddListener(() => { PlayerButton(1); });
        playerButton[2].GetComponent<Button>().onClick.AddListener(() => { PlayerButton(2); });
        playerButton[3].GetComponent<Button>().onClick.AddListener(() => { PlayerButton(3); });
        playerButton[4].GetComponent<Button>().onClick.AddListener(() => { PlayerButton(4); });
        playerButton[5].GetComponent<Button>().onClick.AddListener(() => { PlayerButton(5); });
        playerButton[6].GetComponent<Button>().onClick.AddListener(() => { PlayerButton(6); });
        playerButton[7].GetComponent<Button>().onClick.AddListener(() => { PlayerButton(7); });
	}


    void Update()
    {
        if (timer >= 0 && timer_lock)
        {
            networkView.RPC("Unlock", RPCMode.AllBuffered);
        }
    }
    // Method for each button

    [RPC]
    void Unlock()
    {
        Text startText;

        startText = startButton.transform.FindChild("Text").GetComponent<Text>();



        timer += Time.deltaTime;
        startText.text = string.Format("{0}", (int)timer * -1 + timer_length);



        if (timer >= timer_length)
        {
            Debug.Log("Timer n Stuff, Good to go");
            startText.text = "Start Game";
            timer_lock = false;
        }

    }
    // Method for each button

    [RPC]
    void CreateWorldButton()
    {
        if (Network.isServer && timer < 0)
        {
            //if(unlock == false)
            //{
            CreateWorld();
            //unlock = true;
            //}
            timer = 0;
        }
    }


	[RPC]
    void StartButton()
    {
		//timer = 0;
        if (!timer_lock)
        {
            this.DestroyButtons();

            gamemanager.StartGame();
            networkmanager.destroylobby();
			Debug.Log(index);

            Screen.lockCursor = true;
            Screen.showCursor = false;

            GridManager.gameStart = true;
            thisUI = Instantiate(mapUI, Vector3.zero, Quaternion.Euler(0, 90, 0)) as GameObject;

            if ((index >= 0 && index < 4) && isclick)
            {

                Debug.Log("HERE WE GO!");
                Debug.Log("index is " + index);
                if (isBoy1)
                {
					GameObject playerObj1m = Network.Instantiate(Team1male, new Vector3(worldWidth -6.0f,3.5f,worldHeight -8.0f), Quaternion.Euler(0, 90, 0), 0) as GameObject;
					                                             //44f, 5f, 42f
                  //  playerObj.networkView.RPC("SetUsername", RPCMode.AllBuffered, networkmanager.advancedSettings.username);
                    Debug.Log("boy");
					for (int i = 0; i < 50; i++) {
						Debug.Log("printing out this shit 40 times");
					}
					pd = Team1male.GetComponent<playerData>();
					pd.isboypd = true;
					NetworkManager mn = GetComponent<NetworkManager>();
					NetworkManager.spawnspot69 = new Vector3(44f, 5f, 42f);
					Health	p = Team1male.GetComponent<Health>();
					p.orgspawn1 = new Vector3(worldWidth -6.0f,3.5f,worldHeight -8.0f);
					Debug.Log("p oeg spawn is " + p.orgspawn1);

                    GridState.player = playerObj1m;
                }
                else if (isGirl1)
                {
					GameObject playerObj1f = Network.Instantiate(Team1Female, new Vector3(worldWidth -6.0f,3.5f,worldHeight -4.0f), Quaternion.Euler(0, 90, 0), 0) as GameObject;
              //      playerObj.networkView.RPC("SetUsername", RPCMode.AllBuffered, networkmanager.advancedSettings.username);
					//44f, 5f, 46f
					 
					Debug.Log("girl");
					pd = Team1Female.GetComponent<playerData>();
					pd.isgirlpd = true;
					Health	p = Team1male.GetComponent<Health>();
					NetworkManager.spawnspot69 = new Vector3(worldWidth -6.0f,3.5f,worldHeight -4.0f);
					Debug.Log("p oeg spawn is " + p.orgspawn1);

                    GridState.player = playerObj1f;
				 
                }
            }
            if ((index >= 4 && index < 9) && isclick)
            {

                Debug.Log("HERE WE GO!");
                Debug.Log("index is " + index);
                if (isBoy1)
                {
                    GameObject playerObj2m = Network.Instantiate(Team2male, new Vector3(5f, 5f, 5f), Quaternion.Euler(0, 90, 0), 0) as GameObject;
          //          playerObj.networkView.RPC("SetUsername", RPCMode.AllBuffered, networkmanager.advancedSettings.username);
                    Debug.Log("boy");
					pd = Team2male.GetComponent<playerData>();
					pd.isboypd = true;
					Health	pb = Team1male.GetComponent<Health>();
					NetworkManager.spawnspot69 = new Vector3(5f, 5f, 5f);
					Debug.Log("p oeg spawn is " + pb.orgspawn1);

                    GridState.player = playerObj2m;
                }
                else if (isGirl1)
                {
                    GameObject playerObj2f = Network.Instantiate(Team2Female, new Vector3(6f, 5f, 6f), Quaternion.Euler(0, 90, 0), 0) as GameObject;
              //      playerObj.networkView.RPC("SetUsername", RPCMode.AllBuffered, networkmanager.advancedSettings.username);
                    Debug.Log("girl");
					pd = Team2Female.GetComponent<playerData>();
					pd.isgirlpd = true;
					Health	pb = Team1male.GetComponent<Health>();
					NetworkManager.spawnspot69 = new Vector3(6f, 5f, 6f);
					Debug.Log("p oeg spawn is " + pb.orgspawn1);

                    GridState.player = playerObj2f;
                }
            }
        
        }

	}

    //[RPC]
	void PlayerButton(int button_num)
    {
        Text boxText;
        boxText = playerButton[button_num].transform.FindChild("Text").GetComponent<Text>();

        if (boxText.text == "Empty Slot")
        {
            index = button_num;

            switch (button_num)
            {
                case 0:
                    SpawnButtons(-200, 50);
                    Debug.Log("CLICKED RED BUTTON 1");
                    break;

                case 1:
                    SpawnButtons(-200, 0);
                    Debug.Log("CLICKED RED BUTTON 2");
                    break;

                case 2:
                    SpawnButtons(-200, -50);
                    Debug.Log("CLICKED RED BUTTON 3");
                    break;

                case 3:
                    SpawnButtons(-200, -100);
                    Debug.Log("CLICKED RED BUTTON 4");
                    break;

                case 4:
                    SpawnButtons(200, 50);
                    Debug.Log("CLICKED BLUE BUTTON 1");
                    break;

                case 5:
                    SpawnButtons(200, 0);
                    Debug.Log("CLICKED BLUE BUTTON 2");
                    break;

                case 6:
                    SpawnButtons(200, -50);
                    Debug.Log("CLICKED BLUE BUTTON 3");
                    break;

                case 7:
                    SpawnButtons(200, -100);
                    Debug.Log("CLICKED BLUE BUTTON 4");
                    break;

                default:
                    Debug.Log("WTF did you press?");
                    break;
            }
        }
    }

	//[RPC]
    // Creates Boy/Girl Buttons on top of button
    void SpawnButtons(int x, int y)
    {
		if(genderButtons)
		{
		    //networkView.RPC("DestroyButtons",RPCMode.All);
            DestroyButtons();
		}
	//	
        GameObject boy = null;
        GameObject girl = null;

        boy = Instantiate(boyButton, Vector3.zero, Quaternion.identity) as GameObject;

        boy.transform.parent = transform;
        boy.GetComponent<RectTransform>().anchoredPosition = new Vector2(x - 40, y);
        boy.GetComponent<Button>().onClick.AddListener(() => { BoyButton(); });

        girl = Instantiate(girlButton, Vector3.zero, Quaternion.identity) as GameObject;

        girl.transform.parent = transform;
        girl.GetComponent<RectTransform>().anchoredPosition = new Vector2(x + 40, y);
        girl.GetComponent<Button>().onClick.AddListener(() => { GirlButton(); });

        genderButtons = true;
    }

    void DestroyButtons()
    {
        if(genderButtons)
        {
            GameObject aboutToDie = transform.FindChild("Boy_Button(Clone)").gameObject;
			//Network.Destroy(aboutToDie);
			Destroy(aboutToDie);


            GameObject aboutToDie2 = transform.FindChild("Girl_Button(Clone)").gameObject;
			//Network.Destroy(aboutToDie2);
		    Destroy(aboutToDie2);


            // Boy_Button(Clone)

            Debug.Log("#%!@ your buttons");

            genderButtons = false;
        }
    }

    void BoyButton()
    {
        Debug.Log("CLICKED BOY BUTTON");
		networkView.RPC ("AddPlayer", RPCMode.All, true, index, slot);  //buffered again so late joiner with see it
    }

    void GirlButton()
    {
        Debug.Log("CLICKED GIRL BUTT");
		networkView.RPC ("AddPlayer", RPCMode.All, false, index, slot);
    }

	[RPC]
    void AddPlayer(bool isBoy, int new_slot, int old_slot)
    {
        Text boxText;
        
        if(old_slot >= 0)
        {
            boxText = playerButton[old_slot].transform.FindChild("Text").GetComponent<Text>();
            boxText.text = "Empty Slot";
        }


		//networkView.RPC ("SpawnButtons", RPCMode.AllBuffered,200,-100);
	    
        slot = index;
        // Name for new slot
        boxText = playerButton[new_slot].transform.FindChild("Text").GetComponent<Text>();

        //GameObject wtfamidoing;
        //wtfamidoing = transform.FindChild("GameManager").gameObject;
        //boxText.text = wtfamidoing.GetComponent<NetworkManager>().advancedSettings.username;
            
        if (isBoy)
        {
            boxText.text = "Player (Boy)";
            isclick = true;
            isBoy1 = true;
        }
        else
        {
            boxText.text = "Player  (Girl)";
            isclick = true;
            isGirl1 = true;
        }

		if(genderButtons)
		{
		    //networkView.RPC("DestroyButtons", RPCMode.All);
            DestroyButtons();
		}

    }
	

	[RPC]
	void CreateWorld () {
		
		randomLift = new float[worldWidth, worldHeight];
		
		
		
		randomLift[0, 0] = 0;
		
		int upordown;
		
		for (int x = 1; x < worldWidth; x++)
		{
			upordown =  Random.Range(-1,2);
			
			randomLift[x, 0] = randomLift[x-1,0] + upordown;
			
		}
		
		for (int x = 1; x < worldHeight; x++)
		{
			upordown =  Random.Range(-1,2);
			
			randomLift[0, x] = randomLift[0,x-1] + upordown;
			
		}
		
		for (int x = 1; x < worldWidth ; x++) {
			for (int y = 1; y < worldHeight ; y++) {
				
				do {
					
					upordown = Random.Range(-1,2);
					
					randomLift[x,y] = randomLift[x-1,y] + upordown;
					
					if ((randomLift[x,y]-randomLift[x,y-1] <= 1)&&(randomLift[x,y]-randomLift[x,y-1] >=-1)) {
						
						break;
						
					}
				} while (true);
				
				
			}
			
		}
		
		for(int x = 0; x < worldWidth; x++) 
        {
			//yield return new WaitForSeconds(spawnSpeed);
			
			for(int z = 0; z < worldHeight; z++) 
            {                
				//yield return new WaitForSeconds(spawnSpeed);
				
				//random = new Random();
				
			    if (!(x <= 9 && z <= 9)
                && !(x >= worldWidth - 10 && z >= worldHeight - 10))
                {
                    GameObject block = Network.Instantiate(block1, Vector3.zero, block1.transform.rotation, 0) as GameObject;
                    //block.transform.parent = transform;
                    block.transform.position = new Vector3(x, randomLift[x, z] / 3, z);


                    block.GetComponent<Cube>().xIndex = x;
                    block.GetComponent<Cube>().zIndex = z;
                }			
			}
		}

        //GameObject walle = Network.Instantiate (wall, Vector3.zero, wall.transform.rotation, 0) as GameObject;
        //walle.transform.localPosition = new Vector3 (worldWidth / 2, 0, -1);
        //walle.transform.localScale = new Vector3 (worldWidth+1, 40, 1);

        //GameObject walls = Network.Instantiate (wall, Vector3.zero, wall.transform.rotation, 0) as GameObject;
        //walls.transform.position = new Vector3 (-1, 0, worldHeight/2);
        //walls.transform.networkView.transform.localScale = new Vector3 (1, 40, worldHeight+1);

        //GameObject walln = Network.Instantiate (wall, Vector3.zero, wall.transform.rotation, 0) as GameObject;
        //walln.transform.localPosition = new Vector3 (worldWidth / 2, 0, worldHeight);
        //walln.transform.localScale = new Vector3 (worldWidth+1, 40, 1);

        //GameObject wallw = Network.Instantiate (wall, Vector3.zero, wall.transform.rotation, 0) as GameObject;
        //wallw.transform.localPosition = new Vector3 (worldWidth, 0, worldHeight/2);
        //wallw.transform.localScale = new Vector3 (1, 40, worldHeight+1);

        SpawnBases();
        SpawnWalls();
		timer = 0;
	 
	}

    void SpawnBases()
    {
        // Blue Base
        GameObject Blue_Base = Network.Instantiate(BlueBase, new Vector3(0.7f, baseHeight, 0.7f),
            BlueBase.transform.rotation, 0) as GameObject;

        // Blocks around the base, I'm sorry I did it like this
        SpawnRandWall(new Vector3(-7.25f, stoneHeight, 11.75f));
        SpawnRandWall(new Vector3(-10.35f, stoneHeight, 7.25f));
        SpawnRandWall(new Vector3(-10.35f, stoneHeight, 2.75f));
        SpawnRandWall(new Vector3(-10.35f, stoneHeight, -1.75f));
        SpawnRandWall(new Vector3(-10.35f, stoneHeight, -6.25f));

        SpawnRandWall(new Vector3(11.75f, stoneHeight, -7.25f));
        SpawnRandWall(new Vector3(7.25f, stoneHeight, -10.35f));
        SpawnRandWall(new Vector3(2.75f, stoneHeight, -10.35f));
        SpawnRandWall(new Vector3(-1.75f, stoneHeight, -10.35f));
        SpawnRandWall(new Vector3(-6.25f, stoneHeight, -10.35f));

        // Red Base
        GameObject Red_Base = Network.Instantiate(RedBase,
            new Vector3(worldWidth - 1.7f, baseHeight, worldHeight - 1.7f),
            RedBase.transform.rotation, 0) as GameObject;

        // Blocks around the base
        SpawnRandWall(new Vector3(worldWidth + 6.25f, stoneHeight, worldHeight - 12.75f));
        SpawnRandWall(new Vector3(worldWidth + 9.35f, stoneHeight, worldHeight - 8.25f));
        SpawnRandWall(new Vector3(worldWidth + 9.35f, stoneHeight, worldHeight - 3.75f));
        SpawnRandWall(new Vector3(worldWidth + 9.35f, stoneHeight, worldHeight + 0.75f));
        SpawnRandWall(new Vector3(worldWidth + 9.35f, stoneHeight, worldHeight + 5.25f));

        SpawnRandWall(new Vector3(worldWidth - 12.75f, stoneHeight, worldHeight + 6.25f));
        SpawnRandWall(new Vector3(worldWidth - 8.25f, stoneHeight, worldHeight + 9.35f));
        SpawnRandWall(new Vector3(worldWidth - 3.75f, stoneHeight, worldHeight + 9.35f));
        SpawnRandWall(new Vector3(worldWidth + 0.75f, stoneHeight, worldHeight + 9.35f));
        SpawnRandWall(new Vector3(worldWidth + 5.25f, stoneHeight, worldHeight + 9.35f));
        //57.25 - 56.25

    }

    void SpawnWalls()
    {
        for (float x = 11.75f; x < worldWidth; x += 4.5f)
        {
            SpawnRandWall(new Vector3(x, stoneHeight, -2.75f));
        }

        for (float x = 12.75f; x < worldWidth; x += 4.5f)
        {
            SpawnRandWall(new Vector3(worldWidth - x, stoneHeight, worldHeight + 1.75f));
        }

        for (float z = 11.75f; z < worldHeight; z += 4.5f)
        {
            SpawnRandWall(new Vector3(-2.75f, stoneHeight, z));
        }

        for (float z = 12.75f; z < worldHeight; z += 4.5f)
        {
            SpawnRandWall(new Vector3(worldWidth + 1.75f, stoneHeight, worldHeight - z));
        }
		spawnTurrents();
    }

    void SpawnRandWall(Vector3 _position)
    {
        GameObject stone;
        Quaternion shapeRot;
        int randRot = Random.Range(0, 4);
        int randShape = Random.Range(0, 3);



        switch (randRot)
        {
            default:
            case 0:
                shapeRot = Quaternion.Euler(0, 0, 0);
                break;

            case 1:
                shapeRot = Quaternion.Euler(0, 90, 0);
                break;

            case 2:
                shapeRot = Quaternion.Euler(0, 180, 0);
                break;

            case 3:
                shapeRot = Quaternion.Euler(0, 270, 0);
                break;
        }



        switch (randShape)
        {
            default:
            case 0:
                stone = Network.Instantiate(StoneWall1, _position,
                    shapeRot, 0) as GameObject;
                break;

		
            case 1:
                stone = Network.Instantiate(StoneWall2, _position,
                    shapeRot, 0) as GameObject;
                break;

            case 2:
                stone = Network.Instantiate(StoneWall3, _position,
                    shapeRot, 0) as GameObject;
                break;
        }


    }

void spawnTurrents() {
		Debug.Log("spawning turret");
		GameObject standblue1 = Network.Instantiate(standblue, new Vector3 (7,1.5f,7),
		                                             BlueBase.transform.rotation, 0) as GameObject;

		GameObject standRed1 = Network.Instantiate(standred,  new Vector3 (worldWidth -8.0f,1.5f,worldHeight -8.0f), 
		                                           BlueBase.transform.rotation, 0) as GameObject;
		//new Vector3 (42,1.5f,42),
		GameObject turretBlue1 = Network.Instantiate(turretBlue, new Vector3 (7,3,7),
		                            BlueBase.transform.rotation, 0) as GameObject;
		GameObject turretRed1 = Network.Instantiate(turretRed, new Vector3 (worldWidth -8.0f,3.0f,worldHeight -8.0f),
		                                             BlueBase.transform.rotation, 0) as GameObject;
		//new Vector3 (42,3,42)
		GameObject bluec = Network.Instantiate(Bluecross, new Vector3 (worldWidth -40f,7.0f,worldHeight -8.0f),
		                                            BlueBase.transform.rotation, 0) as GameObject;
		GameObject redc = Network.Instantiate(redcross, new Vector3 (worldWidth -5f,7.0f,worldHeight -40.0f),
		                                      BlueBase.transform.rotation, 0) as GameObject;
		GameObject blueh = Network.Instantiate(bluehit, new Vector3 (worldWidth -40f,3.0f,worldHeight -8.0f),
		                                      BlueBase.transform.rotation, 0) as GameObject;
		GameObject redh = Network.Instantiate(redhit, new Vector3 (worldWidth -5f,3.0f,worldHeight -40.0f),
		                                       BlueBase.transform.rotation, 0) as GameObject;


}
public void respawn1m(){
		GameObject playerObj = Network.Instantiate(Team1male, new Vector3(44f, 5f, 42f), Quaternion.Euler(0, 90, 0), 0) as GameObject;
		//  playerObj.networkView.RPC("SetUsername", RPCMode.AllBuffered, networkmanager.advancedSettings.username);
		Debug.Log("boy");
		for (int i = 0; i < 50; i++) {
			Debug.Log("printing out this shit 40 times");
		}
		pd = Team1male.GetComponent<playerData>();
		pd.isboypd = true;
	}
public	void respawn1f(){
		for (int i = 0; i < 50; i++) {
			Debug.Log("printing out this shit 40 times");
		}
	GameObject playerObj = Network.Instantiate(Team1Female, new Vector3(42f, 5f, 42f), Quaternion.Euler(0, 90, 0), 0) as GameObject;
	//      playerObj.networkView.RPC("SetUsername", RPCMode.AllBuffered, networkmanager.advancedSettings.username);
	
	
	Debug.Log("girl");
	pd = Team1Female.GetComponent<playerData>();
	pd.isgirlpd = true;
	}
}