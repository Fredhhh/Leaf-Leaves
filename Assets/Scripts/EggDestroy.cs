using UnityEngine;
using System.Collections;

public class EggDestroy : MonoBehaviour {

	public float timer;
	public int lvl;

	// Use this for initialization
	void Start () {

		if(GetComponent<LevelCHANGE>().lvl == 0 || GetComponent<LevelCHANGE>().lvl == 1)
		{
			gameObject.renderer.sortingOrder = 3;
		}
		
		if(GetComponent<LevelCHANGE>().lvl == 2)
		{
			gameObject.renderer.sortingOrder = 0;
		}
	
	
	}
	
	// Update is called once per frame
	void Update () {

		timer+=Time.deltaTime;
	
	
	}

	public float getTime() {

		return timer;

		}
	
}


