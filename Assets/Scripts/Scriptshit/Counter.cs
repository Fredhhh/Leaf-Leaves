using UnityEngine;
using System.Collections;

public class Counter : MonoBehaviour {

	private gamestate state;
	public float timeLeft;

	// Use this for initialization
	void Start () {
		state = gamestate.Instance;
		state.normalPerception = false;
		timeLeft = 10;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.W))
		{
			if(!state.normalPerception && timeLeft >= 10) {
				state.normalPerception = true; 
				//this.gameObject.guiText.enabled = true;
			} else if(state.normalPerception) {
				state.normalPerception = false;
			}
		}
		if (state.normalPerception) {
			if (timeLeft <= 0) {
				state.normalPerception = false;
			} else {
				timeLeft -= Time.deltaTime;
			}
		} else {
			//Debug.Log ("Inside count upwards");
			if (timeLeft < 10) {
					timeLeft += Time.deltaTime;
			}
	}
		this.gameObject.guiText.text = Mathf.Round(timeLeft).ToString (); 
	}
}
