using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AddManOnClick : MonoBehaviour {

	// Use this for initialization

	public Image ourObject = null;

	CountryHandler handler = null;

	public Image Spawnable;
	void Start () {
		handler = FindObjectOfType<CountryHandler> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown(0) && this.GetComponent<UIClick>().isDown()) {
			if (ourObject == null) {
				ourObject = Instantiate (Spawnable);
				ourObject.transform.SetParent (this.transform);

			}
			ourObject.color = handler.GetColor (0);
			ourObject.sprite = Spawnable.sprite;
			ourObject.rectTransform.rect.Set (0f, 0f, 1f, 1f);
			ourObject.transform.position =  this.GetComponent<Image>().transform.position;
		}

		if (Input.GetMouseButtonDown(1) && this.GetComponent<UIClick>().isDown()) {
			if (ourObject == null) {
				ourObject = Instantiate (Spawnable);
				ourObject.transform.SetParent (this.transform);

			}
			ourObject.color = handler.GetColor (1);
			ourObject.sprite = Spawnable.sprite;
			ourObject.rectTransform.rect.Set (0f, 0f, 1f, 1f);
			ourObject.transform.position =  this.GetComponent<Image>().transform.position;
		}
		if (Input.GetMouseButtonDown(2) && this.GetComponent<UIClick>().isDown()) {
			if (ourObject == null) {
				ourObject = Instantiate (Spawnable);
				ourObject.transform.SetParent (this.transform);

			}
			ourObject.color = handler.GetColor (2);
			ourObject.sprite = Spawnable.sprite;
			ourObject.rectTransform.rect.Set (0f, 0f, 1f, 1f);
			ourObject.transform.position =  this.GetComponent<Image>().transform.position;
		}

	}
}
