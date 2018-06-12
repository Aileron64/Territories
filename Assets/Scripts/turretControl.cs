using UnityEngine;
using System.Collections;

public class turretControl : MonoBehaviour {
//public 	Transform lookat;
//	public Transform target1;
	public Transform target2;
	public float range = 200f;
	public GameObject bulletObject;
	public Transform spawnPoint;
public GameObject fireEffect;
  public Rigidbody projectilPrefab;
	public float timer1;
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
//	transform.LookAt(lookat);
		findenemy();
			//  transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, Time.time * speed);
	}
	[RPC]
	 void findenemy()
	{
		if(GameObject.FindGameObjectWithTag("Player"))
		{
			target2 =	GameObject.FindGameObjectWithTag("Player").transform;
			Debug.Log("found one");
		}
		timer1 += Time.deltaTime;
		if(target2 && CanAttackTarget())
		{
			Debug.Log ("hi");
			Vector3 relativePos = target2.position - transform.position;
			Quaternion	targetRotation = Quaternion.LookRotation(relativePos, Vector3.up);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 1.2f);
		}





	}
	[RPC]
	 bool CanAttackTarget()
{
	//Check if the target is close enough
	if(Vector3.Distance(transform.position, target2.position) > range)
			 
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
				Attack();
		}
		else
		{
				Debug.DrawLine(transform.position, target2.position,Color.green);
			 
				
			Attack();
			return true;
		}
	}
	return true;
	}
	[RPC]	
void	 Attack()
{
		if (timer1 >= 3f)
		{
	 //	audio.Play();
 GameObject clone;
		Network.Instantiate(fireEffect, spawnPoint.position, spawnPoint.rotation,0);
		
		
		//Instantiate(bulletObject, spawnPoint.position, spawnPoint.rotation);
			
	 clone = Network.Instantiate(projectilPrefab, spawnPoint.position, spawnPoint.rotation,0)as GameObject;
//		clone.AddForce(transform.forward * 2500f);
			Destroy(clone.gameObject,10);
			timer1 =0;
			Debug.Log("firing cannon");
		}	
}
	
}