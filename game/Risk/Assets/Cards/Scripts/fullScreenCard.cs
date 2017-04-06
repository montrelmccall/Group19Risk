using UnityEngine;
using System.Collections;

public class fullScreenCard : MonoBehaviour {

    // Use this for initialization

    bool grow = false;
    bool enlarging = false;
    bool centeringX = false;
    bool centeringY = false;
    bool greaterX;
    bool greaterY;

    readonly float enlargeScale = .03f;
    readonly float centerXScale = .2f;
    readonly float centerYScale = .095f;
    readonly float bigRatio = .7f;


void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (grow)
        {

            if (enlarging) { 
                Vector3 theScale = new Vector3(transform.localScale.x + enlargeScale, transform.localScale.y + enlargeScale);
                transform.localScale = theScale;

                if (transform.localScale.x >= bigRatio)
                {

                    theScale = new Vector3(bigRatio, bigRatio);
                    transform.localScale = theScale;

                    enlarging = false;
                }
             }

            //center the x position
            if (centeringX)
            {
                Vector3 thePosition;
                if (greaterX)
                {
                    thePosition = new Vector3(transform.position.x - centerXScale, transform.position.y, transform.position.z);

                    if (transform.position.x <= Camera.main.transform.position.x)
                    {
                        thePosition = new Vector3(Camera.main.transform.position.x, transform.position.y, transform.position.z);
                        centeringX = false;
                    }
                }
                else
                {
                    thePosition = new Vector3(transform.position.x + centerXScale, transform.position.y, transform.position.z);
                    if (transform.position.x >= Camera.main.transform.position.x)
                    {
                        thePosition = new Vector3(Camera.main.transform.position.x, transform.position.y, transform.position.z);
                        centeringX = false;
                    }
                }
                transform.position = thePosition;

            }

            //center the y position
            if (centeringY)
            {
                Vector3 thePosition;
                if (greaterY)
                {
                    thePosition = new Vector3(transform.position.x, transform.position.y - centerYScale, transform.position.z);

                    if (transform.position.y <= Camera.main.transform.position.y)
                    {
                        thePosition = new Vector3(transform.position.x, Camera.main.transform.position.y, transform.position.z);
                        centeringY = false;
                    }
                }
                else
                {
                    thePosition = new Vector3(transform.position.x, transform.position.y + centerYScale, transform.position.z);
                    if (transform.position.y >= Camera.main.transform.position.y)
                    {
                        thePosition = new Vector3(transform.position.x, Camera.main.transform.position.y, transform.position.z);
                        centeringY = false;
                    }
                }
                transform.position = thePosition;

            }

            if(!enlarging && !centeringX && !centeringX)
            {
                Debug.Log("finished1");
                grow = false;
                GetComponent<BoxCollider2D>().enabled = true;

            }
        }

    }

    public void startGrowing()
    {
        enlarging = true;
        centeringX = true;
        centeringY = true;

        greaterX = transform.position.x > Camera.main.transform.position.x;
        greaterY = transform.position.y > Camera.main.transform.position.y;
        grow = true;
    }

    void OnMouseOver()
    {
        
            if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftShift))
            {
                Debug.Log("clicked1");
                enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                while (gameObject.GetComponent<BoxCollider2D>().enabled) ;
                gameObject.GetComponent<returnCard>().enabled = true;
                gameObject.GetComponent<returnCard>().returnToOriginalPosition();
            }
        
    }
}
