using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIRolls : MonoBehaviour {

	public string baseText = "Dice Rolls: ";
	private float rs = 5f;
	private DieValue[] dice;

	public bool red = false;
	public bool white = false;
	public bool blue = false;

	public bool canRoll = false;

	public Button Roller;

	public bool android = false;

	private Vector3[] startPos;
	// Use this for initialization
	void Start () {
		dice = FindObjectsOfType<DieValue> ();
		startPos = new Vector3[dice.GetLength (0)];
		for (int i = 0; i < dice.GetLength (0); i++) {
			startPos [i] = dice [i].transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		string temp = baseText;

		for (int i = 0; i < dice.GetLength(0); i++) {
			if (dice [i].isRed && red)
				temp += ""+dice [i].getValue () + ", ";
			else if (dice [i].isBlue && blue)
				temp += ""+dice [i].getValue () + ", ";
			else if (white && !dice[i].isBlue && !dice[i].isRed)
				temp += dice [i].getValue () + ", ";
		}
		char[] tempc = temp.ToCharArray ();
		tempc[temp.LastIndexOf(",")] = ' ';
		temp = new string(tempc);
		this.GetComponent<Text> ().text = temp;

		if ((android && Input.GetMouseButtonDown(0))) {
			for (int i = 0; i < dice.GetLength (0); i++) {
				dice [i].transform.position = startPos [i];
				Rigidbody tbody = dice [i].GetComponent<Rigidbody> ();
				tbody.velocity = new Vector3 (Random.Range (-rs, rs), Random.Range (rs*2, rs*5f), Random.Range (-rs, rs));
				tbody.angularVelocity = new Vector3 (Random.Range (-rs*2f, rs*2f), Random.Range (-rs*2f, rs*2f), Random.Range (-rs*2f, rs*2f));

			}
		}

		for (int i = 0; i < dice.GetLength (0); i++) {
			if(dice[i].GetComponent<Rigidbody>().velocity.magnitude < 1f && dice[i].GetComponent<Rigidbody>().velocity.magnitude > 0.01f) {
				float newX = dice [i].transform.position.x*40f + startPos [i].x;
				float newY = dice [i].transform.position.y*40f + startPos [i].y;
				float newZ = dice [i].transform.position.z*40f + startPos [i].z;
				dice [i].GetComponent<MeshCollider> ().enabled = false;
				dice [i].transform.position = new Vector3 (newX / 41f, newY / 41f, newZ / 41f);
			}
			else
				dice [i].GetComponent<MeshCollider> ().enabled = true;
		}
	}

	public void Roll() {
		for (int i = 0; i < dice.GetLength (0); i++) {
			dice [i].transform.position = startPos [i];
			Rigidbody tbody = dice [i].GetComponent<Rigidbody> ();
			tbody.velocity = new Vector3 (Random.Range (-rs, rs), Random.Range (rs * 2, rs * 5f), Random.Range (-rs, rs));
			tbody.angularVelocity = new Vector3 (Random.Range (-rs * 2f, rs * 2f), Random.Range (-rs * 2f, rs * 2f), Random.Range (-rs * 2f, rs * 2f));
		}
	}
}
