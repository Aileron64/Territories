using UnityEngine;
using System.Collections;

public class Destroid : MonoBehaviour {

	// Use this for initialization
	
	public float speed  = 200;
	public float range  = 400;

	 
	 
	 
	private float dist;
	 
void Start () {
  // or whatever;
	}

void Update () {
		
	// Move Ball forward
//	transform.Translate(new Vector3(forward * Time.deltaTime * speed);
	
	// Record Distance.
	dist += Time.deltaTime * speed;
	
	// If reach to my range, Destroy. 
	if(dist >= range) {
		 
		Destroy(gameObject);
	}
}
}