using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountryHandler : MonoBehaviour {

	public Color[] colors;
	public Transform Spawnable;
	public Transform Parent;
	public Transform[] Spawned;
	private int numSpawned =1023;
	public float Distance = 12f;
	public Dropdown selecter;
	public Dropdown TroopSelecter;
	public int selected = -1;
	public Texture[] images;

	// Use this for initialization
	void Start () {
		Spawned = new Transform[1023];
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (1)) {
			if (isClicked () == -1) {
				int temp = 0;
				while (Spawned [temp] != null)
					temp++;
				Spawned [temp] = Instantiate (Spawnable).transform;
				Spawned [temp].transform.position = FindObjectOfType<Camera> ().ScreenPointToRay (Input.mousePosition).origin;
				Spawned [temp].transform.position = new Vector3 (Spawned [temp].position.x, 0f -  Spawned [temp].position.z / 500f, Spawned [temp].position.z);
				Spawned [temp].transform.parent = Parent;
				Spawned [temp].GetComponent<MeshRenderer> ().material.color = colors [selecter.value];
				Spawned [temp].GetComponent<MeshRenderer> ().material.mainTexture = images [TroopSelecter.value];
			} else {
				Destroy (Spawned [isClicked()].gameObject);
			}
		}

		if (Input.GetMouseButton (0)) {
			if (isClicked () != -1 || selected != -1) {
				if (selected == -1) {
					selected = isClicked ();
				}
				Spawned [selected].transform.position = FindObjectOfType<Camera> ().ScreenPointToRay (Input.mousePosition).origin;
				Spawned [selected].transform.position = new Vector3 (Spawned [selected].position.x, 0f -  Spawned [selected].position.z / 500f, Spawned [selected].position.z);
			}
		}
		if (Input.GetMouseButtonUp (0)) {
			selected = -1;
		}
	}

	public int isClicked() {
		for (int i = 0; i < numSpawned; i++) {
			if (Spawned [i] != null) {
				float xoff = Mathf.Abs (Spawned [i].position.x - FindObjectOfType<Camera> ().ScreenPointToRay (Input.mousePosition).origin.x);
				float yoff = Mathf.Abs (Spawned [i].position.z - FindObjectOfType<Camera> ().ScreenPointToRay (Input.mousePosition).origin.z);
				float dist = Mathf.Sqrt (xoff * xoff + yoff * yoff);
				if (dist < Distance)
					return i;
			}
		}
		return -1;
	}

	public void clearAllObjects() {
		for(int i = 0; i<numSpawned; i++)
			if(Spawned[i] != null)
				Destroy (Spawned [i].gameObject);
	}
	public Color GetColor(int i) {
		return colors [i];
	}
}
