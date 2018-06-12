using UnityEngine;
using System.Collections;

public class healthaddblue : MonoBehaviour {
public	float healrate = 0.25f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay(Collider other){
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
		
		if(other.gameObject.tag=="Enemy")
		{
			Debug.Log ("hit tank");
			Health h = other.transform.GetComponent<Health>();
			//		while(h==null && hit.tranform.parent)
			//		{
			//	hit1 =	hit.parent;
			//	h= hit.transform.GetComponent<Health>();
			//	}
			 
			 
			if (h != null)
			{
				h.healme(healrate);
			}
			
			
		}
		
	}
}
