using UnityEngine;
using System.Collections;

public class LevelCHANGE : MonoBehaviour {

	public bool chooseLevel;
	public int lvl;

	public GameObject Marsvin;
	public GameObject Sopp;
	public GameObject Laks;

	// Use this for initialization
	void Start () {

		chooseLevel = false;

		Marsvin = GameObject.FindGameObjectWithTag("marsvin");
		Sopp = GameObject.FindGameObjectWithTag("sopp");
		Laks = GameObject.FindGameObjectWithTag("laks");
	}
	
	// Update is called once per frame
	void Update () {

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

		if (lvl == 1)
		{
			gameObject.transform.position = new Vector3 (6 , 1 , 0);
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
