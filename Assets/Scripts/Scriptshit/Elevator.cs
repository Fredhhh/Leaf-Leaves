using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour
{

		private gamestate state;
		public int floor;
		private float time;
		private float currentY;
		public float floor1Y;
		public float floor2Y;
		public float floor3Y;
		public string direction; 
		public float elevatorSpeed;

		void Start ()
		{
				elevatorSpeed = 5.0f; 
				state = gamestate.Instance; 
				floor = 2; 
				floor1Y = GameObject.Find ("Floor1").transform.position.y; 
				floor2Y = GameObject.Find ("Floor2").transform.position.y; 
				floor3Y = GameObject.Find ("Floor3").transform.position.y; 
				direction = "down"; 

		}
		// Update is called once per frame
		void Update ()
		{

		Debug.Log (floor);
				currentY = this.gameObject.transform.position.y; 
				if (state.normalPerception) {
						if (state.elevatorItemsPlaced.Count < 2) {
								MoveBetweenOneAndTwo (); 
						}
						else{
							MoveBetweenAll();
					}
				}

		}

	void MoveBetweenAll ()
		{
				if (floor == 2 && direction.Equals ("down")) {
						if (time < 0.5) {
								time += Time.deltaTime; 
						} else {
								if (currentY > floor1Y) {
										this.gameObject.transform.Translate (Vector3.down * Time.deltaTime * elevatorSpeed);
								} else {
										floor = 1;
										time = 0;
										direction = "up"; 
								}
						}


				} else if (floor == 1) {
						if (time < 0.5) {
								time += Time.deltaTime; 
						} else {
								if (currentY < floor2Y) {
						this.gameObject.transform.Translate (Vector3.up * Time.deltaTime * elevatorSpeed);
								} else {
										floor = 2;
										time = 0; 
										
								}
						}

				} else if (floor == 2 && direction.Equals ("up")) {
						if (time < 0.5) {
								time += Time.deltaTime; 
						} else {
								if (currentY < floor3Y) {
						this.gameObject.transform.Translate (Vector3.up * Time.deltaTime * elevatorSpeed);
								} else {
										floor = 3;
										time = 0;
										direction = "down"; 
								}
						}
				} else {
						if (time < 0.5) {
								time += Time.deltaTime; 
						} else {
								if (currentY > floor2Y) {
							this.gameObject.transform.Translate (Vector3.down * Time.deltaTime * elevatorSpeed);
								} else {
										floor = 1;
										time = 0;
								}
						}
				}
		}

	void MoveBetweenOneAndTwo(){
		
		if (floor == 2) {
			if (time < 0.5) {
				time += Time.deltaTime; 
			} else {
				if (currentY > floor1Y) {
					this.gameObject.transform.Translate (Vector3.down * Time.deltaTime * 3.3f);
				} else {
					floor = 1;
					time = 0; 
				}
			}
			
			
		} else {
			if (time < 0.5) {
				time += Time.deltaTime; 
			} else {
				if (currentY < floor2Y) {
					this.gameObject.transform.Translate (Vector3.up * Time.deltaTime * 3.3f);
				} else {
					floor = 2;
					time = 0; 
				}
			}
			
		}
	}
}
