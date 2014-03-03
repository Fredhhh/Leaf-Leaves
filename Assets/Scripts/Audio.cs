using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour {

	public AudioClip filterOn;
	public AudioClip filterOff; 
	public AudioClip enemyNearby; 

	public AudioClip currentClip; 
	public bool enemyClipPlaying; 

	private gamestate state;


	// Use this for initialization
	void Start () {
		state = gamestate.Instance; 
		audio.clip = filterOn; 
		audio.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!state.normalPerception) {
			if(currentClip != enemyNearby && currentClip != filterOn) {
				Debug.Log ("Filter on");
				audio.Stop (); 
				audio.clip = filterOn;
				currentClip = filterOn;
				audio.Play ();
			}
		} else if (state.normalPerception && currentClip != filterOff) {
			Debug.Log ("Filter off");
			audio.Stop (); 
			audio.clip = filterOff;
			currentClip = filterOff;
			audio.Play ();
		}
	}
	

	void OnTriggerEnter2D(Collider2D c){
		if (c.gameObject.tag == "Enemy") {
			if(currentClip != enemyNearby){
				Debug.Log ("ENEEEEMY");
				audio.Stop(); 
				audio.clip = enemyNearby; 
				currentClip = enemyNearby;
				audio.Play ();
			}
		}
	}

	void OnTriggerExit2D(Collider2D c){
		if (c.gameObject.tag == "Enemy") {
			if(currentClip == enemyNearby){
				Debug.Log ("ENEEEEMY");
				audio.Stop(); 
				audio.clip = filterOn;
				currentClip = filterOn;
				audio.Play (); 
			}
		}
	}
}
