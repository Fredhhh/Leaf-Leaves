using UnityEngine;
using System.Collections;

public class ItemTrigger : MonoBehaviour {

	private gamestate state;

	// Use this for initialization
	void Start () {

		state = gamestate.Instance;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c){
		if (c.transform.tag == "Item") {
			var item = c.gameObject;
			if(item.name == "Bed" || item.name == "Broom" || item.name == "Table") {
				if(!state.elevatorItemsPlaced.Contains(item)){
					state.elevatorItemsPlaced.Add(item);
					Debug.Log ("Placed item on trigger: " + item.name);
				}
			}

		}
	}
	
	void OnTriggerExit2D(Collider2D c){
		if (c.transform.tag == "Item") {
			var item = c.gameObject;
			if(state.elevatorItemsPlaced.Contains(item)){
				state.elevatorItemsPlaced.Remove(item);
				Debug.Log ("Removed item from trigger: " + item.name);
			}
		}
		
	}
}
