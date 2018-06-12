using UnityEngine;
using System.Collections;

public class blueballs : MonoBehaviour {

	// Use this for initialization
	
	public float speed  = 100;
	public float range  = 25;
	public GameObject bullethole;
	public	int damage = 25;
	private float dist;
	
	void Start () {
		// or whatever;
	}
	
	void Update () {
		
		
		
		
		dist += Time.deltaTime * speed;
		
		// If reach to my range, Destroy. 
		if(dist >= range) {
			//	Instantiate(ExploPtcl, transform.position, transform.rotation);
			//	Destroy(gameObject);
		}
	}
	
	
	void OnTriggerEnter(Collider other){
		// If hit something, Destroy. 
		
		Debug.Log (other.collider.name);
		Debug.Log ("hit21");
		/*if(other.gameObject.tag=="enemy")
		{

			Debug.Log ("hit");
			Instantiate(exp, transform.position, transform.rotation);
		Destroy(other.gameObject);
		}
		Instantiate(ExploPtcl, transform.position, transform.rotation);
	*/
		//	Destroy(gameObject);
		
		if(other.gameObject.tag=="Player")
		{
			Debug.Log ("hit tank");
			Health h = other.transform.GetComponent<Health>();
			//		while(h==null && hit.tranform.parent)
			//		{
			//	hit1 =	hit.parent;
			//	h= hit.transform.GetComponent<Health>();
			//	}
			if (other.collider.tag == "Player")
			{
				Instantiate(bullethole, transform.position, transform.rotation);
				//Quaternion.FromToRotation(Vector3.up,other.transform.position.Normalize()));
			}
			Debug.Log (other.collider.name);
			if (h != null)
			{
				h.TakeDamage(damage);
			}
			
			
		}
		
	}
	
}
