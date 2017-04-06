using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {

	public Canvas quitMenu;
	public Button playButton;
	public Button exitButton;

	// Use this for initialization
	void Start () {
		quitMenu.GetComponent<Canvas> ();
		playButton.GetComponent<Button> ();
		quitMenu.enabled = false;
	}
	
	public void exitPress() {
		quitMenu.enabled = true;
		playButton.enabled = false;
		exitButton.enabled = false;
	}

	public void noPress() {
		quitMenu.enabled = false;
		playButton.enabled = true;
		exitButton.enabled = true;
	}

	public void startLevel() {
		Application.LoadLevel (1);
	}

	public void exitGame() {
		Application.Quit ();
	}

}
