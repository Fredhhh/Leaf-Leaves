/*
        Unity 3D: Game State Manager Script Source for State Manager
       
    Copyright 2012 FIZIX Digital Agency
    http://www.fizixstudios.com
       
        For more information see the tutorial at:
    http://www.fizixstudios.com/labs/do/view/id/unity-game-state-manager
       
       
    Notes:
        This script is a C# game state manager for Unity 3D; you should review the gamestart.cs
        script to help understand how to implement game states.
*/



using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gamestate : MonoBehaviour {
	
	// Declare properties
	private static gamestate instance;

	private string activeLevel;                     // Active level
	public bool normalPerception;
	public bool playerDead;
	public List<GameObject> elevatorItemsPlaced;
		// ---------------------------------------------------------------------------------------------------
	// gamestate()
	// ---------------------------------------------------------------------------------------------------
	// Creates an instance of gamestate as a gameobject if an instance does not exist
	// ---------------------------------------------------------------------------------------------------
	public static gamestate Instance
	{
		get
		{
			if(instance == null)
			{
				instance = new GameObject("gamestate").AddComponent<gamestate> ();
			}
			
			return instance;
		}
	}    

	void Start(){
		var state = gamestate.Instance;
			state.StartState();

	}

	void Update() {
		if (playerDead) {
			Application.LoadLevel(2);

		}

	}

	// Sets the instance to null when the application quits
	public void OnApplicationQuit()
	{
		instance = null;
	}
	// ---------------------------------------------------------------------------------------------------
	
	
	// ---------------------------------------------------------------------------------------------------
	// startState()
	// ---------------------------------------------------------------------------------------------------
	// Creates a new game state
	// ---------------------------------------------------------------------------------------------------
	public void StartState()
	{
		normalPerception = false;
		elevatorItemsPlaced = new List<GameObject>();

		Physics2D.IgnoreLayerCollision (8, 9, true);
	}
}