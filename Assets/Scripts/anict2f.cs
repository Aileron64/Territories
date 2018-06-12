using UnityEngine;
using System.Collections;

public class anict2f : MonoBehaviour {
	
	 private Animator anim2f;
	//	CharacterController cc;
	public float speed = 10f;
	private int gun;
	public bool isdead = false;
	
	// Use this for initialization
	void Awake () {
		
		//		cc = GetComponent<CharacterController>();
		
		anim2f = GetComponent<Animator>();
		
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
				networkView.RPC ("Run2f", RPCMode.All,5.0f);
				//anim.SetFloat("run",speed);
				Debug.Log("its happening");
			}else 
			{
				networkView.RPC ("Run2f", RPCMode.All,0.0f);
				
				//anim.SetFloat("run",0.0f);
			}
						if (Input.GetKey(KeyCode.S))//||(Input.GetKey(KeyCode.D))||(Input.GetKey(KeyCode.S))||(Input.GetKey(KeyCode.A)))
						{
							networkView.RPC ("Back2f", RPCMode.All,5.0f);
							//anim.SetFloat("run",speed);
							Debug.Log("its happening");
						}else 
						{
							networkView.RPC ("Back2f", RPCMode.All,0.0f);
							
							//anim.SetFloat("run",0.0f);
						}
						if (Input.GetKey(KeyCode.A))//||(Input.GetKey(KeyCode.D))||(Input.GetKey(KeyCode.S))||(Input.GetKey(KeyCode.A)))
						{
							networkView.RPC ("Right2f", RPCMode.All,5.0f);
							//anim.SetFloat("run",speed);
							Debug.Log("its happening");
						}else 
						{
							networkView.RPC ("Right2f", RPCMode.All,0.0f);
							
							//anim.SetFloat("run",0.0f);
						}
						if (Input.GetKey(KeyCode.D))//||(Input.GetKey(KeyCode.D))||(Input.GetKey(KeyCode.S))||(Input.GetKey(KeyCode.A)))
						{
							networkView.RPC ("Left2f", RPCMode.All,5.0f);
							//anim.SetFloat("run",speed);
							Debug.Log("its happening");
						}else 
						{
							networkView.RPC ("Left2f", RPCMode.All,0.0f);
							
							//anim.SetFloat("run",0.0f);
						}
					if (Input.GetMouseButtonDown(0) && gun == 0)
					{
							networkView.RPC ("pistol2f", RPCMode.All,true);
						//	pistol(true);
						//anim.SetBool("shoot",true);
						Debug.Log("shooting");
					}else 
					{
							networkView.RPC ("pistol2f", RPCMode.All,false);
						//	pistol(false);
			//			anim.SetBool("shoot",false);
			//			Debug.Log("false");
					}
					if (Input.GetMouseButtonDown(0) && (gun == 1 || gun == 2))
					{
						//anim.SetFloat("run",speed);
						//	Gun(true);
							networkView.RPC ("Gun2f", RPCMode.All,true);
						Debug.Log("mshooting");
					}else 
					{
							networkView.RPC ("Gun2f", RPCMode.All,false);
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
	void 	Run2f(float x)
	{
		
		anim2f.SetFloat("run2f1",x);
	}
		[RPC]
		void 	Back2f(float x)
		{
			 
			anim2f.SetFloat("Back2f",x);
		}
		[RPC]
		void pistol2f(bool x)
		{
			anim2f.SetBool("shoot2f",x);
		}
		[RPC]
		void 	Gun2f(bool x)
		{
			anim2f.SetBool("multishoot2f",x);
			 
		}
		[RPC]
		void 	Right2f(float x)
		{
			
			anim2f.SetFloat("right2f",x);
		}
		[RPC]
		void 	Left2f(float x)
		{
			
			anim2f.SetFloat("left2f",x);
		}
	[RPC]
	void die(bool x){
		anim2f.SetBool("die2f",x);
        }
	void makedead(bool dead){
		isdead = dead;
		Debug.Log("dead is " + isdead);
	}
}