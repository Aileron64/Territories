using UnityEngine;
using System.Collections;

public class health1m : MonoBehaviour {
	 
		Animator anim;
		public	int currentHitPoint;
		public int hitpoints = 100;
		public bool isdead = false;
		Player p1;
		Player p ;
		
		// Use this for initialization
		void Awake () {
			
			//		cc = GetComponent<CharacterController>();
			
			anim = GetComponent<Animator>();
			
		}
		void Start () {
			
			currentHitPoint = hitpoints;
			
			enabled = networkView.isMine;
		}
		
		// Update is called once per frame
		void Update () {
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
				if(Input.GetKey(KeyCode.V)){
					Die(); 
					
				}
			}
		}
		public void	TakeDamage(int amt)
		{
			if (isdead == false)
			{
				currentHitPoint -= amt;
			}
			Debug.Log ("amt is "+amt);
			if (currentHitPoint <= 0 )
			{
				
				
				//	networkView.RPC ("Die", RPCMode.All);
				Die();
				
			}
			
		}
		[RPC]
		void Die(){
			Debug.Log ("i'm dieing");
			//	anim.SetTrigger("die");
			
			
			
//			NetworkManager	nm	=	GameObject.FindObjectOfType<NetworkManager>();
//			playerData	pd = gameObject.GetComponent<playerData>();
//			
//			//	NetworkManager nm;
//			if (pd.isboypd == true){
//				
//			nm.timer = 5f;
//				
//			}
//			if (pd.isgirlpd == true)
//			{
//				nm.respawn1f();
//				
//			}
			
			Network.Destroy(gameObject);
			
			
			
			
			
			//	if ( gameObject.tag  == "Player")
			//		{
			//			Debug.Log("in player loop");
			//		 
			//			//	GameObject l = GameObject.FindGameObjectWithTag("lobbies");
			//			 
			//				amiController a1 =	gameObject.transform.GetComponent<amiController>();
			//				if (a1 != null)
			//				{
			//				a1.isdead = true;
			//			 
			//				 p1 = gameObject.GetComponent<Player>();
			//			p1.respawn();
			//				//networkView.RPC ("respawn", RPCMode.All);
			//
			//				}
			//			anic1m a2 = gameObject.transform.GetComponent<anic1m>();
			//			if(a2 !=null)
			//			{
			//				a2.isdead = true;
			//				p1 = gameObject.GetComponent<Player>();
			//			p1.respawn();
			//			 
			//
			//			PlayerInput pi = gameObject.transform.GetComponent<PlayerInput>();
			//			pi.isdead = true;
			//		  p =	gameObject.transform.GetComponent<Player>();
			//
			//			p.isfired(true);
			//		}
			//		if( gameObject.tag  == "Enemy")
			//		{
			//
			//			anc2m a2m =	gameObject.transform.GetComponent<anc2m>();
			//			if (a2m != null)
			//			{
			//				a2m.isdead = true;
			//				
			//		PlayerBlue		pb1 = gameObject.GetComponent<PlayerBlue>();
			//				pb1.respawn();
			//				networkView.RPC ("respawn", RPCMode.All);
			//			}
			//			anict2f an2f = gameObject.transform.GetComponent<anict2f>();
			//			if (an2f != null)
			//			{
			//				an2f.isdead = true;
			//				
			//				PlayerBlue		pb1a = gameObject.GetComponent<PlayerBlue>();
			//				pb1a.respawn();
			//				//networkView.RPC ("respawn", RPCMode.All);
			//			}
			//
			//
			//			PlayerInput pi = gameObject.transform.GetComponent<PlayerInput>();
			//			pi.isdead = true;
			//	PlayerBlue		p =	gameObject.transform.GetComponent<PlayerBlue>();
			//			
			//			p.isfired(true);
			//
			//		}
			//		isdead = true;
			//		currentHitPoint = hitpoints;
			//		Debug.Log("current = " + currentHitPoint);
			//		isdead = false;
			//	//	animation.Play("die");
			//		//	Destroy(gameObject);
			//	}

	}
 
}
