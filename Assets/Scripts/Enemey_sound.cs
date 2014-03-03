using UnityEngine;
using System.Collections;

public class Enemey_sound : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	


	}

	void OnTriggerEnter (Collider p)
	{
		if (p.gameObject.tag.Equals ("Player"))
		{
			audio.Play();
		}
	}
}
