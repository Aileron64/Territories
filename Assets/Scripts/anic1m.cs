using UnityEngine;
using System.Collections;

public class anic1m : MonoBehaviour {

Animator anim1m;
	//	CharacterController cc;
	public float speed = 10f;
	private int gun;
	public bool isdead = false;
	
	// Use this for initialization
	void Awake () {
		
		//		cc = GetComponent<CharacterController>();
		
		anim1m = GetComponent<Animator>();
		
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
				networkView.RPC ("Run1m", RPCMode.All,5.0f);
				//anim.SetFloat("run",speed);
				Debug.Log("its happening");
			}else 
			{
				networkView.RPC ("Run1m", RPCMode.All,0.0f);
				
				//anim.SetFloat("run",0.0f);
			}
						if (Input.GetKey(KeyCode.S))//||(Input.GetKey(KeyCode.D))||(Input.GetKey(KeyCode.S))||(Input.GetKey(KeyCode.A)))
						{
							networkView.RPC ("Back1m", RPCMode.All,5.0f);
							//anim.SetFloat("run",speed);
							Debug.Log("its happening");
						}else 
						{
							networkView.RPC ("Back1m", RPCMode.All,0.0f);
							
							//anim.SetFloat("run",0.0f);
						}
						if (Input.GetKey(KeyCode.A))//||(Input.GetKey(KeyCode.D))||(Input.GetKey(KeyCode.S))||(Input.GetKey(KeyCode.A)))
						{
							networkView.RPC ("Right1m", RPCMode.All,5.0f);
							//anim.SetFloat("run",speed);
							Debug.Log("its happening");
						}else 
						{
							networkView.RPC ("Right1m", RPCMode.All,0.0f);
							
							//anim.SetFloat("run",0.0f);
						}
						if (Input.GetKey(KeyCode.D))//||(Input.GetKey(KeyCode.D))||(Input.GetKey(KeyCode.S))||(Input.GetKey(KeyCode.A)))
						{
							networkView.RPC ("Left1m", RPCMode.All,5.0f);
							//anim.SetFloat("run",speed);
							Debug.Log("its happening");
						}else 
						{
							networkView.RPC ("Left1m", RPCMode.All,0.0f);
							
							//anim.SetFloat("run",0.0f);
						}
					if (Input.GetMouseButtonDown(0) && gun == 0)
					{
							networkView.RPC ("pistol1m", RPCMode.All,true);
						//	pistol(true);
						//anim.SetBool("shoot",true);
						Debug.Log("shooting");
					}else 
					{
							networkView.RPC ("pistol1m", RPCMode.All,false);
						//	pistol(false);
			//			anim.SetBool("shoot",false);
			//			Debug.Log("false");
					}
					if (Input.GetMouseButtonDown(0) && (gun == 1 || gun == 2))
					{
						//anim.SetFloat("run",speed);
						//	Gun(true);
							networkView.RPC ("Gun1m", RPCMode.All,true);
						Debug.Log("mshooting");
					}else 
					{
							networkView.RPC ("Gun1m", RPCMode.All,false);
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
	void 	Run1m(float x)
	{
		
		anim1m.SetFloat("run1m",x);
	}
		[RPC]
		void 	Back1m(float x)
		{
			 
			anim1m.SetFloat("back1m",x);
		}
		[RPC]
		void pistol1m(bool x)
		{
			anim1m.SetBool("shoot1m",x);
		}
		[RPC]
		void 	Gun1m(bool x)
		{
			anim1m.SetBool("multishoot1m",x);
			 
		}
		[RPC]
		void 	Right1m(float x)
		{
			
			anim1m.SetFloat("right1m",x);
		}
		[RPC]
		void 	Left1m(float x)
		{
			
			anim1m.SetFloat("left1m",x);
	}[RPC]
	void die(bool x){
		anim1m.SetBool("die",x);
	}
	void makedead(bool dead){
		isdead = dead;
		Debug.Log("dead is " + isdead);
	}
}
