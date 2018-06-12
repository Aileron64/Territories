using UnityEngine;
using System.Collections;

public class PlayerT4 : MonoBehaviour {
	 
 
	public float speed = 10f;

	private float lastSynchronizationTime = 0f;
	private float syncDelay = 0f;
	private float syncTime = 0f;
	private Vector3 syncStartPosition = Vector3.zero;
	private Vector3 syncEndPostion = Vector3.zero;
	 
	public int playerTeam = 3;


	void start(){





	}





	void Update()
	{
		RaycastHit hit;
		if (Physics.Raycast(transform.position, -Vector3.up, out hit))
		//if (	gameObject.tag == "ground")
		{
		if	(hit.collider.renderer.material.color != Color.green)
			{
				Debug.Log (hit.collider.renderer.material.color);
				hit.collider.renderer.material.color = Color.green;
				Debug.Log (hit.collider.renderer.material.color);
			} 
				//else if(hit.team == 1) {
//				Debug.Log (hit.team);
//				hit.collider.renderer.material.color = Color.blue;
//				Debug.Log (hit.team);
//			}

//			int teamnumber = 1;
//			changecolour.team = teamnumber;
//			GameObject thePlayer = GameObject.Find("ThePlayer");
//			c1 Changecolor = thePlayer.GetComponent<c1>();
		//	changecolor.team += 1;

		}


		if (networkView.isMine) {
						InputMovement ();
				} else {
			SyncedMovement();
				}
	}

	private void SyncedMovement(){
		syncTime += Time.deltaTime;
		rigidbody.position = Vector3.Lerp (syncStartPosition, syncEndPostion, syncTime / syncDelay);

		}

	void InputMovement()
	{
		if (Input.GetKey(KeyCode.W))
			rigidbody.MovePosition(rigidbody.position + Vector3.forward * speed * Time.deltaTime);
		
		if (Input.GetKey(KeyCode.S))
			rigidbody.MovePosition(rigidbody.position - Vector3.forward * speed * Time.deltaTime);
		
		if (Input.GetKey(KeyCode.D))
			rigidbody.MovePosition(rigidbody.position + Vector3.right * speed * Time.deltaTime);
		
		if (Input.GetKey(KeyCode.A))
			rigidbody.MovePosition(rigidbody.position - Vector3.right * speed * Time.deltaTime);
	}

	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
	{
		
		Vector3 syncPosition = Vector3.zero;
		if (stream.isWriting) {
			syncPosition = rigidbody.position;
			stream.Serialize (ref syncPosition);
		} else {
			stream.Serialize(ref syncPosition);
			syncTime = 0f;
			syncDelay = Time.time - lastSynchronizationTime;
			lastSynchronizationTime = Time.time;

			syncStartPosition = rigidbody.position;
			syncEndPostion = syncPosition;

		}
		
		
	}

}
