using UnityEngine;
using System.Collections;

public class shootfx : MonoBehaviour {
	GameObject guneffect;
	GameObject bullet;
	public Transform spawnPoint;
	public Rigidbody projectilPrefab;
	public GameObject fireEffect;
	public Transform muzzle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	[RPC]
	void shootbullet(Vector3 start, Vector3 end){
		Rigidbody clone;
		GameObject muzzle1 =  Instantiate(fireEffect, muzzle.position, muzzle.rotation) as GameObject;
		clone = Instantiate(projectilPrefab, spawnPoint.position, spawnPoint.rotation)as Rigidbody;
		clone.AddForce(transform.forward * 2500f);
		Destroy(clone.gameObject,10);

	}
}
