using UnityEngine;
using System.Collections;

public class FindAllRigidbodies : MonoBehaviour {

	private Rigidbody[] list;

	// Use this for initialization
	void Start () {
		list = FindObjectsOfType<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		float x=0, y=0, z=0;

		for (int i = 0; i < list.GetLength (0); i++) {
			x += list [i].transform.position.x;
			y += list [i].transform.position.y;
			z += list [i].transform.position.z;
		}
		x = x / list.GetLength (0);
		y = y / list.GetLength (0);
		z = z / list.GetLength (0);
		this.transform.position = new Vector3 (x, y, z);
	}
}
