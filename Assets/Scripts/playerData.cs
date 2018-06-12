using UnityEngine;
using System.Collections;

public class playerData : MonoBehaviour {
	public bool isgirlpd = false;
	public bool isboypd = false;
	 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.K))
		{
			
			Debug.Log ("is girl is " + isgirlpd);
			Debug.Log ("is boy is " + isboypd);
		}
	}
}
