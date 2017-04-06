using UnityEngine;
using System.Collections;

public class cardCentral : MonoBehaviour {

                                
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //toggle card manipulation
        if (Input.GetKeyDown(KeyCode.C)){
            staticCardVariables.active = !staticCardVariables.active;
        }
	
	}
}
