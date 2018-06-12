using UnityEngine;
using System.Collections;

public class basehealthteam2 : MonoBehaviour {

	
	Animator anim;
	public static int currentHitPoint;
	public int hitpoints = 1000;
	public bool isdead = false;
	public Transform fire;
	public Transform fire2;
	public Transform fire3;
	public Transform fire4;
	public GameObject build;
	public bool onfire1 = false;
	public bool onfire2 = false;
	public bool onfire3 = false;
	public bool onfire4 = false;
	public GameObject effect,effecta,effectb,effectc;
	GameObject effect2;
	GameObject effect3;
	GameObject effect4;
	// Use this for initialization
	void Awake () {
		
		//		cc = GetComponent<CharacterController>();
		
		anim = GetComponent<Animator>();
		
	}
	void Start () {
		currentHitPoint = hitpoints;
		Debug.Log(currentHitPoint);
		Debug.Log(hitpoints);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void	TakeDamage(int amt)
	{
		currentHitPoint -= amt;
		Debug.Log ("base damage is - amt is "+amt);
		Debug.Log("basehp is " + currentHitPoint);
		Debug.Log("basehp is " + hitpoints);

		if (currentHitPoint <= 0 )
		{
			Die();
		}
	 
		if (currentHitPoint <= 950 && currentHitPoint >= 750)
		{
			
			Debug.Log(onfire1);
			Debug.Log("on fire");
				if(onfire1 == false){
				networkView.RPC ("makefire1",RPCMode.AllBuffered,null);
	//	  effect = Instantiate(fire,build.transform.position,build.transform.rotation) as GameObject;
	//			effectb = Instantiate(fire,build.transform.position + new Vector3(4,4,-4),build.transform.rotation) as GameObject;
	//			effectc = Instantiate(fire,build.transform.position + new Vector3(-4,4,4),build.transform.rotation) as GameObject;
//				effectd = Instantiate(fire,build.transform.position,build.transform.rotation) as GameObject;
					onfire1= true;
				}
				if (currentHitPoint == 800)
				{
					
					Destroy(effect);
					Debug.Log("now destroying effect1");
				}
	
		}
	
		
		if (currentHitPoint <=825 && currentHitPoint >=500)   
		{
		
			Debug.Log("on fire2");
				if (onfire2 == false)
				{
				networkView.RPC ("makefire2",RPCMode.AllBuffered,null);
		//	effect2 = Instantiate(fire2,build.transform.position,build.transform.rotation) as GameObject;
					onfire2= true;
			}
				if (currentHitPoint <= 550)
				{
					
					Destroy(effect2);
					Debug.Log("now destroying effect2");
				}
		}
			if (currentHitPoint <= 575 && currentHitPoint >= 200)   
			{
				
				Debug.Log("on fire3");
				if (onfire3 == false)
				{
				networkView.RPC ("makefire3",RPCMode.AllBuffered,null);
					//effect3 = Instantiate(fire3,build.transform.position + new Vector3(2,0,2),build.transform.rotation) as GameObject;
					onfire3= true;
				}
				if (currentHitPoint <= 250)
				{
					
					Destroy(effect3);
					Debug.Log("now destroying effect3");
				}
			 
		}
		if (currentHitPoint <= 275 && currentHitPoint >= 0)   
		{
			networkView.RPC ("makefire4",RPCMode.AllBuffered,null);
			Debug.Log("on fire4");
			if (onfire4 == false)
			{
			//	effect4 = Instantiate(fire4,build.transform.position ,build.transform.rotation) as GameObject;
				onfire4 = true;
			}
			 
			
		}
	}	
	[RPC]
	public void makefire1(){
		effect = Network.Instantiate(fire,build.transform.position,build.transform.rotation, 0) as GameObject;
		
	}
	[RPC]
	public void makefire2()
	{
		effect2 = Network.Instantiate(fire2,build.transform.position,build.transform.rotation,0) as GameObject;
		effectb = Network.Instantiate(fire,build.transform.position + new Vector3(4,4,-4),build.transform.rotation,0) as GameObject;
		effectc = Network.Instantiate(fire,build.transform.position + new Vector3(-4,4,4),build.transform.rotation,0) as GameObject;
	}
	[RPC]
	public void makefire3()
	{
		effect3 = Network.Instantiate(fire3,build.transform.position + new Vector3(-2,0,-2),build.transform.rotation,0) as GameObject;
	}
	[RPC]
	public void makefire4()
	{
		
		effect4 = Network.Instantiate(fire4,build.transform.position ,build.transform.rotation,0) as GameObject;
		
	}

	public void Die(){
		
		Debug.Log ("base is dead");
		

		
		
		
	}
}
