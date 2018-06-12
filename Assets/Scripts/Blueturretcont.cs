using UnityEngine;
using System.Collections;

public class Blueturretcont : MonoBehaviour {
 
		//public 	Transform lookat;
		//	public Transform target1;
		public Transform target2;
		private float range = 25f;
		public GameObject bulletObject;
		public Transform spawnPoint;
		public GameObject fireEffect;
		public Rigidbody projectilPrefab;
		public float timer1;
	public float timer2;
		// Use this for initialization
		void Start () {
	
		}
		void Awake()
		{
			//	target2 = GameObject.FindGameObjectWithTag("Player").transform;
			//	Debug.Log (target2.transform);
		}
		
		// Update is called once per frame
		void Update () {
		timer2 += Time.deltaTime;
			//	transform.LookAt(lookat);
		if (timer2 >= 20)
		{
			Debug.Log("time to kill blue turret on");
		networkView.RPC ("findenemy", RPCMode.All);
		}
			//  transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, Time.time * speed);
		}
		[RPC]
		void findenemy()
		{
		if (target2 == null)
		{
			if(GameObject.FindGameObjectWithTag("Player"))
			{
				target2 =	GameObject.FindGameObjectWithTag("Player").transform;
			//	Debug.Log("found one");
			}
		}
		// Debug.Log(Vector3.Distance(transform.position, target2.position));
		if (target2 != null)
		{
		if((Vector3.Distance(transform.position, target2.position) >= range))
		{
			target2 = null;
			if (target2 != null)
			{
			Debug.Log (target2.collider.name);
			}
		}
		}
			timer1 += Time.deltaTime;
		if(target2 != null )// && CanAttackTarget())
			{
			networkView.RPC ("CanAttackTarget", RPCMode.All);
			//	Debug.Log ("hijjj");
				Vector3 relativePos = target2.position+ new Vector3(0,1,0) - transform.position;
				Quaternion	targetRotation = Quaternion.LookRotation(relativePos, Vector3.up);
				transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 1.2f);
			}
			
			
			
			
			
		}
		[RPC]
		bool CanAttackTarget()
		{
		if(target2 == null)
		{
			target2 =	GameObject.FindGameObjectWithTag("Player").transform;
		//	Debug.Log("found one");
		}
			//Check if the target is close enough
			if(Vector3.Distance(transform.position, target2.position) >= range)
				
			{
				Debug.DrawLine(transform.position, target2.position,Color.blue);
				//	Disengage();
				return false;
				
			}
			
			RaycastHit hit;
			
			//Check if there's collision inbetween turret & target
			if(Physics.Linecast(transform.position, target2.position,out hit))
				
			{
				
				if(hit.collider.gameObject.tag == "Player")
				{
					Debug.DrawLine(transform.position, target2.position,Color.red);
					
					Debug.Log(hit.collider.gameObject.name); // this will tell you what you are hitting
					//	Disengage();
					return false;
				//	Attack();
				}
				else
				{
					Debug.DrawLine(transform.position, target2.position,Color.green);
					
					
				networkView.RPC ("Attack", RPCMode.All);
					return true;
				}
			}
			return true;
		}
		[RPC]	
		void	 Attack()
	{
		if (target2 !=null)
		{
			Debug.Log("range is "+ range);
			if(Vector3.Distance(transform.position, target2.position) <= range)
			{
				//		Debug.Log ("fuck me");
				if (timer1 >= 5f )
				{
					
					//	audio.Play();
					Rigidbody clone;
					Instantiate(fireEffect, spawnPoint.position, spawnPoint.rotation);
					
					
					//Instantiate(bulletObject, spawnPoint.position, spawnPoint.rotation);
					
					clone = Instantiate(projectilPrefab, spawnPoint.position, spawnPoint.rotation)as Rigidbody;
					clone.AddForce(transform.forward * 2500f);
					Destroy(clone.gameObject,5);
					timer1 = 0;
					Debug.Log("firing cannon");
				}	
			}
		}
	}
}