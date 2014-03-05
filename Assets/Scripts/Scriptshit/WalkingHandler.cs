using UnityEngine;
using System.Collections;

public class WalkingHandler : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!audio.isPlaying && Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.D)) {
			audio.Play();
			
		}
		if (audio.isPlaying && Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.D)) {
			audio.Stop();
			
		}
	}
}
