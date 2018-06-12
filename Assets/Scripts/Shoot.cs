using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour 
{
	public Rigidbody[] bullet = new Rigidbody[5];
	public static int Ammo;
	public static int maxAmmo = 10;
	public float power = 50;
	public float time_delay = 0.1f;
	float timer;
	
	// Use this for initialization
	void Start () 
	{
		Ammo = 1000;
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer -= Time.deltaTime;

		GameObject aText = GameObject.Find("Ammo_Display");
		aText.guiText.text = "Ammo : " + Ammo;
		
		if (Input.GetKey(KeyCode.Mouse0) && timer <= 0 && Ammo > 0 && !HUDTest.mapActive) 
		{
			Rigidbody clone;
			clone = Instantiate(bullet[HUDTest.wep - 1], transform.position, transform.rotation) as Rigidbody;
			clone.velocity = (Vector3.forward * power);
			Ammo--;
			Debug.Log(Ammo + " Ammo Left");
			timer = time_delay;
		}
	}
}
