using UnityEngine;
using System.Collections;

public class EggDestroy : MonoBehaviour {

	public float timer;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

		timer+=Time.deltaTime;
	
	
	}

	public float getTime() {

		return timer;

		}
	
}


