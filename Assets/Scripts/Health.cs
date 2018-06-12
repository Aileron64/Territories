using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	Animator anim;
    public static float currentHitPoint;
	public float hitpoints = 100;
	public bool isdead = false;
	Player p1;
	Player p ;
	public GameObject Team1male;
	public GameObject Team1Female;
	public GameObject Team2male;
	public GameObject Team2Female;
	public Vector3 orgspawn1 ;
	GameManager gm;
	private float timer4;
	bool canSwitch = false;
	bool waitActive = false;
	// Use this for initialization
	void Awake () {
		
		//		cc = GetComponent<CharacterController>();
	 
		anim = GetComponent<Animator>();
		
	}
	void Start () {
	
		currentHitPoint = hitpoints;

		enabled = networkView.isMine;
	}
	IEnumerator Wait(){
		Debug.Log("hi i'm heree");
		yield return new WaitForSeconds(3.0f);
		
		Debug.Log ("i'm dieing");
		//	anim.SetTrigger("die");
		orgspawn1 = NetworkManager.spawnspot69;
		Debug.Log ("dieing hitpoints are " + currentHitPoint);
		Debug.Log ("org" + orgspawn1);
		PlayerSync s =	gameObject.transform.GetComponent<PlayerSync>();
		s.lastPosition = orgspawn1;
		s.targetPosition = orgspawn1;
		currentHitPoint = hitpoints;
		Debug.Log("respaw hit points " + currentHitPoint);
		s.myTransform = transform;
		s.myTransform.position = orgspawn1;
		Resetami();
		
	}
	// Update is called once per frame
	void Update () {
		timer4 += Time.deltaTime;
		if (networkView.isMine) {
		if(Input.GetKey(KeyCode.O))
		{
			Die();
			//	gameObject.transform.position = orgspawn + new Vector3(0,4,0);
		}
		 
			if(Input.GetKey(KeyCode.J)){
				PlayerBlue		pb1 = gameObject.GetComponent<PlayerBlue>();
				pb1.respawn();

			}
			if(Input.GetKey(KeyCode.U)){
				Debug.Log(currentHitPoint); 

			}
			if(Input.GetKeyDown(KeyCode.V)){
				Die(); 
				
			}
		}
	}
	public void healme(float amt2)
	{

		if (currentHitPoint < hitpoints)
		{
		currentHitPoint += amt2;
		Debug.Log(currentHitPoint);
		}
	}
 
	public void	TakeDamage(float amt)
	{






		if (isdead == false)
		{
		currentHitPoint -= amt;
		}
		Debug.Log ("amt is " + currentHitPoint);
		if (currentHitPoint <= 0 )
		{
			
		 
			networkView.RPC ("Die", RPCMode.All);
		//	Die();
	 
		}
	 
	}
	[RPC]
	void Die(){
		GameObject g = GameObject.Find("GameManger");
		if ( gameObject.tag  == "Player")
					{
						Debug.Log("in player loop");
					 
						//	GameObject l = GameObject.FindGameObjectWithTag("lobbies");
						 
							amiController a1 =	gameObject.transform.GetComponent<amiController>();
							if (a1 != null)
							{
							a1.isdead = true;
					 
							}
						anic1m a2 = gameObject.transform.GetComponent<anic1m>();
						if(a2 !=null)
						{
							a2.isdead = true;
			}
						 

						PlayerInput pi = gameObject.transform.GetComponent<PlayerInput>();
				Debug.Log("before"+pi.isdead);
						pi.isdead = true;
				Debug.Log("skdlfjlsd"+pi.isdead);
					  p =	gameObject.transform.GetComponent<Player>();
			
						p.isfired(true);
					}

					if( gameObject.tag  == "Enemy")
					{
			
						anc2m a2m =	gameObject.transform.GetComponent<anc2m>();
						if (a2m != null)
						{
							a2m.isdead = true;
							
					 
						}
						anict2f an2f = gameObject.transform.GetComponent<anict2f>();
						if (an2f != null)
						{
							an2f.isdead = true;
							
							 
							//networkView.RPC ("respawn", RPCMode.All);
						}
			
			
						PlayerInput pi = gameObject.transform.GetComponent<PlayerInput>();
						pi.isdead = true;
				PlayerBlue		p =	gameObject.transform.GetComponent<PlayerBlue>();
						
						p.isfired(true);
			
					}


		StartCoroutine(Wait());
		
		

	 
 

//			}
		}
	public void Resetami()
	{
		if ( gameObject.tag  == "Player")
		{
			Debug.Log("in player loop");
			
			//	GameObject l = GameObject.FindGameObjectWithTag("lobbies");
			
			amiController a1 =	gameObject.transform.GetComponent<amiController>();
			if (a1 != null)
			{
				a1.isdead = false;
				
			}
			anic1m a2 = gameObject.transform.GetComponent<anic1m>();
			if(a2 !=null)
			{
				a2.isdead = false;
			}
			
			
			PlayerInput pi = gameObject.transform.GetComponent<PlayerInput>();
			Debug.Log("before"+pi.isdead);
			pi.isdead = false;
			Debug.Log("skdlfjlsd"+pi.isdead);
			p =	gameObject.transform.GetComponent<Player>();
			
			p.isfired(false);
		}
		
		if( gameObject.tag  == "Enemy")
		{
			
			anc2m a2m =	gameObject.transform.GetComponent<anc2m>();
			if (a2m != null)
			{
				a2m.isdead = false;
				
				
			}
			anict2f an2f = gameObject.transform.GetComponent<anict2f>();
			if (an2f != null)
			{
				an2f.isdead = false;
				
				
				//networkView.RPC ("respawn", RPCMode.All);
			}
			
			
			PlayerInput pi = gameObject.transform.GetComponent<PlayerInput>();
			pi.isdead = false;
			PlayerBlue		p =	gameObject.transform.GetComponent<PlayerBlue>();
			
			p.isfired(false);
			
		}
		
		
		
	}
	
}
