using UnityEngine;
using System.Collections;

public class MapSprite : MonoBehaviour
{
    public Texture white_square;
    public Texture red_square;
    public Texture blue_square;
    public Texture empty_square;
    public Texture blank;

    public bool isMini;
    public int value;
    public int x;
    public int y;


    void Update()
    {
        if (isMini || GridManager.mapOpen)
        {
            if (x < GridManager.mapWidth && y < GridManager.mapHeight && x >= 0 && y >= 0)
            {
                value = GridState.gridState[x, y];

                if (value == 1)
                    GetComponent<UnityEngine.UI.RawImage>().texture = blue_square;
                else if (value == 2)
                    GetComponent<UnityEngine.UI.RawImage>().texture = red_square;
                else
                    GetComponent<UnityEngine.UI.RawImage>().texture = white_square;


            }
            else
                GetComponent<UnityEngine.UI.RawImage>().texture = empty_square;
        }
        else
            GetComponent<UnityEngine.UI.RawImage>().texture = blank;
    }
}
