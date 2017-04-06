using UnityEngine;
using System.Collections;

public class rotateCard : MonoBehaviour {


    bool rotating = false;
    bool changeFace = false;
    bool started = false;
    float rotationCount = 0;
    readonly float rotateSpeed = 3f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (rotating)
        {
            if (!changeFace && rotationCount >= 90)
            {
                transform.FindChild("Back").gameObject.SetActive(!transform.FindChild("Back").gameObject.activeSelf);
                changeFace = true;
            }
            if (rotationCount < 180)
            {
                Debug.Log("tee" + rotationCount);
                transform.Rotate(new Vector3(0, 1), rotateSpeed);
                rotationCount += rotateSpeed;
            }
            else {
                rotating = false;
                rotationCount = 0;
                changeFace = false;
            }
        }

        if (started && !rotating)
        {
            started = false;
            GetComponent<BoxCollider2D>().enabled = true;
            
        }

    }

    void OnMouseOver()
    {
        
        if (Input.GetMouseButton(1))
        {
            GetComponent<BoxCollider2D>().enabled = false;
            rotating = true;
            started = true;
        }
    }
}
