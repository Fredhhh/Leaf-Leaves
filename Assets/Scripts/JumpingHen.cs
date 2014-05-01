using UnityEngine;
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
		jumpHeightHen = Random.Range(30 , 80);
	
	}
	
	// Update is called once per frame
	void Update () {


		if (transform.position.y > 10 && transform.position.y < 18)
		{
			HenisGrounded = false;

		}

		if (transform.position.x > 22 && transform.position.x < 28)
		{
			left = true;

		}

		if (transform.position.x > 1 && transform.position.x < 7)
		{
			left = false;
		}

		if (left)
		{
			transform.Translate (Vector3.left * henSpeed * Time.deltaTime);
			gameObject.transform.localScale = new Vector3 (0.15f, 0.15f, 0.15f);
		}


		else
		{
			transform.Translate (Vector3.right * henSpeed * Time.deltaTime);
			gameObject.transform.localScale = new Vector3 (-0.15f, 0.15f, 0.15f);
		}


		if (HenisGrounded == true)
		{
			this.gameObject.rigidbody2D.AddForce (Vector3.up * jumpHeightHen);
		}

	}


	void OnTriggerEnter2D (Collider2D c)
	{


		if (c.gameObject.tag.Equals ("Ground"))
		{
			HenisGrounded = true;
		}

		if (c.gameObject.tag.Equals ("Egg")||c.gameObject.tag.Equals("Hen"))
		{
			HenisGrounded = false;
		}

		//else
			
			//HenisGrounded = false;

		if (c.gameObject.tag.Equals ("Player")&&c.gameObject.tag.Equals ("Ground"))
		{
			HenisGrounded = true;
		}


		if (c.gameObject.name.Equals ("LeftTrig"))
		{
			jumpHeightHen = Random.Range(150 , 200);
			henSpeed = 5;
			left = true;
		}

		if (c.gameObject.name.Equals ("RightTrig"))
		{
			jumpHeightHen = Random.Range(150 , 200);
			henSpeed = 5;
			left = false;
		}


	}


	void OnTriggerExit2D (Collider2D u)
	{
		if (u.gameObject.tag.Equals ("Ground")||u.gameObject.tag.Equals ("Egg")||u.gameObject.tag.Equals("Hen")||u.gameObject.name.Equals("LeftTrig")||u.gameObject.name.Equals("RightTrig")||u.gameObject.tag.Equals("Player"))
		{
			HenisGrounded = false;
			jumpHeightHen = Random.Range(30 , 80);
			henSpeed = 2;
		}
	}
	


}
