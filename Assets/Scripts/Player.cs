using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public GameObject Team1male;
	public GameObject Team1Female;
public Lobby lob;
	public playerData pd;
	public bool isboy = false;
	public bool isGirl = false;
	public float speed = 1000f;
	public Vector3 orgspawn;
	private float lastSynchronizationTime = 0f;
	private float syncDelay = 0.1f;
	private float syncTime = 0.1f;
	private Vector3 syncStartPosition = Vector3.zero;
	private Vector3 syncEndPostion = Vector3.zero;
	private Vector3 movedirection;
	public int playerTeam = 0;
	public float timer3;
	public GameObject playerPrefab;
	public GameObject playerObj;
	public Transform objectSpawn;
	public bool isspawn = false;
	public GameObject playerPrefab2;
	public GameObject playerObj2;
	public Transform objectSpawn2;
	public bool isspawn2 = false;
	public GameObject player;
	public Rigidbody Pistolbullet;
	public Rigidbody Assaultbullet;
	public float shootForce = 500;
	public GameObject fireEffect;
	public Transform muzzle;
	private int gun;
	Vector3 direction = Vector3.zero;
	CharacterController cc;
	Rigidbody objectTest;
	float timer;
	public GameObject target;
	public	float damage = 25;
	public GameObject p;
	shootfx shfx;
	public GameObject bullethole;
	public GameObject bullethole2;
    public	bool isdead = false;
	private float machinegunammo = 50.0f;
//	Animator anim;
	void	Awake(){

		p = GameObject.FindWithTag("cam");


	}
 
void		start ()
		{
		enabled = networkView.isMine;
//		CHandler c1 =	gameObject.transform.GetComponent<CHandler>();
//		if (c1.onGround = true)
//		{
//
//		orgspawn = gameObject.transform.position;
//		}
//		//orgspawn.transform.rotation = gameObject.transform.rotation;
		//orgspawn = gameObject.transform.position;
		 
	}




	[RPC]
	void Update()
	{
		if (machinegunammo < 50.0)
		{
			machinegunammo += .01f;
			Debug.Log("recharging gun" + machinegunammo);
		}

		timer3 += Time.deltaTime;
		if (p == null)
		{
			p = GameObject.FindWithTag("cam");
		}

		//direction =  transform.rotation * new Vector3 (Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical")).normalized;
//		if (Input.GetKey(KeyCode.W))
//		{
//		anim.SetFloat("run",speed);
//		}else 
//		{
//			anim.SetFloat("run",0.0f);
//		}
//		muzzle.position = p.transform.postion;
	//	muzzle.transform.rotation = p.transform.rotation;

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
		
//		if (Input.GetKey(KeyCode.M))
//		{
//
//			pd = gameObject.GetComponent<playerData>();
//
//			Debug.Log("spawn spot is" + orgspawn);
//			 
//		//	isGirl = pd.isgirlpd;
//			if (pd.isboypd == true){
//				Debug.Log ("is boy is " + pd.isboypd);
//			}
//			if(pd.isgirlpd == true){
//			Debug.Log ("is girl is " + pd.isgirlpd);
//			}
//		}
	
		if(Input.GetKey(KeyCode.L))
		   {
			respawn ();
		//	gameObject.transform.position = orgspawn + new Vector3(0,4,0);
		}



		if (networkView.isMine) {
					InputMovement ();

				
	if(isdead == false)
			{
	if (Input.GetKey(KeyCode.W))
	   {

	//		animation.Play ("pistolAim");	 
			networkView.RPC("ray1",RPCMode.AllBuffered,null);

		}
		if (Input.GetKey(KeyCode.S))
		{
			
			//		animation.Play ("pistolAim");	 
			networkView.RPC("ray1",RPCMode.AllBuffered,null);
			
		}if (Input.GetKey(KeyCode.A))
		{
			
			//		animation.Play ("pistolAim");	 
			networkView.RPC("ray1",RPCMode.AllBuffered,null);
			
		}if (Input.GetKey(KeyCode.D))
		{
			
			//		animation.Play ("pistolAim");	 
			networkView.RPC("ray1",RPCMode.AllBuffered,null);
			
		}
//		if (Input.GetKey(KeyCode.R))
//		{
//			
//			animation.Play ("kneelAim");	 
//			
//		}
//		if (Input.GetKey(KeyCode.T))
//		{
//			if (isspawn == false){
//		//	objectSpawn =   new Vector3 (0, transform.position.y + 2.0f,transform.position.z +2.0f);
//				playerObj = Network.Instantiate (playerPrefab,  objectSpawn.position, Quaternion.identity,0)as GameObject;	 
//				isspawn = true;
//			}
//		}
//		if (Input.GetKey(KeyCode.Y))
//		{
//			if (isspawn2 == false){
//		//		objectSpawn2 =   new Vector3 (0, transform.position.y + 2.0f,transform.position.z +2.0f);
//				playerObj2 = Network.Instantiate (playerPrefab2,  objectSpawn2.position, Quaternion.identity,0)as GameObject;	 
//				isspawn2 = true;
//			}
//		}

		if ((Input.GetMouseButtonDown(0) && gun ==1) && machinegunammo > 0)
		{
					if (timer3 >= .5f)
					{
			networkView.RPC ("fire2", RPCMode.All);
						timer3 = 0;
						Debug.Log("gun ammo is " + machinegunammo);
						machinegunammo -= 1f;
					}
			//	networkView.RPC ("fire2", RPCMode.All);
			
			
		}else if (Input.GetMouseButtonDown(0) && gun == 0) {
					if ( timer3 >= 3 )
					{
			networkView.RPC ("fire2", RPCMode.All);
						timer3 = 0;
			//	networkView.RPC("fire2",RPCMode.All);
			//first one call the raycast next one is just the gfx represent.
					}
				}else if (Input.GetMouseButtonDown(0) && gun == 3) {
					if (timer3 >= 40)
					{
					networkView.RPC ("fire2", RPCMode.All);
						timer3 = 0;
					}



				}
			} 
		}else {
			SyncedMovement();
			//ray1 ();
			//	fire ();
		}
	}

	
	
	
	
	[RPC]
void fire()
{			
		//GameObject p = GameObject.FindWithTag("cam");
	//	muzzle.transform.rotation = p.transform.rotation;
	//target = GameObject.FindWithTag("cam");
		if (target != null)
		{
		    Debug.DrawLine(muzzle.transform.position,new Vector3(20,0,0),Color.green);
		}
		RaycastHit hit;
//	Ray ray = new Ray(muzzle.transform.position, muzzle.transform.forward);
		Ray ray = p.camera.ScreenPointToRay(Input.mousePosition);
		//	this.camera.ScreenPointToRay(Input.mousePosition);
	
	Transform hit1;
		if (	Physics.Raycast(ray, out hit))
		    {
		Debug.Log(hit.collider.name);
		}
	if (	Physics.Raycast(ray, out hit)&& GameObject.FindWithTag("Enemy"))
	{
		Health h = hit.transform.GetComponent<Health>();
//		while(h==null && hit.tranform.parent)
//		{
		//	hit1 =	hit.parent;
		//	h= hit.transform.GetComponent<Health>();
	//	}
		Debug.Log (hit.collider.name);
		if (h != null)
		{
			h.TakeDamage(damage);
		}
	}
		if (	Physics.Raycast(ray, out hit))
		{
			Debug.Log(hit.collider.name);
	 
		Rigidbody clone;
		 
		clone = Instantiate (Pistolbullet, p.transform.position 
		                     , p.transform.rotation) as Rigidbody;
		float step = speed * Time.deltaTime;
		Vector3 a = hit.transform.position;
		Debug.Log (a);
		//while (clone.position != a)
//	clone.position = Vector3.MoveTowards(clone.position,a,step);
			clone.AddForce(transform.forward * 2500f);
	//	} else {
		//	Debug.Log ("i'm null");
//			float turn = p.transform.rotation.x;
//		clone.AddForce(transform.forward * turn * 2500f);
		}
}
	[RPC]
	void fire2(){
		Rigidbody clone;

		
		if (p == null)
		{
			p = GameObject.FindWithTag("cam");
		}
		 
			Debug.DrawLine(muzzle.transform.position,new Vector3(20,0,0),Color.green);
		 
		RaycastHit hit;
		//	Ray ray = new Ray(muzzle.transform.position, muzzle.transform.forward);
		Ray ray = p.camera.ScreenPointToRay(Input.mousePosition);
		//	this.camera.ScreenPointToRay(Input.mousePosition);
		
		Transform hit1;
		if (	Physics.Raycast(ray, out hit))
		{
			Debug.Log(hit.collider.name);
		}
		if (	Physics.Raycast(ray, out hit) && GameObject.FindWithTag("Enemy"))
		{
			Health h = hit.transform.GetComponent<Health>();
			//		while(h==null && hit.tranform.parent)
			//		{
			//	hit1 =	hit.parent;
			//	h= hit.transform.GetComponent<Health>();
			//	}
			if (hit.collider.tag == "Enemy")
			{
			Instantiate(bullethole, hit.point, Quaternion.FromToRotation(Vector3.up,hit.normal));
			}
			Debug.Log (hit.collider.name);
			if (h != null)
			{
				h.TakeDamage(damage);
			}
		}
		if (	Physics.Raycast(ray, out hit))
		{
			Basehealth1 h2 = hit.transform.GetComponent<Basehealth1>();
			if (hit.collider.tag == "blueBuilding")
			{
			
			//		while(h==null && hit.tranform.parent)
			//		{
			//	hit1 =	hit.parent;
			//	h= hit.transform.GetComponent<Health>();
			//	}
			 
			
				Instantiate(bullethole2, hit.point, Quaternion.FromToRotation(Vector3.up,hit.normal));
		 
			Debug.Log (hit.collider.name);
			if (h2 != null)
			{
				h2.TakeDamage(damage);
			}
			}
		}
		if (	Physics.Raycast(ray, out hit))
		{
			Debug.Log(hit.collider.name);
			 
	 

		
		//	GameObject playerObj = Network.Instantiate (playerPrefab1, new Vector3 (0f, 5f, 0f), Quaternion.Euler(0, 90, 0), 0) as GameObject;
		GameObject clonex =		Instantiate(fireEffect, muzzle.position  ,muzzle.rotation *Quaternion.Euler(-90, 0, 0   )) as GameObject;
//			Transform _playerTransform = null;  
//			Transform _cameraTransform = null;
//			_cameraTransform = p.transform;
//			Vector3 relativePos = p.transform.position - muzzle.transform.position; // Calculate differences
//		//	Quaternion desiredRotation = Quaternion.LookRotation (relativePos); // Calculate required rotation angle
//			Vector3 desiredRotation = new Vector3(_cameraTransform.eulerAngles.x * 1, _playerTransform.eulerAngles.y, _playerTransform.eulerAngles.z); // Sets the rotation based off of the dampener * the Camera's X-axis. It might be the Z-axis instead so... don't get fully invested in using the X
//			_playerTransform.eulerAngles = desiredRotation; // Set the eulerAngles.//for the itween thingy

		//Pistolbullet.rigidbody.AddForce (transform.forward * shootForce);	 
		clone = Instantiate (Pistolbullet, muzzle.position 
			                     , p.transform.rotation ) as Rigidbody;
		//clone.velocity = transform.TransformDirection(Vector3.forward * speed);
	//	float turn = p.transform.rotation.x;
		clone.AddForce(transform.forward * 2500f);

		}}
	void FixedUpdate (){
//		cc.SimpleMove(direction * speed);
	


	}
	[RPC]
	public  void respawn(){

 



//
//		NetworkManager	nm	=	GameObject.FindObjectOfType<NetworkManager>();
//		pd = gameObject.GetComponent<playerData>();
//		
//		//	NetworkManager nm;
//		if (pd.isboypd == true){
//			
//			nm.respawn1m();
//			 
//		}
//		if (pd.isgirlpd == true)
//		{
//			nm.respawn1f();
//
//		}
//		if(networkView.isMine)
//		{
//		Network.Destroy(gameObject);
//		}
			//		if (isGirl == true)
//		{
//			GameObject playerObj = Network.Instantiate(Team1Female, new Vector3(42f, 5f, 41f), Quaternion.Euler(0, 90, 0), 0) as GameObject;
//		}
//		if (isboy == true)
//		{
//			GameObject playerObj = Network.Instantiate(Team1male, new Vector3(0f, 5f, 0f), Quaternion.Euler(0, 90, 0), 0) as GameObject;
//
//		}



	}
public	void isfired(bool dietime){

		isdead = dietime;

	}
	private void SyncedMovement(){
		syncTime += Time.deltaTime;
	//	player.transform.position = Vector3.Lerp (syncStartPosition, syncEndPostion, syncTime / syncDelay);

		}

	void InputMovement()
	{





//		if (Input.GetKey(KeyCode.A))
//		{
//
//			rigidbody.MovePosition(rigidbody.position + Vector3.forward * speed * Time.deltaTime);
//			if ( dirw == false)
//			{
//			//	transform.rotation = Quaternion.LookRotation(transform.forward);
//
//			//	transform.LookAt(Vector3.forward);
//				dirw = true;
//				dirs = false;
//				dira = false;
//				dird = false;
//			}
//			//rigidbody.MoveRotation(0,90,0);//Quaternion.Euler(0, 90, 0)
//			animation.Play ("run");
//		}else 
//		if (Input.GetKey(KeyCode.D))
//		{
//			if ( dirs == false)
//			{
//			//	transform.LookAt(Vector3.back);
//				 
//				dird = false;
//				dirw = false;
//				dirs = true;
//				dira = false;
//
//			}
//			rigidbody.MovePosition(rigidbody.position - Vector3.forward * speed * Time.deltaTime);
//			animation.Play ("run");
//		}
//		else
//		if (Input.GetKey(KeyCode.W)){
//		//	transform.eulerAngles = Vector3(0, 90, 0);
//			if ( dird == false)
//			{
//			//	transform.LookAt(Vector3.right);
//				 
//				dird = true;
//				dirw = false;
//				dirs = false;
//				dira = false;
//				 
//			}
//		//	transform.rotation = Quaternion.Euler(0, 90, 0);
//			rigidbody.MovePosition(rigidbody.position +( Vector3.right * speed * Time.deltaTime));
//	//		animation.Play ("run");
//		}
//		else
//		if (Input.GetKey(KeyCode.S)){
//			if ( dira == false)
//			{
//			//	transform.LookAt(Vector3.left);
//				dira = true;
//				dird = false;
//				dirw = false;
//				dirs = false;
//			}
//			rigidbody.MovePosition(rigidbody.position + Vector3.left * speed * Time.deltaTime);
//		//	animation.Play ("run");
//	}else{
//			animation.CrossFade("idle",0.5f);
//	//	animation.Play ("idle");
//	}
	}
	[RPC]
	void ray()
	{
		RaycastHit hit;
		if (Physics.Raycast(transform.position + new Vector3(0.0f,1.0f,0.0f), -Vector3.up, out hit))
		{
			if (	hit.collider.tag == "ground")
				
			{
				if	(hit.collider.renderer.material.color != Color.red && hit.collider.renderer.material.color != Color.blue )  
				{
					//Debug.DrawLine(hit.transform.position, new Vector3 (0f,5.0f,0f), Color.red);
                    //Debug.Log (hit.collider.renderer.material.color);
                    //hit.collider.renderer.material.color = Color.red;
                    //Debug.Log (hit.collider.renderer.material.color);

                    int x = hit.collider.GetComponent<Cube>().xIndex;
                    int z = hit.collider.GetComponent<Cube>().zIndex;

                    GridManager.grid[x, z] = -100;
				} 
			}
			
			
		}




	}
	[RPC]
	void ray1()
	{
		RaycastHit hit;
		if (Physics.Raycast(transform.position + new Vector3(0.0f,1.0f,0.0f), -Vector3.up, out hit,2.0f))
		{
			if (	hit.collider.tag == "ground")
				
			{
			 
					//Debug.DrawLine(hit.transform.position, new Vector3 (0f,5.0f,0f), Color.red);
//					Debug.Log (hit.collider.renderer.material.color);
					//hit.collider.renderer.material.color = Color.red;
                    int x = hit.collider.GetComponent<Cube>().xIndex;
                    int z = hit.collider.GetComponent<Cube>().zIndex;

                    GridManager.grid[x, z] = -100;
		 
			}
			
			
		}
		
		
		
		
	}
//	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
//	{
//		
//		Vector3 syncPosition = Vector3.zero;
//		if (stream.isWriting) {
//			syncPosition = rigidbody.position;
//			stream.Serialize (ref syncPosition);
//		} else {
//			stream.Serialize(ref syncPosition);
//			syncTime = 0f;
//			syncDelay = Time.time - lastSynchronizationTime;
//			lastSynchronizationTime = Time.time;
//
//			syncStartPosition = rigidbody.position;
//			syncEndPostion = syncPosition;
//
//		}
//		
//		
//	}

}
