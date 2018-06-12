using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public enum CubeState
{
    WHITE = 0,
    BLUE = 1,
    RED = 2
}

public class Cube : MonoBehaviour
{

    public int xIndex;
    public int zIndex;
    public float value;
    public CubeState state;

    void Start()
    {
        xIndex = (int)transform.position.x;
        zIndex = (int)transform.position.z;
        state = CubeState.WHITE;
    }

    void Update()
    {
        if (xIndex <= GridManager.mapWidth && zIndex <= GridManager.mapHeight)
        {
            //GridState.gridState[xIndex, zIndex] = (int)state;

            if (Network.isServer)
            {
                value = GridManager.grid[xIndex, zIndex];


                switch (state)
                {
                    default:
                    case CubeState.WHITE:
                        if (value >= 50)
                        {
                            networkView.RPC("Blue", RPCMode.AllBuffered, xIndex, zIndex);
                        }
                        else if (value <= -50)
                        {
                            networkView.RPC("Red", RPCMode.AllBuffered, xIndex, zIndex);
                        }
                        break;

                    case CubeState.BLUE:
                        if (value < 50 && value > -50)
                        {
                            networkView.RPC("White", RPCMode.AllBuffered, xIndex, zIndex);
                        }
                        else if (value <= -50)
                        {
                            networkView.RPC("Red", RPCMode.AllBuffered, xIndex, zIndex);
                        }
                        break;

                    case CubeState.RED:
                        if (value < 50 && value > -50)
                        {
                            networkView.RPC("White", RPCMode.AllBuffered, xIndex, zIndex);
                        }
                        else if (value >= 50)
                        {
                            networkView.RPC("Blue", RPCMode.AllBuffered, xIndex, zIndex);
                        }

                        break;
                }
            }
        }
    }

    [RPC]
    void Blue(int x, int z)
    {
        state = CubeState.BLUE;
        collider.renderer.material.color = Color.blue;
        GridState.gridState[x, z] = 1;
    }

    [RPC]
    void Red(int x, int z)
    {
        state = CubeState.RED;
        collider.renderer.material.color = Color.red;
        GridState.gridState[x, z] = 2;
    }

    [RPC]
    void White(int x, int z)
    {
        state = CubeState.WHITE;
        collider.renderer.material.color = Color.white;
        GridState.gridState[x, z] = 0;
    }
}
