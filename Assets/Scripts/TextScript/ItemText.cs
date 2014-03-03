using UnityEngine;
using System.Collections;

public class ItemText : MonoBehaviour {


	public void ChangeItemText(string newText){
		this.gameObject.guiText.text = "Item: " + newText;
		Debug.Log (newText);

	}
}
