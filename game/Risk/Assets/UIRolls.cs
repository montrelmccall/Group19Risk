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

		if (Input.GetKeyDown (KeyCode.Space) || (android && Input.GetMouseButtonDown(0))) {
			for (int i = 0; i < dice.GetLength (0); i++) {
				dice [i].transform.position = startPos [i];
				Rigidbody tbody = dice [i].GetComponent<Rigidbody> ();
				tbody.velocity = new Vector3 (Random.Range (-rs, rs), Random.Range (rs*2, rs*5f), Random.Range (-rs, rs));
				tbody.angularVelocity = new Vector3 (Random.Range (-rs*2f, rs*2f), Random.Range (-rs*2f, rs*2f), Random.Range (-rs*2f, rs*2f));

			}
		}
	}
}
