using UnityEngine;
using System.Collections;

public class LevelCHANGE : MonoBehaviour {

	public bool chooseLevel;
	public int lvl;

	public GameObject Marsvin;
	public GameObject Sopp;
	public GameObject Laks;

	public GameObject Egg;

	// Use this for initialization
	void Start () {

		chooseLevel = false;


	}
	
	// Update is called once per frame
	void Update () {

		Marsvin = GameObject.FindGameObjectWithTag("marsvin");
		Sopp = GameObject.FindGameObjectWithTag("sopp");
		Laks = GameObject.FindGameObjectWithTag("laks");

		if (GetComponent<Pickup>().currentHens == 4 && lvl == 0)
		{
			Marsvin.collider2D.enabled = false;
			Sopp.collider2D.enabled = true;
		}

		if (GetComponent<Pickup>().fruitIsCorrect == true && GetComponent<Pickup>().currentHens == 4 && lvl == 0)
		{
			Laks.collider2D.enabled = false;
			Marsvin.collider2D.enabled = true;
		}
	}

	void Awake ()
	{
		DontDestroyOnLoad(gameObject);
	}

	void OnLevelWasLoaded (int level){
		lvl = level;

		if (lvl == 0)
		{
			GetComponent<CreateEgg>().eggCount = 0;
		}

		if (lvl == 1)
		{
			gameObject.transform.position = new Vector3 (6 , 1 , 0);

			GetComponent<CreateEgg>().eggCount = 0;
		}

		if (lvl == 2)
		{
			gameObject.transform.position = new Vector3 (5 , 1 , 11);
			gameObject.renderer.sortingOrder = 1;

			Egg.renderer.sortingOrder = 0;

			GetComponent<CreateEgg>().eggCount = 0;
		}

		if (lvl == 3)
		{
			gameObject.transform.position = new Vector3 (4 , 1 , 10);
			gameObject.renderer.sortingOrder = -3;
			
			Egg.renderer.sortingOrder = -4;
			
			GetComponent<CreateEgg>().eggCount = 0;
		}
	}

	void OnTriggerEnter2D (Collider2D c)
	{

		if (lvl == 0)
		{
			if (c.gameObject.name.Equals("LoadLVL1"))
			{
				Application.LoadLevel("Beta1");
			}

			if (c.gameObject.name.Equals("LoadLVL2"))
			{
				Application.LoadLevel("Fruitscene");
			}

			if (c.gameObject.name.Equals("LoadLVL3"))
			{
				Application.LoadLevel("Escape");
			}
		}

		if (c.gameObject.tag.Equals("sopp"))
		{
			if (lvl == 1)
			{
				if (GetComponent<Pickup>().currentHens == 4)
				{

					Application.LoadLevel("Choose_level");
					chooseLevel = true;
				}
			}
		}


		if (c.gameObject.tag.Equals("marsvin"))
		{

			if (GetComponent<Pickup>().fruitIsCorrect == true && lvl == 2)
			{
				Application.LoadLevel("Choose_level");
				chooseLevel = true;
			}

		}
	
	}
}
