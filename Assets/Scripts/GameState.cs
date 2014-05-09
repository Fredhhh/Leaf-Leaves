using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	public Transform PlayerPrefab;
	public Transform CameraPrefab;

	// Use this for initialization
	void Start () {

		if (!(GameObject.FindWithTag("Player")))
		{
			Instantiate (PlayerPrefab, transform.position, transform.rotation);
		}

		if (!(GameObject.FindWithTag("MainCamera")))
		{
			Instantiate (CameraPrefab, transform.position, transform.rotation);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
