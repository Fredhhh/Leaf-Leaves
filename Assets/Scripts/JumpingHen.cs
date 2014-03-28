﻿using UnityEngine;
using System.Collections;

public class JumpingHen : MonoBehaviour {

	public float jumpHeightHen;
	public bool HenisGrounded;
	public float henSpeed;
	public bool left;
	public bool leftTrigBool;

	// Use this for initialization
	void Start () {

		henSpeed = 2;
		left = true;
		leftTrigBool = false;
	
	}
	
	// Update is called once per frame
	void Update () {

		jumpHeightHen = Random.Range(50 , 100);



		if (transform.position.x > 22 && transform.position.x < 28)
		{
			left = true;
		}

		if (transform.position.x > 5 && transform.position.x < 10)
		{
			left = false;
		}

		if (left)
		{
			transform.Translate (Vector3.left * henSpeed * Time.deltaTime);
		}


		else
		{
			transform.Translate (Vector3.right * henSpeed * Time.deltaTime);
		}


		if (HenisGrounded == true)
		{
			this.gameObject.rigidbody2D.AddForce (Vector3.up * jumpHeightHen);
		}
	
	}


	void OnTriggerEnter2D (Collider2D c)
	{


		if (c.gameObject.tag.Equals ("Ground")||c.gameObject.tag.Equals ("Egg"))
		{
			HenisGrounded = true;
		}

		//else
			
			//HenisGrounded = false;

		if (c.gameObject.tag.Equals ("Player")&&c.gameObject.tag.Equals ("Ground"))
		{
			HenisGrounded = true;
		}


		if (c.gameObject.name.Equals ("LeftTrig"))
		{
			jumpHeightHen = Random.Range(120 , 180);
			henSpeed = 4;
			left = true;
		}

		if (c.gameObject.name.Equals ("RightTrig"))
		{
			jumpHeightHen = Random.Range(120 , 180);
			henSpeed = 4;
			left = false;
		}


	}


	void OnTriggerExit2D (Collider2D u)
	{
		if (u.gameObject.tag.Equals ("Ground")||u.gameObject.tag.Equals ("Egg")||u.gameObject.name.Equals("LeftTrig")||u.gameObject.name.Equals("RightTrig"))
		{
			HenisGrounded = false;
			jumpHeightHen = Random.Range(50 , 100);
			henSpeed = 2;
		}
	}
	


}
