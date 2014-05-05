using UnityEngine;
using System.Collections;

public class CreateEgg : MonoBehaviour {

	public GameObject eggPrefab;
	public GameObject spawnPoint;
	public GameObject player;
	public int eggCount;
	public float currentTime;
	public float compareTime;

	public bool canPlace;

	// Use this for initialization
	void Start () {
		spawnPoint.transform.position = GameObject.FindGameObjectWithTag("eggSpawn").transform.position;
		player = GameObject.FindGameObjectWithTag("Player");

		eggCount = 0;
		currentTime = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (GetComponent<PlayerMovement>().isGrounded == true||player.tag.Equals("Egg") == true)
		{
			canPlace = false;
		}

		else if (eggCount<6)
		{
			canPlace = true;
		}

		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			if (canPlace==true)
			{

				GameObject egg = (GameObject)Instantiate(eggPrefab, spawnPoint.transform.position, Quaternion.identity);
				egg.transform.position = spawnPoint.transform.position;

				eggCount++;
			}
		}

		destroyEgg();



	} //update



	void destroyEgg (){

		if (eggCount>=6)
		{
			canPlace = false;

			foreach (GameObject gO in GameObject.FindGameObjectsWithTag("Egg")) 
			{
				
				compareTime = gO.GetComponent<EggDestroy>().getTime();
				
				if (compareTime>currentTime)
				{
					
					currentTime = compareTime;
					Destroy (gO);
					eggCount--;

					Debug.Log ("tahoi");
					
				}
				
			}


		}

	/*	if (eggCount<6)
		{
			canPlace = true;
		}
		*/


	}

}
