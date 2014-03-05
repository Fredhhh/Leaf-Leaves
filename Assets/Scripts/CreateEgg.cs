using UnityEngine;
using System.Collections;

public class CreateEgg : MonoBehaviour {

	public GameObject eggPrefab;
	public GameObject egg;

	// Use this for initialization
	void Start () {
		eggPrefab = GameObject.FindGameObjectWithTag("Egg");
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			egg = Instantiate(eggPrefab, transform.FindGameObjectWithTag("eggSpawn").transform.position, Quaternion.identity);
			egg.tag = "Egg";
		}

	}
}
