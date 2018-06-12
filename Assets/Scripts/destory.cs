using UnityEngine;
using System.Collections;

public class destory : MonoBehaviour {
ParticleSystem tmpPtclObj;

void Awake() {
	// get my ParticleSystem
	tmpPtclObj = gameObject.GetComponent(typeof(ParticleSystem)) as ParticleSystem;
}

void Update () {
	// When it finish the play, Destroy.
	if (tmpPtclObj.isStopped)
		Destroy(gameObject);
}
	 
}
