using UnityEngine;
using System.Collections;

public class netCam : MonoBehaviour {
	GameObject cam;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(networkView.isMine){
			cam.SetActive(true);
			//camera.gameObject. = true;
		}
		else{
			cam.SetActive(false);
		//	camera.gameObject.GetComponents(). = false;
		}
	}
}
