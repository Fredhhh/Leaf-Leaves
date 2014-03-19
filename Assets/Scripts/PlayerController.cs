using UnityEngine;
using System.Collections;
//[RequireComponent(typeof(PlayerPhysics))]


public class PlayerController : MonoBehaviour {

	// Player Handling
	public float gravity = 20;
	public float speed = 8;
	public float acceleration = 30;
	public float jumpHeight = 12;
	
	private float currentSpeed;
	private float targetSpeed;
	private Vector2 amountToMove;
	
	//private PlayerPhysics playerPhysics;

	public bool grounded;
	

	void Start () {
		//playerPhysics = GetComponent<PlayerPhysics>();
		grounded = false;
	}
	
	void Update () {


		targetSpeed = Input.GetAxisRaw("Horizontal") * speed;
		currentSpeed = IncrementTowards(currentSpeed, targetSpeed,acceleration);
		
		if (grounded) {
			amountToMove.y = 0;
			
			//Jump
			if (Input.GetButtonDown("Jump")) {
				amountToMove.y = jumpHeight;
				grounded=false;
			}
		}
		amountToMove.x = currentSpeed;
		amountToMove.y -= gravity * Time.deltaTime;
		Move (amountToMove * Time.deltaTime);
	}
	
	// Increase n towards target by speed
	private float IncrementTowards(float n, float target, float a) {
		if (n == target) {
			return n;	
		}
		else {
			float dir = Mathf.Sign(target - n); // must n be increased or decreased to get closer to target
			n += a * Time.deltaTime * dir;
			return (dir == Mathf.Sign(target-n))? n: target; // if n has now passed target then return target, otherwise return n
		}
	}

	void OnCollisionEnter2D (Collision2D c)
	{
		
		//if (c.gameObject.name.Equals ("FallTrigger")) {
		//state.playerDead = true;
		
		//}
		if (c.gameObject.tag.Equals ("Ground")) {
			grounded = true;
			//Debug.Log("GROUNDED!");	
		} 

		
		/*if (c.gameObject.name.Equals ("doorExit")) {
			Application.LoadLevel (Application.loadedLevel); // Should reflect the current level
		}*/
	}
    public void Move(Vector2 moveAmount) {
				float deltaY = moveAmount.y;
				float deltaX = moveAmount.x;
				//Vector2 p = transform.position;
				//transform.Translate(moveAmount);
				Vector2 finalTransform = new Vector2 (deltaX, deltaY);
		
				transform.Translate (finalTransform);
		}
}
