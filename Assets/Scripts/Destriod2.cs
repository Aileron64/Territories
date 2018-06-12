using UnityEngine;
using System.Collections;

public class Destriod2 : MonoBehaviour {

	float timer = -1f;
	float timer_length = 2.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (timer >= 0)
			timer += Time.deltaTime;
		
		if (timer >= timer_length)
		{
			Debug.Log("Time to die");
			Destroy(gameObject);
		}

	}
}
