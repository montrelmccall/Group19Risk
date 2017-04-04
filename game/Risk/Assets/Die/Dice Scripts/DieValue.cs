using UnityEngine;
using System.Collections;

public class DieValue : MonoBehaviour {

	public int face_value = 0;
	public bool isRed = false;
	public bool isBlue = false;
	public Transform[] faces = { null, null, null, null, null, null };
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int facecount = faces.GetLength (0);
		int topface = 0;
		for (int i = 1; i < facecount; i++) {
			if (faces [i].position.y > faces [topface].position.y)
				topface = i;
			
		}
		face_value = topface + 1;
	}

	public int getValue() {
		return face_value;
	}
}
