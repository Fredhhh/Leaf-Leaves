using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

		public bool hitSpikes = false;
		public GameObject spawnPoint = GameObject.FindGameObjectWithTag("Spawning");

		// Use this for initialization
		void Start () {

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
			}

			hitSpikes = false;
		}


	}
