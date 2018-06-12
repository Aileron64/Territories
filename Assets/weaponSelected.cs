 	using UnityEngine;
	using System.Collections;
	public class weaponSelected : MonoBehaviour {
		public GameObject[] weapons; // push your prefabs
	public static int currentWeapon = 0;
		private int nrWeapons = 2;
		void Start() {
			nrWeapons = weapons.Length;
			SwitchWeapon(currentWeapon); // Set default gun
		}
		void Update () {
			 
				if (Input.GetKeyDown("1")) {
				currentWeapon = 0;
				//	SwitchWeapon(0);
			networkView.RPC ("SwitchWeapon", RPCMode.All,0);
				}
		if (Input.GetKeyDown("2")) {
				currentWeapon = 1;
		//	SwitchWeapon(1);
			networkView.RPC ("SwitchWeapon", RPCMode.All,1);
		}
		if (Input.GetKeyDown("3")) {
				currentWeapon = 2;
			//SwitchWeapon(2);
			networkView.RPC ("SwitchWeapon", RPCMode.All,2);
		}
			 
		}
	[RPC]
		void SwitchWeapon(int index) {
			for (int i=0; i < nrWeapons; i++) {
				if (i == index) {
					weapons[i].gameObject.SetActive(true);
				Debug.Log(i);
				} else {
					weapons[i].gameObject.SetActive(false);
				Debug.Log(i);
				}
			}
		}
	}
	
 
		
	 

