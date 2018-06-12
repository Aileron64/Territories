using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// Class for each tile on the map (not mini map)
/// reads and alters cords from map data (GUITest atm)
/// 
/// </summary>

public class MapTile : MonoBehaviour 
{
	public Texture2D[] tile = new Texture2D[5];
	public Texture2D[] influBar = new Texture2D[9];
	public GameObject blueBase;
	public GameObject redBase;

	Color normal;

	public int x = 0;
	public int y = 0;
	public int size = 50;
	public int influence = 45;

	int playerLocX = 0;
	int playerLocY = 0;

	float time_delay = 0.5f;
	float timer = 0;

	void Start()
	{

		normal = guiTexture.color;
		guiTexture.pixelInset = new Rect(size * y, size * (8 - x), size, size);

//		if (HUDTest.map [x, y] == 3)
//			Debug.Log ("Blue Base on " + x + ", " + y);
//
//		if (HUDTest.map [x, y] == 4)
//			Debug.Log ("Red Base on " + x + ", " + y);


		switch(HUDTest.map [x, y])
		{
		default:
		case 0:
			break;
		
		case 1:
		case 3:
		case 5:
		case 7:
			influence = 1;
			break;

		case 2:
		case 4:
		case 6:
		case 8:
			influence = 89;
			break;


		}
	
	}

	void Update()
	{
		if (HUDTest.mapActive) 
			guiTexture.texture = tile [HUDTest.map [x, y]];
		else 
			guiTexture.texture = null;






		//// Check if player is on this tile
		playerLocX = 100 - HUDTest.locY;
		playerLocY = HUDTest.locX - 1;

		//// Update influence 
		if(playerLocX == x && playerLocY == y)
		{
			timer -= Time.deltaTime;

			//Debug.Log ("Get off my lawn");
            

			if(HUDTest.blueTeam && influence > 1 && timer <= 0 && HUDTest.map [x, y] < 3)
			{
				influence -= 50;
				timer = time_delay;
			}
			else if (!HUDTest.blueTeam && influence < 89 && timer <= 0 && HUDTest.map [x, y] < 3)
			{
				influence += 50;
				timer = time_delay;
			}
		}

		//// Update tile based on influence
		if (HUDTest.map [x, y] < 3)
		{

			if (influence <= 30)
				HUDTest.map [x, y] = 1;
			else if (influence >= 60)
				HUDTest.map [x, y] = 2;
			else
				HUDTest.map [x, y] = 0;
		}


		//// Update influence bar
		//GUIText mapData = GameObject.Find ("TileInfluence").guiText;
		//GUITexture _influBar = GameObject.Find ("InfluenceBar").guiTexture;

        //if (MapUI.selected && MapUI.xSelect == x && MapUI.ySelect == y)
        //{
        //    mapData.text = string.Format ("{0}", influence);
        //    _influBar.texture = influBar[influence / 10];
        //}
        //else if (!MapUI.selected && playerLocX == x && playerLocY == y)
        //{
        //    mapData.text = string.Format ("{0}", influence);
        //    _influBar.texture = influBar[influence / 10];
        //}
	}




	void OnMouseEnter()
	{
		if (HUDTest.mapActive) 
		{
			guiTexture.color = new Color (0.5f, 0.5f, 0.5f);
		}
	}
	
	void OnMouseExit()
	{
		if (HUDTest.mapActive) 
		{
			guiTexture.color = normal;
		}
	}

	void OnMouseDown()
	{
		if (HUDTest.mapActive) 
		{
			guiTexture.color = new Color (0.3f, 0.3f, 0.3f);


			MapUI.selected = true;
			MapUI.xSelect = x;
			MapUI.ySelect = y;
		}
	}

	void OnMouseUp()
	{
		if (HUDTest.mapActive) 
		{
			guiTexture.color = normal;
		}
	}


}
