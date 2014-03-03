using UnityEngine;
using System.Collections;

public class PlayerPhysics : MonoBehaviour {

	//[HideInInspector]
	//public bool grounded;

		public void Move(Vector2 moveAmount) {
			float deltaY = moveAmount.y;
			float deltaX = moveAmount.x;
		//Vector2 p = transform.position;
			//transform.Translate(moveAmount);
		Vector2 finalTransform = new Vector2(deltaX,deltaY);
		
		transform.Translate(finalTransform);
		}
	

}
