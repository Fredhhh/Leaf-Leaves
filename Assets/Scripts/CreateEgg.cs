using UnityEngine;
using System.Collections;

public class CreateEgg : MonoBehaviour {

	public GameObject eggPrefab;
	public GameObject spawnPoint;
	public GameObject player;

	// Use this for initialization
	void Start () {
		spawnPoint.transform.position = GameObject.FindGameObjectWithTag("eggSpawn").transform.position;
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			GameObject egg = (GameObject)Instantiate(eggPrefab, spawnPoint.transform.position, Quaternion.identity);
			egg.transform.position = spawnPoint.transform.position;
		}

	}
}
