using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

	bool hitSpikes;
	public GameObject[] spawnPoint;

	//public GameObject spawnPoint;

		

		// Use this for initialization
		void Start () {

		hitSpikes = false;

		spawnPoint = new GameObject[2]{GameObject.FindGameObjectWithTag("Spawning"),GameObject.FindGameObjectWithTag("Spawning2")};

		//spawnPoint = GameObject.FindGameObjectsWithTag("Spawning");

		}

		// Update is called once per frame
		void Update () {


	
	}

		void OnTriggerEnter2D(Collider2D collider)
		{

			if (collider.tag.Equals("Death"))
			{
				hitSpikes = true;
				Debug.Log("RESPAWN!");

			for (var i=0; i < spawnPoint.Length; i+=0)
				{
					gameObject.transform.position = spawnPoint[0].transform.position;
					Debug.Log ("HIT");
				}
				
			}
	
			hitSpikes = false;
		}


	}
