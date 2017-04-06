using UnityEngine;
using System.Collections;

public class highlight : MonoBehaviour {

    // Use this for initialization

    static Color visible = new Color(.5f, 0.92f, 0.016f, 1);
    static Color invisible = new Color(0, 0, 0, 0);
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(staticCardVariables.active);

    }
 }
