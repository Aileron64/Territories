using UnityEngine;
using System.Collections;

public class MapImage : MonoBehaviour 
{
    public Sprite mainImage;
    public Sprite blank;

    void Update()
    {
        if (GridManager.mapOpen)
        {
            GetComponent<UnityEngine.UI.Image>().sprite = mainImage;
            //GetComponent<UnityEngine.UI.RawImage>().texture = green_arrow;
        }
        else
        {
            GetComponent<UnityEngine.UI.Image>().sprite = blank;
            //GetComponent<UnityEngine.UI.Sprite>().texture = blank;
            
        }
            
    }
}
