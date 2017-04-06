using UnityEngine;
using System.Collections;

public class cardFollowMouse : MonoBehaviour {

    bool follow = false;
    float depth = 10.0f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (follow)
        {
            var mousePos = Input.mousePosition;
            var wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, depth));
            transform.position = wantedPos;
        }

        
	}

    void OnMouseOver()
    {
        if (Input.GetMouseButton(0) && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
        {
            Debug.Log("Card clicked but nothing yet");
            if (staticCardVariables.active)
                {
                Debug.Log("card clickable");
                if (staticCardVariables.cardMode == 0)
                {
                    Debug.Log("You selected this card");
                    staticCardVariables.cardMode = 1;
                    follow = true;
                    
                }else if(staticCardVariables.cardMode == 1)
                {
                    Debug.Log("You let go of this card");
                    staticCardVariables.cardMode = 0;
                    follow = false;
                }
            }
            
        }

    }
}
