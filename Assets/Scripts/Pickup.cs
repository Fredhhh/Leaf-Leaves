using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	public GameObject spawnPoint;
	public GameObject[] heldItems;
	//public GameObject[] heldHens;
	public int currentItems;
	public int currentHens;
	public int lvl;

	public int i;
	//public int d;

	public bool canPickup;
	public bool fruitIsCorrect;

	// Use this for initialization
	void Start () {

		lvl = GetComponent<LevelCHANGE>().lvl;

		i = 0;

		currentItems = 0;
		currentHens = 0;

		canPickup = true;

		spawnPoint.transform.position = GameObject.FindGameObjectWithTag("eggSpawn").transform.position;

		heldItems = new GameObject[3]{null, null, null};

		fruitIsCorrect = false;
	
	}
	
	// Update is called once per frame
	void Update () {


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
							
								Destroy (Hen);
								
								currentHens++;
								
							}
					}
				} 

		if (lvl == 1)
		{

		if (c.name.Equals ("Sopp"))
			{

				if (currentHens < 4)
				{
					Debug.Log("You need to catch all of the stupid turkeys!");
				}
			}
		}


			if (lvl == 2)
			{
				if (c.tag.Equals ("marsvin")) {
						if (i == 3) 
								{
								if (heldItems [0].name.Equals ("cherry") && heldItems [1].name.Equals ("plum") && heldItems [2].name.Equals ("melon")) {
									Debug.Log ("These are the right fruits!");
									fruitIsCorrect = true;
								} 
									
									foreach (GameObject Fruit in GameObject.FindGameObjectsWithTag("Fruit"))
									{
										
										Fruit.gameObject.renderer.enabled = true;
										Fruit.gameObject.collider2D.enabled = true;
										
										if (fruitIsCorrect == false && i == 3)
											{
												Debug.Log ("No, that's wrong, I said cherry, plum and melon!");
											}

										currentItems = 0;
										i = 0;
										heldItems = new GameObject[3]{null, null, null};
										
										//GameObject F = (GameObject)Instantiate(Fruit, spawnPoint.transform.position, Quaternion.identity);
										//F.transform.position = spawnPoint.transform.position;
									}

				
									if (fruitIsCorrect == false && i > 0)
									{
										Debug.Log ("I said cherry, plum and melon, you need all of the fruits!");
									}
					
								}
						else
						{
							Debug.Log ("Please pick three fruits. A cherry, a plum and a melon!");
						}
					}
				}
					
		}
	
} 

