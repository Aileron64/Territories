using UnityEngine;
using System.Collections;

public class TestPlayer : MonoBehaviour 
{
//	public static float health = 100;
//	public static int wep = 3;
//	
//	public static float locX = 5;
//	public static float locY = 5;

	void Start () 
	{
	
	}


	void Update () 
	{
		//locX = transform.position.x;
		//locY = transform.position.x;

		HUDTest.locX = (int)(transform.position.x);
		HUDTest.locY = (int)(transform.position.z);
	}
}
