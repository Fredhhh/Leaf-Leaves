using UnityEngine;
using System.Collections;
//[RequireComponent(typeof(GroundedScript))]

public class PlayerMovement : MonoBehaviour {
	public float speed = 4.0f;
	public float inSpeed = 4.0f;
	public bool facingRight;
	public float jumpHeight = 300;
	public float ray1 = 1f;
	public bool isGrounded;
	//public bool isGrounded;
	
	
	
	
	// Update is called once per frame
	void Start (){
		facingRight = true;
		isGrounded = false;
		
		
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
		
		
		if (Input.GetButtonDown("Jump") && isGrounded) {
			//transform.Translate (Vector3.up * jumpheight * speed * Time.deltaTime);
			this.gameObject.rigidbody2D.AddForce (Vector3.up * jumpHeight);
			//isGrounded = false;
			
		}
		
	}
	
	void OnTriggerEnter2D (Collider2D c)
	{
		if (c.gameObject.tag.Equals ("Ground")||c.gameObject.tag.Equals ("Egg")||c.gameObject.tag.Equals ("Hen"))
		{
			isGrounded = true;
		}
		
		else
			
			isGrounded = false;
		
	}
	void OnTriggerExit2D (Collider2D u)
	{
		if (u.gameObject.tag.Equals ("Ground")||u.gameObject.tag.Equals ("Egg")||u.gameObject.tag.Equals("Hen"))
		{
			isGrounded = false;
		}


		if (u.gameObject.tag.Equals("Basket"))
		{
			isGrounded = true;
		}
	}
	
	
	
	/*void OnCollisionEnter2D (Collision2D c)
	{

	}*/
}
