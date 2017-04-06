using UnityEngine;
using System.Collections;

public class drawACard : MonoBehaviour {

    // Use this for initialization
    bool big = false;
    bool centeringX = false;
    bool centeringY = false;
    bool returningX = false;
    bool returningY = false;
    bool returningScaleX = false;
    bool returningScaleY = false;
    bool greaterX = false;
    bool greaterY = false;
    bool lesserX = false;
    bool lesserY = false;
    bool rotating = false;
    bool sideChoice = false;
    bool changeFace = false;
    bool shrinking = false;
    bool doingSomething = false;
    bool returningOrCentering = true;
    bool wasShrinking = false;
    readonly float cardWidth = 1000;
    readonly float cardHeight = 1400;
    readonly float bigRatio = .7f;
    readonly float smallRatio = .1f;
    readonly float enlargeScale = .03f;
    readonly float centerXScale = .2f;
    readonly float centerYScale = .095f;
    readonly float rotateSpeed = 3f;
    float xOrigin;
    float yOrigin;
    float rotationCount = 0;

    Vector3 originalScale;

    bool enlarging = false;
    float screenRatio;
	void Start () {
        xOrigin = transform.position.x;
        yOrigin = transform.position.y;
        
        screenRatio = (Screen.width * smallRatio);
        Vector3 theScale = new Vector3(screenRatio/cardHeight, screenRatio/cardHeight,0f);
        transform.localScale = theScale;
        originalScale = transform.localScale;
        
	
	}
	
	// Update is called once per frame
	void Update () {
        screenRatio = (Screen.width * smallRatio);

        if (enlarging)
        {
            Vector3 theScale = new Vector3(transform.localScale.x + enlargeScale, transform.localScale.y + enlargeScale);
            transform.localScale = theScale;

            if(transform.localScale.x >= bigRatio)
            {

                theScale = new Vector3(bigRatio, bigRatio);
                transform.localScale = theScale;

                enlarging = false;
            }
        }

        if(shrinking)
        {
            Vector3 theScale = new Vector3(transform.localScale.x - enlargeScale, transform.localScale.y - enlargeScale);
            transform.localScale = theScale;

            if (transform.localScale.x <= originalScale.x)
            {

                theScale = new Vector3(originalScale.x, originalScale.x);
                transform.localScale = theScale;

                enlarging = shrinking = false;
            }

        }

        //center the x position
        if (centeringX)
        {
            Vector3 thePosition;
            if (greaterX) {
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
                thePosition = new Vector3(transform.position.x, transform.position.y -centerYScale, transform.position.z);
                if (transform.position.y <= yOrigin)
                {
                    thePosition = new Vector3(transform.position.y, yOrigin, transform.position.z);
                    returningY = false;

                }
            }
            transform.position = thePosition;
        }



        if (!centeringX && !centeringY && !enlarging && !rotating && !returningX && !returningY &&!shrinking)
        {
            
            if (doingSomething)
            {
                doingSomething = false;
                //transform.Find("Return").GetComponent<BoxCollider2D>().enabled = true;
                GetComponent<BoxCollider2D>().enabled = true;
            }

            if (wasShrinking)
            {
                wasShrinking = false;
                //transform.GetComponent<BoxCollider2D>().enabled = true;
            }
        }

        


    }

     void enlarge()
    {
        //zoom
        enlarging = true;
        
    }

    public void shrink()
    {
        //zoom out
        wasShrinking = true;
        shrinking = true;
        returningX = true;
        lesserX = transform.position.x < xOrigin;
        returningY = true;
        lesserY = transform.position.y < yOrigin;
        
    }

    void centerX()
    {
        centeringX = true;
        greaterX = transform.position.x > Camera.main.transform.position.x;
    }

    void centerY()
    {
        centeringY = true;
        greaterY = transform.position.y > Camera.main.transform.position.y;
    }

    void rotate()
    {
        rotating = true;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            doingSomething = true;
                enlarge();
                centerX();
                centerY();         
             
        }
    }
}
