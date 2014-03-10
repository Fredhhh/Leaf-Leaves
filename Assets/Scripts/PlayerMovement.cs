using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float speed = 4.0f;
	public float inSpeed = 4.0f;
	public bool facingRight;
	public bool isGrounded;
	public float jumpHeight = 300;


	// Update is called once per frame
	void Start (){
		facingRight = true;

	}
	void Update () {

				if (Input.GetKey (KeyCode.D)) {
						transform.Translate (Vector3.right * speed * Time.deltaTime);

						if (facingRight == false) {
								facingRight = true;
				
								gameObject.transform.localScale = new Vector3 (1, 1, 1);
				
						}
				}

				if (Input.GetKey (KeyCode.A)) {
						transform.Translate (Vector3.left * speed * Time.deltaTime);


						if (facingRight == true) {
								facingRight = false;
			
								gameObject.transform.localScale = new Vector3 (-1, 1, 1);                             
						}

				}
				if (Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.D)) {
				} 
				else {
						if (Input.GetKey (KeyCode.Space) && isGrounded) {
								//transform.Translate (Vector3.up * jumpheight * speed * Time.deltaTime);
								this.gameObject.rigidbody2D.AddForce (Vector3.up * jumpHeight);
								isGrounded = false;
						}
				}
				

		}
		//Debug.Log (isGrounded);
		


	void OnCollisionEnter2D (Collision2D c)
	{
		if (c.gameObject.tag.Equals ("Ground"))
		{
			isGrounded = true;
		}
		if (c.gameObject.tag.Equals ("Item")) {
			isGrounded = true;
		}
	}




}
