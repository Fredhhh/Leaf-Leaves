using UnityEngine;
using System.Collections;

public class PlayerAnimate : MonoBehaviour {
	Animator anim = new Animator();
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();


	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)){
			if(!Player.isGrounded){
				anim.SetBool("isJumping", true);
				anim.SetBool("isWalking", false);
				anim.SetBool("isIdle", false);
			}
			if(Player.isGrounded){
				anim.SetBool("isWalking", true);
				anim.SetBool("isIdle", false);
				anim.SetBool("isJumping", false);
			}
		}
	
		else if (!Player.isGrounded)
		{
			anim.SetBool("isJumping", true);
			anim.SetBool("isWalking", false);
			anim.SetBool("isIdle", false);
		}

		else {
			anim.SetBool("isIdle", true);
			anim.SetBool("isWalking", false);
			anim.SetBool("isJumping", false);

		}
	}
}
