using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour 
{

	public Rigidbody Pistolbullet;
	public Rigidbody Assaultbullet;
	public float shootForce = 500;
	public GameObject fireEffect;
	public Transform muzzle;
	private int gun;

	Rigidbody objectTest;
	float timer;

	void Start()
	{
		timer = 0;
		//objectTest = Pistolbullet;
	}
	// Update is called once per frame
	void Update () 
	{
		timer -= Time.deltaTime;
	//	GameObject wweaponSelected1 = GameObject.Find ("weaponSelected");
	//	WeaponSelected weaponSelected = weaponSelected1.GetComponent<weaponSelected>();

		gun = weaponSelected.currentWeapon;

//		if (Input.GetKey (KeyCode.Alpha1)) 
//		{
//			objectTest = Pistolbullet;
//		} 
//		else if (Input.GetKey (KeyCode.Alpha2)) 
//		{
//			objectTest = Assaultbullet;
//		}
		
		if ((Input.GetKey(KeyCode.Mouse0) && timer <= 0)&& gun >=1) 
		{
			Rigidbody clone;
			Instantiate(fireEffect, muzzle.position, muzzle.rotation);
			//Pistolbullet.rigidbody.AddForce (transform.forward * shootForce);	 
			GameObject player = GameObject.Find ("team1female");
		player.animation.Play ("singleShot");	 
			clone = Instantiate (Pistolbullet, muzzle.position + (muzzle.forward * 2)
			                     , muzzle.rotation) as Rigidbody;
			clone.AddForce (transform.forward * shootForce);	 


			Debug.Log ("Click");
			timer = 1;
		}else if ((Input.GetKey(KeyCode.Mouse0) && timer <= 0)&& gun == 0) {
			Rigidbody clone;
			GameObject player1 = GameObject.FindGameObjectWithTag ("Player");
			player1.animation.Play ("singleShot");	
		 
			Instantiate(fireEffect, muzzle.position, muzzle.rotation);
			//Pistolbullet.rigidbody.AddForce (transform.forward * shootForce);	 
			clone = Instantiate (Pistolbullet, muzzle.position + (muzzle.forward * 2)
			                     , muzzle.rotation) as Rigidbody;
			clone.AddForce (transform.forward * shootForce);	 
		}
	}
}