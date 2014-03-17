using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	public GameObject spawnPoint;
	public GameObject[] heldItems;
	public int currentItems;

	public int i;

	public bool canPickup;

	// Use this for initialization
	void Start () {

		i = 0;

		canPickup = true;

		spawnPoint.transform.position = GameObject.FindGameObjectWithTag("eggSpawn").transform.position;

		currentItems = 0;
		heldItems = new GameObject[3]{null, null, null};

	
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

		if (canPickup)
		{

			foreach (GameObject Fruit in GameObject.FindGameObjectsWithTag("Fruit"))
			{

				if (c.gameObject == Fruit)
				{
					heldItems[i] = Fruit.gameObject; 
					Fruit.gameObject.renderer.enabled = false;
					Fruit.gameObject.collider2D.enabled = false;

					currentItems = currentItems + 1;
					i++;

					if (Fruit.name.Equals("Red"))
					{
						Debug.Log("RED");
					}

				}

			
			}

		} 

	} 



}
