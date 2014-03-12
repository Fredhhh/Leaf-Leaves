using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	public GameObject pickableItems;
	public int currentItems;

	// Use this for initialization
	void Start () {

		currentItems = 0;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (currentItems == 3)
		{

		}
	
	}

	void OnTriggerEnter2D (Collider2D c)
	{
		GameObject Fruit = GameObject.FindGameObjectWithTag("Fruit");

		if (c.tag.Equals("Fruit"))
		{
			currentItems = currentItems + 1;
			Destroy (Fruit);
		}
	}


}
