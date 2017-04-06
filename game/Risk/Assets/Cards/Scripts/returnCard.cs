using UnityEngine;
using System.Collections;

public class returnCard : MonoBehaviour {

    bool lesserX = false;
    bool lesserY = false;
    bool returning = false;
    bool returningX = false;
    bool returningY = false;
    bool shrinking = false;
    float screenRatio;
    float xOrigin;
    float yOrigin;
    readonly float cardWidth = 1000;
    readonly float cardHeight = 1400;
    readonly float centerXScale = .2f;
    readonly float centerYScale = .095f;
    readonly float enlargeScale = .03f;
    readonly float smallRatio = .1f;
    Vector3 originalScale;

    // Use this for initialization
    void Start () {

        xOrigin = transform.position.x;
        yOrigin = transform.position.y;

        Debug.Log("started");

        screenRatio = (Screen.width * smallRatio);
        Vector3 theScale = new Vector3(screenRatio / cardHeight, screenRatio / cardHeight, 0f);
        transform.localScale = theScale;
        originalScale = transform.localScale;
    }
	
	// Update is called once per frame
	void Update () {

        if (returning)
        {
            if (shrinking)
            {
                Vector3 theScale = new Vector3(transform.localScale.x - enlargeScale, transform.localScale.y - enlargeScale);
                transform.localScale = theScale;

                if (transform.localScale.x <= originalScale.x)
                {

                    theScale = new Vector3(originalScale.x, originalScale.x);
                    transform.localScale = theScale;

                   shrinking = false;
                }

            }


            //returning
            if (returningX)
            {

                //returning x
                Vector3 thePosition;
                if (lesserX)
                {
                    thePosition = new Vector3(transform.position.x + centerXScale, transform.position.y, transform.position.z);

                    if (transform.position.x >= xOrigin)
                    {
                        thePosition = new Vector3(xOrigin, transform.position.y, transform.position.z);
                        returningX = false;
                    }
                }
                else
                {
                    thePosition = new Vector3(transform.position.x - centerXScale, transform.position.y, transform.position.z);
                    if (transform.position.x <= xOrigin)
                    {
                        thePosition = new Vector3(xOrigin, transform.position.y, transform.position.z);
                        returningX = false;

                    }
                }
                transform.position = thePosition;
            }

            if (returningY)
            {

                //returning y
                Vector3 thePosition;
                if (lesserY)
                {
                    thePosition = new Vector3(transform.position.x, transform.position.y + centerYScale, transform.position.z);

                    if (transform.position.y >= yOrigin)
                    {
                        thePosition = new Vector3(transform.position.x, yOrigin, transform.position.z);
                        returningY = false;
                    }
                }
                else
                {
                    thePosition = new Vector3(transform.position.x, transform.position.y - centerYScale, transform.position.z);
                    if (transform.position.y <= yOrigin)
                    {
                        thePosition = new Vector3(transform.position.y, yOrigin, transform.position.z);
                        returningY = false;

                    }
                }
                transform.position = thePosition;
            }
            if(!shrinking && !returningX && !returningY)
            {
                Debug.Log("finished2");
                returning = false;
                GetComponent<BoxCollider2D>().enabled = true;
            }
        }
	
	}

    public void returnToOriginalPosition()
    {     
        returningX = true;
        returningY = true;
        lesserX = transform.position.x < xOrigin;
        lesserY = transform.position.y < yOrigin;
        shrinking = true;
        returning = true;
    }

    void OnMouseOver()
    {
        
            if (Input.GetMouseButton(0) && !Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.RightShift))
            {
                Debug.Log("clicked2");
                enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<fullScreenCard>().enabled = true;
                GetComponent<fullScreenCard>().startGrowing();
                
            }
        
        
    }
}
