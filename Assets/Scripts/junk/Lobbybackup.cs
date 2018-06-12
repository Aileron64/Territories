using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Lobbybackup : MonoBehaviour 
{
    EventSystem eventSystem;
    GameObject startButton;
    GameObject createWorldButton;
    GameObject[] redTeam = new GameObject[4];
    GameObject[] blueTeam = new GameObject[4];
	public GameObject Team1male;
	public GameObject Team1Female;
	public GameObject Team2male;
	public GameObject Team2Female;
	bool isclick = false;
    public GameObject boyButton;
    public GameObject girlButton;


    int index = 0;
    int slot = 0;
    bool genderButtons = false;
	bool isBoy1= false;
	bool isGirl1= false;
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



        redTeam[0] = transform.FindChild("Red_Slot_1").gameObject;
        redTeam[0].GetComponent<Button>().onClick.AddListener(() => { Red1(); });

        redTeam[1] = transform.FindChild("Red_Slot_2").gameObject;
        redTeam[1].GetComponent<Button>().onClick.AddListener(() => { Red2(); });

        redTeam[2] = transform.FindChild("Red_Slot_3").gameObject;
        redTeam[2].GetComponent<Button>().onClick.AddListener(() => { Red3(); });

        redTeam[3] = transform.FindChild("Red_Slot_4").gameObject;
        redTeam[3].GetComponent<Button>().onClick.AddListener(() => { Red4(); });




        blueTeam[0] = transform.FindChild("Blue_Slot_1").gameObject;
        blueTeam[0].GetComponent<Button>().onClick.AddListener(() => { Blue1(); });

        blueTeam[1] = transform.FindChild("Blue_Slot_2").gameObject;
        blueTeam[1].GetComponent<Button>().onClick.AddListener(() => { Blue2(); });

        blueTeam[2] = transform.FindChild("Blue_Slot_3").gameObject;
        blueTeam[2].GetComponent<Button>().onClick.AddListener(() => { Blue3(); });

        blueTeam[3] = transform.FindChild("Blue_Slot_4").gameObject;
        blueTeam[3].GetComponent<Button>().onClick.AddListener(() => { Blue4(); });







	}

    void Update()
    {
        if (timer >= 0)
            timer += Time.deltaTime;

        if (timer >= timer_length)
        {
            Debug.Log("Timer n Stuff, Good to go");
            timer_lock = false;
        }
    }
    // Method for each button

	[RPC]
    void CreateWorldButton()
    {
        if (Network.isServer)
        {
			if(unlock == false)
			{
            CreateWorld();
				unlock = true;
			}
            timer = 0;
            Debug.Log("MAKIN THE WORLD, BRB 30 SEC");
        }
    }

	[RPC]
    void StartButton()
    {
		timer = 0;
        if (!timer_lock)
        {
            this.DestroyButtons();

            gamemanager.StartGame();

            networkmanager.destroylobby();


            Screen.lockCursor = true;
            Screen.showCursor = false;

            if ((index >= 1 && index < 5) && isclick)
            {

                Debug.Log("HERE WE GO!");
                Debug.Log("index is " + index);
                if (isBoy1)
                {
                    GameObject playerObj = Network.Instantiate(Team1male, new Vector3(0f, 5f, 0f), Quaternion.Euler(0, 90, 0), 0) as GameObject;
                    playerObj.networkView.RPC("SetUsername", RPCMode.AllBuffered, networkmanager.advancedSettings.username);
                    Debug.Log("boy");

                }
                else if (isGirl1)
                {
                    GameObject playerObj = Network.Instantiate(Team1Female, new Vector3(0f, 5f, 0f), Quaternion.Euler(0, 90, 0), 0) as GameObject;
                    playerObj.networkView.RPC("SetUsername", RPCMode.AllBuffered, networkmanager.advancedSettings.username);
                    Debug.Log("girl");
                }
            }
            if ((index >= 5 && index < 9) && isclick)
            {

                Debug.Log("HERE WE GO!");
                Debug.Log("index is " + index);
                if (isBoy1)
                {
                    GameObject playerObj = Network.Instantiate(Team2male, new Vector3(25f, 5f, 25f), Quaternion.Euler(0, 90, 0), 0) as GameObject;
                    playerObj.networkView.RPC("SetUsername", RPCMode.AllBuffered, networkmanager.advancedSettings.username);
                    Debug.Log("boy");

                }
                else if (isGirl1)
                {
                    GameObject playerObj = Network.Instantiate(Team2Female, new Vector3(25f, 5f, 25f), Quaternion.Euler(0, 90, 0), 0) as GameObject;
                    playerObj.networkView.RPC("SetUsername", RPCMode.AllBuffered, networkmanager.advancedSettings.username);
                    Debug.Log("girl");
                }
            }
        
        }

	}
    
	   
	[RPC]
    void Red1()
    {
	    Text boxText;
        boxText = redTeam[0].transform.FindChild("Text").GetComponent<Text>();

        if(boxText.text != "Empty Slot")
        {
            index = 1;
                networkView.RPC ("SpawnButtons", RPCMode.AllBuffered,new object[] {-200,50});  //SpawnButtons(-200, 50); 
            //buffered all becuase you want it to tranfer to everyone and to remember it.)

            Debug.Log("CLICKED RED BUTTON 1"); 
        }        
    }

	[RPC]
    void Red2()
    {
        Text boxText;
        boxText = redTeam[1].transform.FindChild("Text").GetComponent<Text>();

        if(boxText.text != "Empty Slot")
        {
            index = 2;
    		networkView.RPC ("SpawnButtons", RPCMode.AllBuffered,new object[] {-200,0});
         //   SpawnButtons(-200, 0);
            Debug.Log("CLICKED RED BUTTON 2");
        }
    }

	[RPC]
    void Red3()
    {
        Text boxText;
        boxText = redTeam[2].transform.FindChild("Text").GetComponent<Text>();

        if(boxText.text != "Empty Slot")
        {
            index = 3;
            networkView.RPC ("SpawnButtons", RPCMode.AllBuffered,-200,-50);
        //    SpawnButtons(-200, -50);
            Debug.Log("CLICKED RED BUTTON 3");
        }
    }

	[RPC]
    void Red4()
    {
        Text boxText;
        boxText = redTeam[3].transform.FindChild("Text").GetComponent<Text>();

		if(boxText.text != "Empty Slot")
        {
            index = 4;
            networkView.RPC ("SpawnButtons", RPCMode.AllBuffered,-200,-100);
          //  SpawnButtons(-200, -100);
            Debug.Log("CLICKED RED BUTTON 4");
        }


    }


	[RPC]
    void Blue1()
    {
        Text boxText;
        boxText = blueTeam[0].transform.FindChild("Text").GetComponent<Text>();

        if(boxText.text != "Empty Slot")
        {
            index = 5;
            networkView.RPC ("SpawnButtons", RPCMode.AllBuffered,200,50);
        //    SpawnButtons(200, 50);
            Debug.Log("CLICKED BLUE BUTTON 1");
        }

    }


	[RPC]
    void Blue2()
    {
        Text boxText;
        boxText = blueTeam[1].transform.FindChild("Text").GetComponent<Text>();

        if(boxText.text != "Empty Slot")
        {
            index = 6;
            networkView.RPC ("SpawnButtons", RPCMode.AllBuffered,200,0);
         //   SpawnButtons(200, 0);
            Debug.Log("CLICKED BLUE BUTTON 2");
        }

    }

	[RPC]
    void Blue3()
    {
        Text boxText;
        boxText = blueTeam[2].transform.FindChild("Text").GetComponent<Text>();

        if(boxText.text != "Empty Slot")
        {
            index = 7;
            networkView.RPC ("SpawnButtons", RPCMode.AllBuffered,200,-50);
        //    SpawnButtons(200, -50);
            Debug.Log("CLICKED BLUE BUTTON 3");  
        }


    }
	[RPC]
    void Blue4()
    {
        Text boxText;
        boxText = blueTeam[2].transform.FindChild("Text").GetComponent<Text>();

        if(boxText.text != "Empty Slot")
        {
            index = 8;
            networkView.RPC ("SpawnButtons", RPCMode.AllBuffered,200,-100);
          //  SpawnButtons(200, -100);
            Debug.Log("CLICKED BLUE BUTTON 4");
        }

    }



	[RPC]
    // Creates Boy/Girl Buttons on top of button
    void SpawnButtons(int x, int y)
    {
		if(genderButtons)
		{
		networkView.RPC("DestroyButtons",RPCMode.All);
		}
	//	DestroyButtons();
        GameObject boy = null;
        GameObject girl = null;

        boy = Network.Instantiate(boyButton, Vector3.zero, Quaternion.identity,0) as GameObject;

        boy.transform.parent = transform;
        boy.GetComponent<RectTransform>().anchoredPosition = new Vector2(x - 40, y);
        boy.GetComponent<Button>().onClick.AddListener(() => { BoyButton(); });

        girl = Network.Instantiate(girlButton, Vector3.zero, Quaternion.identity,0) as GameObject;

        girl.transform.parent = transform;
        girl.GetComponent<RectTransform>().anchoredPosition = new Vector2(x + 40, y);
        girl.GetComponent<Button>().onClick.AddListener(() => { GirlButton(); });

        genderButtons = true;
    }
	[RPC]
    // Gets rid of Boy/Girl buttons
    void DestroyButtons()
    {
        if(genderButtons)
        {
            GameObject aboutToDie = transform.FindChild("Boy_Button(Clone)").gameObject;
			Network.Destroy(aboutToDie);
			//Destroy(aboutToDie);


            GameObject aboutToDie2 = transform.FindChild("Girl_Button(Clone)").gameObject;
			Network.Destroy(aboutToDie2);
				//Destroy(aboutToDie2);


            // Boy_Button(Clone)

            Debug.Log("#%!@ your buttons");

            genderButtons = false;
        }
    }

	[RPC]
    void BoyButton()
    {
        Debug.Log("CLICKED BOY BUTTON");
		networkView.RPC ("AddPlayer", RPCMode.All,true);  //buffered again so late joiner with see it
   //     AddPlayer(true);

    }
	[RPC]
    void GirlButton()
    {
        Debug.Log("CLICKED GIRL BUTT");
		networkView.RPC ("AddPlayer", RPCMode.All,false);
     //   AddPlayer(false);

    }

	[RPC]
    void AddPlayer(bool isBoy)
    {
        Text boxText;

        // Clear name from previous slot
        switch (slot)
        {
            default:
                break;

            case 1: 
            case 2:
            case 3:
            case 4:
		 
                boxText = redTeam[slot - 1].transform.FindChild("Text").GetComponent<Text>();
                boxText.text = "Empty Slot";
		 
                break;

            case 5:
            case 6:
            case 7:
            case 8:
		 
		 
                boxText = blueTeam[slot - 5].transform.FindChild("Text").GetComponent<Text>();
                boxText.text = "Empty Slot";
			 
                break;
        }
		//networkView.RPC ("SpawnButtons", RPCMode.AllBuffered,200,-100);
	 
        slot = index;

        // Name for new slot
        switch(index)
			 
        {      
            default:
                break;

		case 1: 
            case 2:
            case 3:
            case 4:             
                boxText = redTeam[index - 1].transform.FindChild("Text").GetComponent<Text>();


                if (isBoy)
			{
				isclick = true;
                    boxText.text = "Player (Boy)";
				isBoy1 = true;

			}
                else
			{
                    boxText.text = "Player  (Girl)";
				isclick = true;
				isGirl1 = true;

			}
                break;

            case 5:
            case 6:
            case 7:
            case 8:
                boxText = blueTeam[index - 5].transform.FindChild("Text").GetComponent<Text>();

			if (isBoy)
			{
				isclick = true;
				boxText.text = "Player  (Boy)";
				isBoy1 = true;
				
			}
			else
			{
				boxText.text = "Player  (Girl)";
				isclick = true;
				isGirl1 = true;
				
			}
                break;
        }

		if(genderButtons)
		{
		networkView.RPC("DestroyButtons",RPCMode.All);
		}
	//	DestroyButtons();

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
				
			    if (!(x <=10 && z <=10)
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
	}



    void SpawnBases()
    {
        // Blue Base
        GameObject Blue_Base = Network.Instantiate(BlueBase, new Vector3(1.7f, -0.3f, 1.7f),
            BlueBase.transform.rotation, 0) as GameObject;

        // Blocks around the base, I'm sorry I did it like this
        SpawnRandWall(new Vector3(-7.25f, stoneHeight, 12.75f));
        SpawnRandWall(new Vector3(-9.35f, stoneHeight, 8.25f));
        SpawnRandWall(new Vector3(-9.35f, stoneHeight, 3.75f));
        SpawnRandWall(new Vector3(-9.35f, stoneHeight, -0.75f));
        SpawnRandWall(new Vector3(-9.35f, stoneHeight, -5.25f));

        SpawnRandWall(new Vector3(12.75f, stoneHeight, -7.25f));
        SpawnRandWall(new Vector3(8.25f, stoneHeight, -9.35f));
        SpawnRandWall(new Vector3(3.75f, stoneHeight, -9.35f));
        SpawnRandWall(new Vector3(-0.75f, stoneHeight, -9.35f));
        SpawnRandWall(new Vector3(-5.25f, stoneHeight, -9.35f));

        // Red Base
        GameObject Red_Base = Network.Instantiate(RedBase,
            new Vector3(worldWidth - 1.7f, -0.3f, worldHeight - 1.7f),
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
        for (float x = 12.75f; x < worldWidth; x += 4.5f)
        {
            SpawnRandWall(new Vector3(x, stoneHeight, -2.75f));
        }

        for (float x = 12.75f; x < worldWidth; x += 4.5f)
        {
            SpawnRandWall(new Vector3(worldWidth - x, stoneHeight, worldHeight + 1.75f));
        }

        for (float z = 12.75f; z < worldHeight; z += 4.5f)
        {
            SpawnRandWall(new Vector3(-2.75f, stoneHeight, z));
        }

        for (float z = 12.75f; z < worldHeight; z += 4.5f)
        {
            SpawnRandWall(new Vector3(worldWidth + 1.75f, stoneHeight, worldHeight - z));
        }
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
}
