using UnityEngine;
using System.Collections;

public class MapUI : MonoBehaviour 
{
	public static int xSelect = 0;
	public static int ySelect = 0;
	public static bool selected = false;

	public GUITexture tile;
	public GUITexture emptyTexture;

	public Texture2D[] tiles = new Texture2D[9];
	public Texture2D emptyTile;
	public Texture2D green;
	public Texture2D border;

	public float mapX = 0.3f;
	public float mapY = 0.2f;
	public int mapSize = 50;

	int xText = 0;
	int yText = 0;

	void Start()
	{
		for (int i = 0; i < 100; i++) 
		{
			for (int j = 0; j < 100; j++) 
			{
				tile.GetComponent<MapTile>().x = j;
				tile.GetComponent<MapTile>().y = i;
				tile.GetComponent<MapTile>().size = mapSize;

				GameObject clone;
				clone = Instantiate(tile, new Vector3(mapX, mapY, 0.0f), new Quaternion()) as GameObject;
			}
		}
	}





	void Update () 
	{

		GameObject player = GameObject.Find("Map_Player");
		if (HUDTest.mapActive)
		{
			player.guiTexture.texture = green;
			player.transform.position = new Vector3 ( mapX, mapY, 1.0f);
			player.guiTexture.pixelInset = new Rect (
				mapSize / 2 + mapSize * (HUDTest.locX - 2), mapSize / 2 + mapSize * (HUDTest.locY - 93), mapSize * 2, mapSize * 2);
		} 
		else
			player.guiTexture.texture = null;


		GUITexture _border = GameObject.Find("Selected").guiTexture;
		if (HUDTest.mapActive && selected) 
		{
				_border.texture = border;
				_border.transform.position = new Vector3 (mapX, mapY, 1.0f);
				_border.pixelInset = new Rect (
				mapSize * ySelect - 2, mapSize * (8 - xSelect) - 2, mapSize + 4, mapSize + 4);
		}
		else
			_border.guiTexture.texture = null;


		GUIText mapData = GameObject.Find ("TileInfo").guiText;
		if (selected) 
		{
			xText = xSelect;
			yText = ySelect;
		}
		else
		{
			xText = 100 - HUDTest.locY;
			yText = HUDTest.locX - 1;
		}

		string status = ":(";
		
		switch(HUDTest.map[xText, yText])
		{
			//default:
		case 0:
			status = "Empty";
			break;
		case 1:
			status = "Blue Territory";
			break;
		case 2:
			status = "Red Territory";
			break;
        //case 3:
        //    status = "Blue Base";
        //    break;
        //case 4:
        //    status = "Red Base";
        //    break;
        //case 5:
        //    status = "Blue Outpost";
        //    break;
        //case 6:
        //    status = "Red Outpost";
        //    break;
        //case 7:
        //    status = "Blue Factory";
        //    break;
        //case 8:
        //    status = "Red Facroty";
        //    break;
		}
		
		
		mapData.text = string.Format ("({0}, {1})   {2}", xText, yText, status);


		for (int i = -2; i <= 2; i++)
		{
			for (int j = -2; j <= 2; j++)
			{
				if(Mathf.Abs(i) != 2 || Mathf.Abs(j) != 2)
				{
					GameObject tile = GameObject.Find("Mini(" + j + ", " + i + ")");

					int x = 100 - HUDTest.locY - i;
					int y = HUDTest.locX - 1 + j;

					if ( x <= 99 && x >= 0 && y <= 99 && y >= 0)
						tile.guiTexture.texture = tiles[HUDTest.map[x, y]];
					else
						tile.guiTexture.texture = emptyTile;

					//tile.guiTexture.texture = tiles[2];
				}
			}
		}
	}
}
