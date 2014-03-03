using UnityEngine;
using System.Collections;
[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : MonoBehaviour {

	// Player Handling
	public float gravity = 20;
	public float speed = 8;
	public float acceleration = 30;
	public float jumpHeight = 12;
	
	private float currentSpeed;
	private float targetSpeed;
	private Vector2 amountToMove;
	
	private PlayerPhysics playerPhysics;

	[HideInInspector]
	public bool grounded;
	
	void Start () {
		playerPhysics = GetComponent<PlayerPhysics>();
	}
	
	void Update () {
		//grounded = false;
		targetSpeed = Input.GetAxisRaw("Horizontal") * speed;
		currentSpeed = IncrementTowards(currentSpeed, targetSpeed,acceleration);
		
		if (grounded==true) {
			amountToMove.y = 0;
			
			//Jump
			if (Input.GetButtonDown("Jump")) {
				amountToMove.y = jumpHeight;	
			}
		}
		amountToMove.x = currentSpeed;
		amountToMove.y -= gravity * Time.deltaTime;
		playerPhysics.Move (amountToMove * Time.deltaTime);
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
				} 
		if (c.gameObject.tag.Equals ("Item")) {
						grounded = true;
				}
	

		if (c.gameObject.name.Equals ("doorExit")) {
			Application.LoadLevel (Application.loadedLevel); // Should reflect the current level
		}
	}

}
