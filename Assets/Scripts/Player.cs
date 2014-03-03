using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
		public float speed = 4.0f;
		public float inSpeed = 4.0f;
		public static bool isGrounded;
		public bool facingRight;

		//Inventory 
		public GameObject currentItem;
		public GameObject pickableItem;
	
		// Pick up sounds
		public AudioClip pickUpSound1;
		public AudioClip pickUpSound2;
		public AudioClip pickUpSound3;
		public AudioClip pickUpSound4;
		//gamestate
		private gamestate state;

		// Update is called once per frame
		void Start ()
		{
				gameObject.layer = 8;
				facingRight = true;
				state = gamestate.Instance;

		
		}

		void Update ()
		{
		if (Input.GetKey (KeyCode.Escape)) {
			Application.LoadLevel (0);
		}

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

				if (Input.GetKey (KeyCode.Space) && isGrounded == true) {
						this.gameObject.rigidbody2D.AddForce (Vector3.up * 300);			
						isGrounded = false;
				}

				if (Input.GetKeyDown (KeyCode.E)) {
						if (currentItem == null && pickableItem != null) {
								currentItem = pickableItem; 
								pickableItem = null; 
								audio.PlayOneShot (pickUpSound1);
								Vector3 newPos = currentItem.transform.position;
								newPos.y = -1000;
								currentItem.transform.position = newPos; 
								GameObject.Find ("ItemText").GetComponent<GUIText> ().guiText.text = "Item: " + currentItem.name;
						} else if (currentItem != null) {
								audio.PlayOneShot (pickUpSound4);
								Vector3 newPos = this.gameObject.transform.position;
								if (facingRight) {
										newPos.x += 2;
								} else {
										newPos.x -= 2; 
								}
								currentItem.transform.position = newPos;
								currentItem = null;
								GameObject.Find ("ItemText").GetComponent<GUIText> ().guiText.text = "Item: ";
						}
				}
		}
	
		void OnCollisionEnter2D (Collision2D c)
		{
				if (c.gameObject.name.Equals ("FallTrigger")) {
						state.playerDead = true;

				}
				if (c.gameObject.tag.Equals ("Ground")) {
						isGrounded = true;
				}
				if (c.gameObject.tag.Equals ("Item")) {
						isGrounded = true;
				}
				if (c.gameObject.name.Equals ("doorExit")) {
						Application.LoadLevel (Application.loadedLevel); // Should reflect the current level
				}
		}

		
	
	
	
	
}
