using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour                             
{
	public Texture2D[] healthBar = new Texture2D[21];
	public Texture2D[] weaponBar = new Texture2D[5];
	public Texture2D crossHar;
    

	void Update () 
	{
		//GameObject hBar = GameObject.Find("HealthBar");
		//hBar.guiTexture.texture = healthBar[(int)(HUDTest.health / 5.0f)];

		//hBar.guiTexture.

		GameObject wBar = GameObject.Find("WeaponBar");
		wBar.guiTexture.texture = weaponBar[HUDTest.wep - 1];

        
		GameObject cHar = GameObject.Find ("Crosshair");
		if (HUDTest.mapActive)
			cHar.guiTexture.texture = null;
		else
			cHar.guiTexture.texture = crossHar;

        //green.transform.Translate



	}

}



//	float barDisplay; //current progress
//	Vector2 barPos = new Vector2(0.67f, 0.02f);
//	Vector2 barSize = new Vector2(60,20);
//
//	public Texture2D emptyTex;
//	public Texture2D fullTex;
//
//	void OnGUI() 
//	{
//		//draw the background:
//		GUI.BeginGroup(new Rect(0.67f, 0.02f, 600.0f, 200.0f));
//		GUI.Box(new Rect(0,0, 600.0f, 200.0f), emptyTex);
//		       
//
//		//draw the filled-in part:
//		GUI.BeginGroup(new Rect(0, 0, 600.0f * barDisplay, 200.0f));
//		GUI.Box(new Rect(0,0, 600.0f, 200.0f), fullTex);
//
//		GUI.EndGroup();
//		GUI.EndGroup();
//	}
//
//	void Update() 
//	{
//		//for this example, the bar display is linked to the current time,
//		//however you would set this value based on your desired display
//		//eg, the loading progress, the player's health, or whatever.
//		barDisplay = Time.time * 0.05f;
//	    
//		// barDisplay = MyControlScript.staticHealth;
//	}