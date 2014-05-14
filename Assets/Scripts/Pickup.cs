using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	public GameObject spawnPoint;
	public GameObject[] heldItems;
	public int currentItems;
	public int currentHens;
	public int lvl;

	public bool canPickup;
	public bool fruitIsCorrect;

	// Use this for initialization
	void Start () {

		currentItems = 0;
		currentHens = 0;

		canPickup = true;

		spawnPoint.transform.position = GameObject.FindGameObjectWithTag("eggSpawn").transform.position;

		heldItems = new GameObject[3]{null, null, null};

		fruitIsCorrect = false;
	
	}
	
	// i Update sjekker vi om karakteren har plukket opp for mye eller for lite frukt for å definere når man kan plukke opp mer
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

	void OnLevelWasLoaded (int level){
		lvl = level;
	}

	void OnTriggerEnter2D (Collider2D c)
	{

				if (canPickup) {

						//i denne loopen sjekker vi hver frukt som karakteren plukker opp
						foreach (GameObject Fruit in GameObject.FindGameObjectsWithTag("Fruit")) {

								//for hvert objekt karakteren er borti som er en frukt, rendres(vises) ikke den frukten, og antallet objekter karakteren har - stiger
								if (c.gameObject == Fruit) {
										heldItems [currentItems] = Fruit.gameObject; 
										Fruit.gameObject.renderer.enabled = false;
										Fruit.gameObject.collider2D.enabled = false;

										currentItems++;

								}
						}
						//i denne loopen sjekker vi hver kalkun som karakteren plukker opp
						foreach (GameObject Hen in GameObject.FindGameObjectsWithTag("Hen")) {
							
							//for hvert objekt karakteren er borti som er en kalkun, forsvinner kalkunen og antallet kalkuner man har plukket opp stiger
							if (c.gameObject == Hen) {
							
								Destroy (Hen);
								
								currentHens++;
								
							}
					}
				} 
		if (lvl == 0)
		{
			if (c.tag.Equals ("sopp"))
			{
				Debug.Log("Hello there, Leaf! Jump with space and lay your eggs with shift when air-born to catch my turkeys!");
			}

			if (c.tag.Equals ("marsvin"))
			{
				Debug.Log("Oh! Hurry, we need to get some fruit!");
			}

			if (c.tag.Equals ("laks"))
			{
				Debug.Log ("This is the final trial, please, Leaf, leave the forest!");
			}
		}


		if (lvl == 1)
		{

		if (c.name.Equals ("sopp"))
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

						if (currentItems == 3) 
								{
								//hvis karakteren har fylt opp fruktarrayet heldItems, og navnene stemmer i koden og i spillet skal man få beskjed om at det er riktig frukt
								if (heldItems [0].name.Equals ("cherry") && heldItems [1].name.Equals ("plum") && heldItems [2].name.Equals ("melon")) {
									Debug.Log ("These are the right fruits!");
									fruitIsCorrect = true;
								} 
									
								//hver gang karakteren er borti marsvinets kollisjonsdetektor og har tre frukter, vil fruktene automatisk dukke opp igjen på trærne,
								//slik at karakteren kan hente de riktige om frukten var feil
								foreach (GameObject Fruit in GameObject.FindGameObjectsWithTag("Fruit"))
								{
									Fruit.gameObject.renderer.enabled = true;
									Fruit.gameObject.collider2D.enabled = true;
									
									//hvis frukten er feil når karakteren er borte ved marsvinet blir fruktinformasjonen nullstilt, og karakteren kan fylle opp igjen fruktarrayet
									if (fruitIsCorrect == false && currentItems == 3)
										{
											currentItems = 0;
											
											heldItems = new GameObject[3]{null, null, null};

											Debug.Log ("No, that's wrong, I said cherry, plum and melon!");
										}

				
								}

				
									if (fruitIsCorrect == false && currentItems > 0)
									{
										Debug.Log ("I said cherry, plum and melon, you need all of the fruits!");
									}
					
								}
						else
						{
							Debug.Log ("You can only pick three fruits at the time. A cherry, a plum and a melon, and in the right order!");
						}
					}
				}

			if (c.gameObject.name.Equals("WinPeople"))
		    {
			Debug.Log("Leaf left!!");
			}
					
		}
	
} 

