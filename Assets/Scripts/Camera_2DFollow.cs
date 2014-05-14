using UnityEngine;
using System.Collections;

public class Camera_2DFollow : MonoBehaviour {

public Transform Target;

public GameObject Player;

public float cameraHeight;

public float Y;
public float LockedZ;

void Start ()
{
		Player = GameObject.FindGameObjectWithTag("Player");

		Target = Player.transform;
		cameraHeight = 0.46f;
		LockedZ = -14.3f;
}

//i funksjonen Awake hindrer vi selve spillobjektet (kameraet) å forsvinne når vi laster inn et nytt level
void Awake ()
{
	DontDestroyOnLoad(gameObject);
}

// i funksjonen LateUpdate bestemmer vi Y-posisjonen til kameraet (høyden) og hvor kameraet skal stå i forhold til karakteren
void LateUpdate () { 

	Y = cameraHeight + Target.position.y;
  	gameObject.transform.position = new Vector3(Target.position.x, Y, LockedZ); 
	}

// i funksjonen OnLevelWasLoaded får kameraet en ny z-posisjon (posisjonen innover i 3D-rommet) for hvert nye level som blir lastet inn
void OnLevelWasLoaded (int level){
	
	if (level == 2)
	{
	LockedZ = -2.7f;
	}

	if (level == 3)
	{
		LockedZ = -5;
	}

	if (level == 0 || level == 1)
	{
		LockedZ = -14.3f;
	}

	}

}