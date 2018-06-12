using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class GridState : MonoBehaviour 
{

    public static int[,] gridState = new int[GridManager.mapWidth, GridManager.mapHeight];

    public static int redScore = 0;
    public static int blueScore = 0;

    public static GameObject player;

    Text blueText;
    Text redText;

    bool k = false;
    bool keyDown = false;

    int x = 0;
    int y = 0;

    //public int[] gridCheck = new int[50];

	void Start () 
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                gridState[i, j] = 1;
                gridState[GridManager.mapWidth - (1 + i), GridManager.mapHeight - (1 + j)] = 2;
            }
        }
	}
	

	void Update () 
    {
        int tmpRedScore = 0;
        int tmpBlueScore = 0;

        for (int i = 0; i < GridManager.mapWidth; i++)
        {
            for (int j = 0; j < GridManager.mapHeight; j++)
            {
                //if (grid[i, j] >= 50)
                //    tmpBlueScore++;
                //else if (grid[i, j] <= -50)
                //    tmpRedScore++;


                if (gridState[i, j] == 1)
                    tmpBlueScore++;
                else if (gridState[i, j] == 2)
                    tmpRedScore++;

            }

            //gridCheck[i] = gridState[i, 0];
        }

        redScore = tmpRedScore;
        blueScore = tmpBlueScore;

        if (GameObject.Find("Blue_Score"))
        {
            Text blueText = GameObject.Find("Blue_Score").GetComponent<Text>();
            blueText.text = string.Format("{0}", blueScore);
        }

        if (GameObject.Find("Red_Score"))
        {
            Text redText = GameObject.Find("Red_Score").GetComponent<Text>();
            redText.text = string.Format("{0}", redScore);
        }

        // Debuging

        //if (Input.GetKey(KeyCode.X))  //// Map
        //{
        //    if (!keyDown)
        //    {
        //        x++;
        //    }

        //    k = false;
        //}

        //if (Input.GetKey(KeyCode.Y))  //// Map
        //{
        //    if (!keyDown)
        //    {
        //        y++;
        //    }

        //    k = false;
        //}

        //if (k)
        //    keyDown = false;
        //else
        //    keyDown = true;

        //k = true;




        //if (GameObject.Find("Debug"))
        //{
        //    Text debug_text = GameObject.Find("Debug").GetComponent<Text>();
        //    debug_text.text = string.Format("({0},{1}) = {2}", x, y, gridState[x,y]);
        //}

	}
}
