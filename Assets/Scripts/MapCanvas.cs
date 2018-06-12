using UnityEngine;
using System.Collections;

public class MapCanvas : MonoBehaviour 
{
    public GameObject block;
    private GameObject PlayerArrow;
    public int blockSize = 10;
    public int mapWidth = 10;
    public int mapHeight = 10;
    public int xIndent = 0;
    public int yIndent = 0;

    void Start()
    {

        for (int i = 0; i < mapWidth; i++)
        {
            for (int j = 0; j < mapHeight; j++)
            {
                GameObject clone;

                clone = Instantiate(block,
                    new Vector3(
                        (blockSize * (mapWidth / 2 * -1)) + (i * blockSize) + xIndent,
                        (blockSize * (mapHeight / 2 * -1)) + (j * blockSize) + yIndent,
                        0)
                        + transform.position,
                    transform.rotation) as GameObject;

                clone.transform.localScale.Scale(new Vector3(blockSize, blockSize, blockSize));
                clone.GetComponent<MapSprite>().x = i;
                clone.GetComponent<MapSprite>().y = j;
                clone.transform.SetParent(transform);
                
            }
        }


        PlayerArrow = transform.FindChild("PlayerArrow").gameObject;
        PlayerArrow.transform.SetAsLastSibling();
    }
	
	// Update is called once per frame
	void Update () 
    {
        GameObject player = GameObject.Find("Player");


        //PlayerArrow.transform.Rotate(new Vector3(0, 0, 5));

        PlayerArrow.transform.rotation = new Quaternion(0, 0, player.transform.rotation.y * -1, player.transform.rotation.w);
        //Debug.Log(PlayerArrow.transform.rotation);

        PlayerArrow.transform.position = ((new Vector3(
            player.transform.position.x, player.transform.position.z, 
            0) * blockSize / 2) 
            + transform.position)
            + new Vector3(xIndent, yIndent, 0);

        //PlayerArrow.transform.Rotat
	}
}
