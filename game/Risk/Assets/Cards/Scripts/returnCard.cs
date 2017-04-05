using UnityEngine;
using System.Collections;

public class returnCard : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        Debug.Log("Ha");
        gameObject.GetComponentInParent<drawACard>().shrink();
        transform.Find("Return").gameObject.SetActive(false);
    }
}
