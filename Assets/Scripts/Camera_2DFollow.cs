using UnityEngine;
using System.Collections;

public class Camera_2DFollow : MonoBehaviour {

public Transform Target;

public GameObject Player;

public float cameraHeight;

public float Y;
public float LockedZ;

public int lvl;

void Start ()
{
		Player = GameObject.FindGameObjectWithTag("Player");

		Target = Player.transform;
		cameraHeight = 0.46f;
		LockedZ = -14.3f;
}

void Awake ()
{
	DontDestroyOnLoad(gameObject);
}

void LateUpdate () { 

	Y = cameraHeight + Target.position.y;
  	gameObject.transform.position = new Vector3(Target.position.x, Y, LockedZ); 
	}

void OnLevelWasLoaded (int level){
	lvl = level;
	
	if (lvl == 2)
	{
	LockedZ = -2.7f;
	}

	if (lvl == 3)
	{
		LockedZ = 8.7f;
	}

	else
			LockedZ = -14.3f;

	}

}