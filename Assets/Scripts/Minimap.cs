using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Minimap : MonoBehaviour
{
    public GameObject miniBlock;
    private GameObject miniArrow;

    public Texture white_square;
    public Texture red_square;
    public Texture blue_square;
    public Texture empty_square;
    public Texture blank;

    public int blockSize = 10;
    public int xIndent = 0;
    public int yIndent = 0;
    int redScore = 0;
    int blueScore = 0;

    const int size = 25;

    private int xPos;
    private int yPos;

    private GameObject[,] mini = new GameObject[size, size];

    GameObject player;

    void Start()
    {
        player = GridState.player;

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if ((!(i == 0 && j == 0))
                && !(i == 0 && j == size - 1)
                && !(i == size - 1 && j == size - 1)
                && !(i == size - 1 && j == 0))
                {
                    mini[i, j] = Instantiate(miniBlock,
                    new Vector3(
                        (blockSize * (size / 2 * -1)) + (i * blockSize) + xIndent,
                        (blockSize * (size / 2 * -1)) + (j * blockSize) + yIndent,
                        0)
                        + transform.position,
                        transform.rotation) as GameObject;

                    mini[i, j].transform.localScale.Scale(new Vector3(blockSize, blockSize, blockSize));
                    mini[i, j].GetComponent<MapSprite>().x = i;
                    mini[i, j].GetComponent<MapSprite>().y = j;
                    mini[i, j].transform.SetParent(transform);
                }
            }

        }

        miniArrow = transform.FindChild("MiniArrow").gameObject;
        miniArrow.transform.SetAsLastSibling();
        miniArrow.transform.position = (transform.position + new Vector3(xIndent, yIndent, 0));

    }

    void Update()
    {
        xPos = (int)player.transform.position.x; // +GridManager.mapWidth / 2;
        yPos = (int)player.transform.position.z; // +GridManager.mapHeight / 2;

        miniArrow.transform.rotation = new Quaternion(0, 0, player.transform.rotation.y * -1,
            player.transform.rotation.w);


        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if ((!(i == 0 && j == 0))
                && !(i == 0 && j == size - 1)
                && !(i == size - 1 && j == size - 1)
                && !(i == size - 1 && j == 0))
                {
                    mini[i, j].GetComponent<MapSprite>().x = xPos - (size - 1) / 2 + i;
                    mini[i, j].GetComponent<MapSprite>().y = yPos - (size - 1) / 2 + j;
                }

            }
        }
    }
}