using UnityEngine;
using System.Collections;

public class LevelCHANGE : MonoBehaviour {

	public bool chooseLevel;
	public int lvl;

	public GameObject Marsvin;
	public GameObject Sopp;
	public GameObject Laks;

	public GameObject Egg;
	
	void Start () {

		chooseLevel = false;


	}
	
	// Update blir kalt per frame
	void Update () {

		Marsvin = GameObject.FindGameObjectWithTag("marsvin");
		Sopp = GameObject.FindGameObjectWithTag("sopp");
		Laks = GameObject.FindGameObjectWithTag("laks");

		//hvis man har fått fire kalkuner og levelet er nr. 0 skal soppen blokkere inngangen til level 1, men marsvinet fjerner sin blokkade
		if (GetComponent<Pickup>().currentHens == 4 && lvl == 0)
		{
			Marsvin.collider2D.enabled = false;
			Sopp.collider2D.enabled = true;
		}

		//hvis man har fire kalkuner, levelet er nr. 0, og man har fått riktig frukt i level 2, skal marsvinet blokkere level 2, og laksen åpne sin
		if (GetComponent<Pickup>().fruitIsCorrect == true && GetComponent<Pickup>().currentHens == 4 && lvl == 0)
		{
			Laks.collider2D.enabled = false;
			Marsvin.collider2D.enabled = true;
		}
	}

	//funksjonen Awake unngår å fjerne objektet skriptet er knyttet til, dvs. karakteren 
	void Awake ()
	{
		DontDestroyOnLoad(gameObject);
	}

	void OnLevelWasLoaded (int level){
		lvl = level;

		GetComponent<CreateEgg>().currentTime = 0;
		GetComponent<CreateEgg>().compareTime = 0;

		//hvor hvert nye innlastede level settes antallet egg lagt ut til 0
		if (lvl == 0)
		{
			GetComponent<CreateEgg>().eggCount = 0;
		}

		//for noen level blir karakterens startposisjon endret ved bruk av new Vector3
		if (lvl == 1)
		{
			gameObject.transform.position = new Vector3 (5 , 3 , 0);

			Egg.renderer.sortingOrder = 2;

			GetComponent<CreateEgg>().eggCount = 0;
		}

		if (lvl == 2)
		{
			gameObject.transform.position = new Vector3 (4 , 3 , 11);
			gameObject.renderer.sortingOrder = 1;

			Egg.renderer.sortingOrder = 0;

			GetComponent<CreateEgg>().eggCount = 0;
		}

		if (lvl == 3)
		{
			gameObject.transform.position = new Vector3 (3 , 3 , 10);
			gameObject.renderer.sortingOrder = 3;
			
			Egg.renderer.sortingOrder = 3;
			
			GetComponent<CreateEgg>().eggCount = 0;
		}
	}

	void OnTriggerEnter2D (Collider2D c)
	{
		//denne funksjonen laster inn et nytt level når karakteren kolliderer med en bestemt kollisjonsboks 
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
				//er levelet 1 og man har alle fire kalkunene vil man komme tilbake til valg av level-banen
				if (GetComponent<Pickup>().currentHens == 4)
				{

					Application.LoadLevel("Choose_level");
					chooseLevel = true;
				}

			}

		}


		if (c.gameObject.tag.Equals("marsvin"))
		{
			if (lvl == 2)
			{
				//er levelet 2 og man har riktig frukt vil man komme tilbake til valg av level-banen
				if (GetComponent<Pickup>().fruitIsCorrect == true)
				{
					Application.LoadLevel("Choose_level");
					chooseLevel = true;
				}
			}

		}
	
	}
}
