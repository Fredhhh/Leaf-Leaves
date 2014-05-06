using UnityEngine;
using System.Collections;

public class LevelCHANGE : MonoBehaviour {

	public bool chooseLevel;
	public int lvl;

	// Use this for initialization
	void Start () {

		chooseLevel = false;
	
	}
	
	// Update is called once per frame
	void Update () {


	
	}
	void OnLevelWasLoaded (int level){
		lvl = level;
	//	DontDestroyOnLoad(gameObject);
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

			if (GetComponent<Pickup>().currentHens == 4 && lvl == 0)
			{
				GameObject Sopp = GameObject.FindGameObjectWithTag("sopp");
				Sopp.collider2D.enabled = true;
			}
		}


		if (c.gameObject.tag.Equals("marsvin"))
		{

			if (GetComponent<Pickup>().fruitIsCorrect == true && lvl == 2)
			{
				Application.LoadLevel("Choose_level");
				chooseLevel = true;
			}

			if (GetComponent<Pickup>().fruitIsCorrect == true && lvl == 0)
			{
				GameObject Marsvin = GameObject.FindGameObjectWithTag("marsvin");
				Marsvin.collider2D.enabled = false;
			}

		}
	
	}
}
