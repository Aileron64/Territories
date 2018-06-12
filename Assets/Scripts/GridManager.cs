using UnityEngine;
using System.Collections;


public class GridManager : MonoBehaviour
{
    public static int mapHeight = 50;
    public static int mapWidth = 50;
    public float creepPower = 10;

    bool k = false;
    bool keyDown = false;

    // Blue = 50 - 100, Red = -50 - -100
    public static float[,] grid = new float[mapWidth, mapHeight];


    public static int xPos = 0;
    public static int yPos = 0;

    public static bool mapOpen = false;
    public static bool gameStart = false;


    //public static int redScore = 0;
    //public static int blueScore = 0;

    bool switcharoo = true;

    void Start()
    {
        for (int i = 0; i < mapWidth; i++)
        {
            for (int j = 0; j < mapHeight; j++)
            {
                int rand = Random.Range(0, 40);
            }
        }

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                grid[i, j] = 100;

                grid[mapWidth - (1 + i), mapHeight - (1 + j)] = -100;
            }
        }
    }

    void Update()
    {
        //networkView.RPC("UpdateScore", RPCMode.AllBuffered);
        //networkView.RPC("Creep", RPCMode.AllBuffered);
        //UpdateScore();
        //Creep();


        if (Network.isServer && gameStart)
        {
            //UpdateScore();
            Creep();
        }

        /// Input? 


        if (Input.GetKey(KeyCode.M))  //// Map
        {
            if (!keyDown)
            {
                mapOpen = !mapOpen;
            }

            k = false;
        }



        if (k)
            keyDown = false;
        else
            keyDown = true;

        k = true;

    }



    [RPC]
    void Creep()
    {
        if (switcharoo)
        {
            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {

                    if (i != 0)
                    {   // Left Influence
                        grid[i, j] += creepPower * grid[i - 1, j] / 100 * Time.deltaTime;
                    }

                    if (i != mapWidth - 1)
                    {   // Right Influence
                        grid[i, j] += creepPower * grid[i + 1, j] / 100 * Time.deltaTime;
                    }

                    if (j != 0)
                    {   // Top Influence
                        grid[i, j] += creepPower * grid[i, j - 1] / 100 * Time.deltaTime;
                    }

                    if (j != mapHeight - 1)
                    {   // Bottom Influence
                        grid[i, j] += creepPower * grid[i, j + 1] / 100 * Time.deltaTime;
                    }

                    // Limit -100 to 100
                    if (grid[i, j] > 100)
                        grid[i, j] = 100;
                    else if (grid[i, j] < -100)
                        grid[i, j] = -100;
                }
            }


        }
        else
        {
            for (int i = mapWidth - 1; i >= 0; i--)
            {
                for (int j = mapHeight - 1; j >= 0; j--)
                {

                    if (i != 0)
                    {   // Left Influence
                        grid[i, j] += creepPower * grid[i - 1, j] / 100 * Time.deltaTime;
                    }

                    if (i != mapWidth - 1)
                    {   // Right Influence
                        grid[i, j] += creepPower * grid[i + 1, j] / 100 * Time.deltaTime;
                    }

                    if (j != 0)
                    {   // Top Influence
                        grid[i, j] += creepPower * grid[i, j - 1] / 100 * Time.deltaTime;
                    }

                    if (j != mapHeight - 1)
                    {   // Bottom Influence
                        grid[i, j] += creepPower * grid[i, j + 1] / 100 * Time.deltaTime;
                    }

                    // Limit -100 to 100
                    if (grid[i, j] > 100)
                        grid[i, j] = 100;
                    else if (grid[i, j] < -100)
                        grid[i, j] = -100;
                }
            }
        }

        switcharoo = !switcharoo;
    }
}
