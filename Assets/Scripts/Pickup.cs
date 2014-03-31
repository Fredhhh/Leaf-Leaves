using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	public GameObject spawnPoint;
	public GameObject[] heldItems;
	public GameObject[] heldHens;
	public int currentItems;
	public int currentHens;

	public int i;
	public int d;

	public bool canPickup;

	// Use this for initialization
	void Start () {

		i = 0;
		d = 0;

		currentItems = 0;
		currentHens = 0;

		canPickup = true;

		spawnPoint.transform.position = GameObject.FindGameObjectWithTag("eggSpawn").transform.position;

		heldItems = new GameObject[3]{null, null, null};
		heldHens = new GameObject[4]{null, null, null, null};
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.J))
		{
			foreach (GameObject Fruit in GameObject.FindGameObjectsWithTag("Fruit"))
			{

				Fruit.gameObject.renderer.enabled = true;
				Fruit.gameObject.collider2D.enabled = true;

				currentItems = 0;
				i = 0;
				heldItems = new GameObject[3]{null, null, null};

				//GameObject F = (GameObject)Instantiate(Fruit, spawnPoint.transform.position, Quaternion.identity);
				//F.transform.position = spawnPoint.transform.position;
			}

		}

		if (currentItems == 3)
		{
			canPickup = false;
		}

		if (currentItems < 3)
		{
			canPickup = true;
		}
	
	}
	

	void OnTriggerEnter2D (Collider2D c)
	{

				if (canPickup) {

						foreach (GameObject Fruit in GameObject.FindGameObjectsWithTag("Fruit")) {

								if (c.gameObject == Fruit) {
										heldItems [i] = Fruit.gameObject; 
										Fruit.gameObject.renderer.enabled = false;
										Fruit.gameObject.collider2D.enabled = false;

										currentItems++;
										i++;

								}
						}

						foreach (GameObject Hen in GameObject.FindGameObjectsWithTag("Hen")) {
							
							if (c.gameObject == Hen) {
								heldHens [d] = Hen.gameObject; 
								Hen.gameObject.renderer.enabled = false;
								Hen.gameObject.collider2D.enabled = false;
								//FJERN ALLE COLLIDERE
								
								currentHens++;
								d++;
							}
					}
				} 

				if (c.tag.Equals ("Basket")) {
						if (i == 3) 
								{
								if (heldItems [0].name.Equals ("FruitPurple") && heldItems [1].name.Equals ("FruitPurple") && heldItems [2].name.Equals ("FruitYellow")) {
										Debug.Log ("YES, BASKET COMPLETED!");
								} 
									else 
										Debug.Log ("Wrong fruit!");
								}
							else 
						{
						Debug.Log ("Complete the basket!");
						}
				}		

		}



} 

