using UnityEngine;
using System.Collections;

public class SplashScreenScript : MonoBehaviour {

	public GUIStyle splashScreen;
	public GUIStyle textDisplay;
	public string text = "Press A to start!";
	public float textPulseInSeconds=1f;
	public Rect textRect;
	public int nextLevel;

	private float timer = 0f;
	private bool showingText;
	private ControllerControllerPanelScript cController;
	private int aButton;

	void Awake(){
		cController = GameObject.FindWithTag("ControllerController").GetComponent<ControllerControllerPanelScript>();
	}
	

	void Update(){
		aButton = cController.ReturnJumpButton();
		timer+=Time.deltaTime;

		if(Input.GetKey("joystick 1 button "+aButton) || Input.GetKey(KeyCode.A)){
			Application.LoadLevel(nextLevel);
		}


	}

	void OnGUI(){
		GUI.Box (new Rect(0,0,Screen.width,Screen.height),"",splashScreen);

		FlashText();
	}

	void FlashText(){

		if(timer>textPulseInSeconds){
			showingText = !showingText;
			timer=0f;
		}

		if(showingText){
			//Debug.Log("displaying text");
			GUI.Label(textRect,text,textDisplay);
		}
	}
}
