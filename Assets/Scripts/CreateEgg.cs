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
	//I Start definerer vi spillobjektet spawnPoint, som er objektet eggene skal spawne fra
	void Start () {
		spawnPoint.transform.position = GameObject.FindGameObjectWithTag("eggSpawn").transform.position;
		player = GameObject.FindGameObjectWithTag("Player");

		eggCount = 0;
		currentTime = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//her er forskjellige funksjoner for når karakteren kan legge egg og ikke
		if (GetComponent<PlayerMovement>().isGrounded == true||player.tag.Equals("Egg") == true)
		{
			canPlace = false;
		}

		else if (eggCount<7)
		{
			canPlace = true;
		}

		//en funksjon for når karakteren presser knapper for å legge ut egg
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

		//hvis det er mer eller lik 7 egg på banen, kan ikke karakteren legge ut fler
		if (eggCount>=7)
		{
			canPlace = false;

			foreach (GameObject gO in GameObject.FindGameObjectsWithTag("Egg")) 
			{
				compareTime = gO.GetComponent<EggDestroy>().getTime();

				if (currentTime>5)
				{
					currentTime = 0;
					compareTime = 0;
				}

				if (compareTime>currentTime)
				{
					currentTime = compareTime;
					Destroy (gO);
					eggCount--;
					
				}
				
			}


		}

	}

}
