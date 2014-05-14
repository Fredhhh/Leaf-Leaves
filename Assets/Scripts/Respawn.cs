using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

	public bool hitSpikes;
	public GameObject[] spawnPoint;
	public GameObject SpawnLVL3;

	public int i;

	//public GameObject spawnPoint;

		

		// Use this for initialization
		void Start () {

		i = 0;

		hitSpikes = false;

		spawnPoint = new GameObject[3]{null	, null , null};

		}


		// Update is called once per frame
		void Update () 
		{
			//hvis karakteren har gjort booleanen hitSpikes sann, får man et nytt startpunkt
			if (hitSpikes == true)
			{
			gameObject.transform.position = SpawnLVL3.transform.position;
			hitSpikes = false;
			}

		}

	void OnLevelWasLoaded (int level)
	{

		//vi bruker loopen for å se på alle spawn-stedene vi har
		foreach (GameObject Spawn in GameObject.FindGameObjectsWithTag("Spawning")) {

			if(level == 0)
			{

				//hvis vi laster inn level 0, og booleanen chooseLevel er sann, skal spilleren starte ved Spawn Point [0],
				//og neste gang spilleren kommer inn i level 0, skal man starte ved Spawn point [1] osv.
				if (GetComponent<LevelCHANGE>().chooseLevel == true) {

					Debug.Log (i);
					spawnPoint [i] = Spawn.gameObject; 
					
					gameObject.transform.position = spawnPoint[i].transform.position;

					i++;
					GetComponent<LevelCHANGE>().chooseLevel = false;
				}
			}	

		}
	}

	//en kollisjonsfunksjon som ser når du treffer "Death", som da gjør booleanen hitSpikes sann
	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.tag.Equals("Death"))
		{
			hitSpikes = true;
		}
	}
}
