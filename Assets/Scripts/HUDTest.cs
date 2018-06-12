using UnityEngine;
using System.Collections;

public class HUDTest : MonoBehaviour 
{
	public static float health = 100;
	public static int wep = 1;

    public static int locX = 50;
    public static int locY = 50;

	public static bool mapActive = false;
	public static bool blueTeam = true;
    bool k = false;
	bool keyDown = false;


    public static int[,] map = new int[100, 100];

    //public static int[,] map = new int[9, 9]
    //{
    //    {0, 0, 0, 0, 2, 2, 2, 2, 2},
    //    {0, 0, 0, 0, 0, 2, 2, 4, 2},
    //    {1, 0, 0, 0, 0, 0, 2, 2, 2},
    //    {1, 1, 0, 0, 0, 0, 2, 2, 2},
    //    {1, 1, 1, 0, 0, 0, 0, 2, 2},
    //    {1, 1, 1, 0, 0, 0, 0, 2, 2},
    //    {1, 1, 1, 1, 0, 0, 0, 0, 2},
    //    {1, 3, 1, 1, 0, 0, 0, 0, 0},
    //    {1, 1, 1, 1, 1, 0, 0, 0, 0}
    //};

	void Start()
	{
		Screen.showCursor = false;
	}


	void Update () 
    {
        if (health > -0)
            health -= 0.2f;
        else
            health = 100;

//		if (Input.GetKey (KeyCode.Mouse0)) 
//		{
//			Debug.Log ("Click");
//		}

        //GameObject player = GameObject.Find("Player");

        





        if (Input.GetKey(KeyCode.UpArrow))  //// Up
        {
            if (!keyDown)
            {
                if (locY < 9)
                    locY++;

                //Debug.Log("x = " + locX + ",  y = " + locY);
            }
            k = false;
        }

        if (Input.GetKey(KeyCode.DownArrow))  //// Down
        {
            if (!keyDown)
            {
                if (locY > 1)
                    locY--;

                //Debug.Log("x = " + locX + ",  y = " + locY);
            }
            k = false;
        }

        //if (Input.GetKey(KeyCode.RightArrow))  //// Right
        //{
        //    if (!keyDown)
        //    {
        //        if (locX < 9)
        //            locX++;

        //        //Debug.Log("x = " + locX + ",  y = " + locY);
        //    }
        //    k = false;
        //}

        //if (Input.GetKey(KeyCode.LeftArrow))  //// Left
        //{
        //    if (!keyDown)
        //    {
        //        if (locX > 1)
        //            locX--;

        //        //Debug.Log("x = " + locX + ",  y = " + locY);
        //    }
        //    k = false;
        //}

        if (Input.GetKey(KeyCode.R))  //// Red
        {
			blueTeam = false;
            k = false;
        }

        if (Input.GetKey(KeyCode.B))  //// Red
        {
			blueTeam = true;
            k = false;
        }

		if (Input.GetKey(KeyCode.M))  //// Map
		{
			if (!keyDown)
			{
				mapActive = !mapActive;
				MapUI.selected = false;
				Screen.showCursor = !Screen.showCursor;
			}
			k = false;
		}

        //if (Input.GetKey(KeyCode.Tab))  //// T
		if (Input.GetAxis("Mouse ScrollWheel") > 0.0)
        {
            if (!keyDown)
            {
                if (wep == 1)
                    wep = 5;
                else
                    wep--;
            }
            k = false;
        }

        //if (Input.GetKey(KeyCode.Q))  //// Y
		if (Input.GetAxis("Mouse ScrollWheel") < 0.0)
        {
            if (!keyDown)
            {
                if (wep == 5)
                    wep = 1;
                else
                    wep++;
            }
            k = false;
        }

        if (k)
            keyDown = false;
        else
            keyDown = true;

        k = true;

	}
}
