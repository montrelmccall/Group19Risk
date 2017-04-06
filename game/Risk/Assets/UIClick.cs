using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIClick : MonoBehaviour {

	public bool pressed;

	void Start(){
		pressed = false;
		this.gameObject.AddComponent<BoxCollider> ().size = this.GetComponent<Image> ().rectTransform.rect.size;
		this.GetComponent<BoxCollider> ().center = new Vector3 (0f, 0f);
		this.GetComponent<BoxCollider> ().isTrigger = true;
		Debug.Log ("Spawn on "+this.GetComponent<Image> ().GetPixelAdjustedRect ().position);
	}

	void Update() {
		Vector2 temp = this.GetComponent<Image> ().GetPixelAdjustedRect ().position;
		temp = new Vector2 (-temp.x, -temp.y);

		if(Mathf.Abs(temp.x-Input.mousePosition.x) < 225f && Mathf.Abs(temp.y-Input.mousePosition.y) < 5f){
			Debug.Log ("Click on "+Input.mousePosition);
				pressed = true;
				Debug.Log ("Pressed");
		} else{
			pressed = false;
		}
	}
			

	public bool isDown(){
		return pressed;
	}
}
