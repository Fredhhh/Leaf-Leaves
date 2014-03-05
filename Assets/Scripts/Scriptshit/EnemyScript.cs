using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	
	public float speed = 1.0f;
	public Animator anim;
	private gamestate state;
	private bool aggressive;
	private bool isAttacking; 
	private bool musicIsPlaying; 

	// Use this for initialization
	void Start () {
		gameObject.layer = 8;
		anim = GetComponent<Animator>();
		state = gamestate.Instance;
		isAttacking = false;
		isAttacking = false;
		musicIsPlaying = false;

	}
	
	// Update is called once per frame
	void Update () {
		if(isAttacking && !musicIsPlaying){
			audio.Play();
			musicIsPlaying = true;
		}

		if (state.normalPerception) {
			aggressive = false;
			gameObject.layer = 9;
			anim.SetBool("Evil", false);
		} else {
			aggressive = true;
			gameObject.layer = 8;

		}

	}



	void OnCollisionEnter2D (Collision2D c) {
		if (aggressive && c.gameObject.tag.Equals ("Player")) {
			state.playerDead = true;

		}
	}

	void OnEnterTrigger2D(Collider2D collider) {
		if(collider.gameObject.tag.Equals("Player") && aggressive) {
			anim.SetBool("Evil", true);
			isAttacking = true;
			var myPos = this.gameObject.transform.position.x;
			var playerPos = collider.gameObject.transform.position.x;
			if(myPos < playerPos) {
				this.gameObject.transform.Translate(Vector3.right * Time.deltaTime);
			} else {
				this.gameObject.transform.Translate(Vector3.left * Time.deltaTime);
			}

		}
	}
	
	void OnTriggerStay2D(Collider2D collider) {
		if(collider.gameObject.tag.Equals("Player") && aggressive) {
			anim.SetBool("Evil", true);
			isAttacking = true;
			var myPos = this.gameObject.transform.position.x;
			var playerPos = collider.gameObject.transform.position.x;
			if(myPos < playerPos) {
				transform.Translate(Vector3.right * Time.deltaTime);
			} else {
				transform.Translate(Vector3.left * Time.deltaTime);
			}
		}
	}
	
	void OnTriggerExit2D(Collider2D collider) {
		if(collider.gameObject.tag.Equals("Player")) {
			anim.SetBool("Evil", false);
			isAttacking = false;
			audio.Stop();
			musicIsPlaying = false;
		}
	}
}