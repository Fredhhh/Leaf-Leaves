using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

	public bool hitSpikes;
	public GameObject[] spawnPoint;

	public int i;

	//public GameObject spawnPoint;

		

		// Use this for initialization
		void Start () {

		i = 0;

		hitSpikes = false;

		spawnPoint = new GameObject[3]{null	, null , null};

		//spawnPoint = GameObject.FindGameObjectsWithTag("Spawning");

		}

		// Update is called once per frame
		void Update () 
		{


		
	
		}

	void OnLevelWasLoaded (int level)
	{
		Debug.Log(level);

		if(level == 0)

		foreach (GameObject Spawn in GameObject.FindGameObjectsWithTag("Spawning")) {

		
			{

				if (GetComponent<LevelCHANGE>().chooseLevel == true)
				{
				Debug.Log (i);
				spawnPoint [i] = Spawn.gameObject; 

				gameObject.transform.position = spawnPoint[i].transform.position;
				
				GetComponent<LevelCHANGE>().chooseLevel = false;
				i++;
				}
	
				
				}

			
			
	}

		//void OnTriggerEnter2D(Collider2D collider)
		//{

		
		//}


	}
	
}
