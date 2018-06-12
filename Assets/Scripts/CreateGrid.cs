using UnityEngine;
using System.Collections;


public class CreateGrid : MonoBehaviour {
	public int team = 0 ;
	public GameObject block1; 
//	public GameObject walln;
//	public GameObject wallw;
//	public GameObject walle;
//	public GameObject walls;
	public int worldWidth  = 250;
	public int worldHeight  = 250;

	public float[,] randomLift;



	public float spawnSpeed = 0;

	 void  Start () {

		//StartCoroutine(CreateWorld());
		CreateWorld ();
	}
	
	 void CreateWorld () {
		
		randomLift = new float[worldWidth, worldHeight];
		
		
		
		randomLift[0, 0] = 0;
		
		int upordown;
		
		for (int x = 1; x < worldWidth; x++)
		{
			upordown =  Random.Range(-1,2);
			
			randomLift[x, 0] = randomLift[x-1,0] + upordown;
			
		}
		
		for (int x = 1; x < worldHeight; x++)
		{
			upordown =  Random.Range(-1,2);
			
			randomLift[0, x] = randomLift[0,x-1] + upordown;
			
		}
		
		for (int x = 1; x < worldWidth ; x++) {
			for (int y = 1; y < worldHeight ; y++) {
				
				do {
					
					upordown = Random.Range(-1,2);
					
					randomLift[x,y] = randomLift[x-1,y] + upordown;
					
					if ((randomLift[x,y]-randomLift[x,y-1] <= 1)&&(randomLift[x,y]-randomLift[x,y-1] >=-1)) {
						
						break;
						
					}
				} while (true);
				
				
			}
			
		}
		
		for(int x = 0; x < worldWidth; x++) {
			//yield return new WaitForSeconds(spawnSpeed);
			
			for(int z = 0; z < worldHeight; z++) {                
				//yield return new WaitForSeconds(spawnSpeed);
				
				//random = new Random();

				
				
				GameObject block = Network.Instantiate(block1, Vector3.zero, block1.transform.rotation, 0) as GameObject;
				//block.transform.parent = transform;
				block.transform.localPosition = new Vector3(x, randomLift[x, z]/2, z);
				
			}
		}
	}

}