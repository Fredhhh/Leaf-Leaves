using UnityEngine;
using System.Collections;

public class LevelCHANGE : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	void OnTriggerEnter2D (Collider2D c)
	{
		if (c.gameObject.name.Equals("LoadLVL1"))
		{
			Application.LoadLevel("Beta1");
		}

		if (c.gameObject.name.Equals("sopp"))
		{
			if (GetComponent<Pickup>().currentHens == 4)
			{
				Application.LoadLevel("Choose_level");
			}

			else 
				Debug.Log("You need to catch all of the stupid turkeys!");
		}
	}
}
