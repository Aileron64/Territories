using UnityEngine;
using System.Collections;

public class MapButton : MonoBehaviour 
{
	public Texture2D[] baseButton = new Texture2D[3];

	Color normal;

	public int button_index = 0;

	void Start()
	{
		normal = guiTexture.color;
	}

	void Update()
	{

	}

	void OnMouseEnter()
	{
		guiTexture.color = new Color (0.5f, 0.5f, 0.5f);
	}
	
	void OnMouseExit()
	{
		guiTexture.color = normal;
	}
	
	void OnMouseDown()
	{
		guiTexture.color = new Color (0.3f, 0.3f, 0.3f);
	}
	
	void OnMouseUp()
	{
		guiTexture.color = normal;	
	}
	
	
}
