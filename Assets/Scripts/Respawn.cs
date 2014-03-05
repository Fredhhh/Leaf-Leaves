using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

	bool hitSpikes;
	public GameObject spawnPoint;

		

		// Use this for initialization
		void Start () {
		hitSpikes = false;
		spawnPoint = GameObject.FindGameObjectWithTag("Spawning");

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
			}
	
	
			if (hitSpikes==true)
			{
				gameObject.transform.position = spawnPoint.transform.position;
			Debug.Log ("HIT");
			}

			hitSpikes = false;
		}


	}
