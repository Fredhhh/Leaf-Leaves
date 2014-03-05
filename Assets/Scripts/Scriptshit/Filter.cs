using UnityEngine;
using System.Collections;

public class Filter : MonoBehaviour


{
	
	public float timeLeft;

	public AudioClip audio1;
	public AudioClip audio2;

	private gamestate state;

	void Start() {
		state = gamestate.Instance;
	}

	// Update is called once per frame
	void Update ()
	{


		if (state.normalPerception) {
			this.gameObject.renderer.enabled = false;
		} else {
			this.gameObject.renderer.enabled = true;
		}

	}
	
}

