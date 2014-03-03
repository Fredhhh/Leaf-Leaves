using UnityEngine;
using System.Collections;

public class FallingBars : MonoBehaviour {

	public bool hasFalled; 
	public GameObject target; 
	public Vector3 targetPositon; 
	public bool fall = false; 

	// Update is called once per frame
	void Start () {
		targetPositon = target.gameObject.transform.position; 
		hasFalled = false;
	}

	void Update(){
		if (fall == true && hasFalled != true) {
						if (this.gameObject.transform.position.y > targetPositon.y) {
				Debug.Log ("FALL!");
								this.gameObject.transform.Translate (Vector3.down * Time.deltaTime * 10);
						}
				}
			if(this.gameObject.transform.position.y < targetPositon.y){
				hasFalled = true;
			}
	}


	void OnTriggerEnter2D(Collider2D collider){
		if(collider.tag.Equals("Player")){
			fall = true; 
		}
	}
}
