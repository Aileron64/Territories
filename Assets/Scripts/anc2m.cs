using UnityEngine;
using System.Collections;

public class anc2m : MonoBehaviour {
	public bool isdead = false;
	Animator anim2m;
	//	CharacterController cc;
	public float speed = 10f;
	private int gun;
	
	
	// Use this for initialization
	void Awake () {
		
		//		cc = GetComponent<CharacterController>();
		
		anim2m = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		gun = weaponSelected.currentWeapon;
		
		//		if (Input.GetMouseButtonDown(0) && gun >=1) 
		//		{
		//			//		//	Rigidbody clone;
		//			//			Network.Instantiate(fireEffect, muzzle.position, muzzle.rotation,0);
		//			//			//Pistolbullet.rigidbody.AddForce (transform.forward * shootForce);	 
		//			//		 
		//			//			 
		//			//				player.animation.CrossFade ("jump");	 
		//			//
		//			//		 
		//			//		GameObject	clone = Network.Instantiate (Pistolbullet, muzzle.position  
		//			//			                     , muzzle.rotation,0) as GameObject;
		//			//			GameObject.Find("bullet").rigidbody.AddForce (transform.forward * shootForce);;	 
		//			//			
		//			//			
		//			//			Debug.Log ("Click");
		//			//			timer = 1;
		//			
		//		}else if (Input.GetMouseButtonDown(0) && gun == 0) {
		//
		//		}
		if(networkView.isMine)
		{
			if (isdead == false)
			{
			if (Input.GetKey(KeyCode.W))//||(Input.GetKey(KeyCode.D))||(Input.GetKey(KeyCode.S))||(Input.GetKey(KeyCode.A)))
			{
				networkView.RPC ("Run2m", RPCMode.All,5.0f);
				//anim.SetFloat("run",speed);
				Debug.Log("its happening");
			}else 
			{
				networkView.RPC ("Run2m", RPCMode.All,0.0f);
				
				//anim.SetFloat("run",0.0f);
			}
			if (Input.GetKey(KeyCode.S))//||(Input.GetKey(KeyCode.D))||(Input.GetKey(KeyCode.S))||(Input.GetKey(KeyCode.A)))
			{
				networkView.RPC ("Back2m", RPCMode.All,5.0f);
				//anim.SetFloat("run",speed);
				Debug.Log("its happening");
			}else 
			{
				networkView.RPC ("Back2m", RPCMode.All,0.0f);
				
				//anim.SetFloat("run",0.0f);
			}
			if (Input.GetKey(KeyCode.A))//||(Input.GetKey(KeyCode.D))||(Input.GetKey(KeyCode.S))||(Input.GetKey(KeyCode.A)))
			{
				networkView.RPC ("Right2m", RPCMode.All,5.0f);
				//anim.SetFloat("run",speed);
				Debug.Log("its happening");
			}else 
			{
				networkView.RPC ("Right2m", RPCMode.All,0.0f);
				
				//anim.SetFloat("run",0.0f);
			}
			if (Input.GetKey(KeyCode.D))//||(Input.GetKey(KeyCode.D))||(Input.GetKey(KeyCode.S))||(Input.GetKey(KeyCode.A)))
			{
				networkView.RPC ("Left2m", RPCMode.All,5.0f);
				//anim.SetFloat("run",speed);
				Debug.Log("its happening");
			}else 
			{
				networkView.RPC ("Left2m", RPCMode.All,0.0f);
				
				//anim.SetFloat("run",0.0f);
			}
			if (Input.GetMouseButtonDown(0) && gun == 0)
			{
				networkView.RPC ("pistol2m", RPCMode.All,true);
				//	pistol(true);
				//anim.SetBool("shoot",true);
				Debug.Log("shooting");
			}else 
			{
				networkView.RPC ("pistol2m", RPCMode.All,false);
				//	pistol(false);
				//			anim.SetBool("shoot",false);
				//			Debug.Log("false");
			}
			if (Input.GetMouseButtonDown(0) && (gun == 1 || gun == 2))
			{
				//anim.SetFloat("run",speed);
				//	Gun(true);
				networkView.RPC ("Gun2m", RPCMode.All,true);
				Debug.Log("mshooting");
			}else 
			{
				networkView.RPC ("Gun2m", RPCMode.All,false);
				//	Gun(false);
				//			anim.SetBool("multishoot",false);
				//			Debug.Log("false");
			}
		}
		}
		if(isdead == true)
		{
			networkView.RPC("die",RPCMode.All,true);
		}else{
			networkView.RPC("die",RPCMode.All,false);
		}
	}
	[RPC]
	void 	Run2m(float x)
	{
		
		anim2m.SetFloat("run2m",x);
	}
	[RPC]
	void 	Back2m(float x)
	{
		
		anim2m.SetFloat("back2m",x);
	}
	[RPC]
	void pistol2m(bool x)
	{
		anim2m.SetBool("shoot2m",x);
	}
	[RPC]
	void 	Gun2m(bool x)
	{
		anim2m.SetBool("multishoot2m",x);
		
	}
	[RPC]
	void 	Right2m(float x)
	{
		
		anim2m.SetFloat("right2m",x);
	}
	[RPC]
	void 	Left2m(float x)
	{
		
		anim2m.SetFloat("left2m",x);
	}[RPC]
	void die(bool x){
		anim2m.SetBool("die",x);
	}
	void makedead(bool dead){
		isdead = dead;
		Debug.Log("dead is " + isdead);
	}
}
