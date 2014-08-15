using UnityEngine;
using System.Collections;

public class colorPicker : MonoBehaviour {

	public GUIStyle colorBar, colorIndicator;
	public Color pickedColor;
	public float r,g,b;
	public int decreaseButton, increaseButton;
	public int colorIndicatorOffset=0;

	public float increment = .01f;
	private ControllerControllerPanelScript controllerSettings;

	public Color PickedColor{
		get{return pickedColor;}
	}
	
	void Awake(){
		controllerSettings = GameObject.FindWithTag("ControllerController").GetComponent<ControllerControllerPanelScript>();
		
	}

	// Use this for initialization
	void Start () {
		pickedColor = Color.white;
		decreaseButton = controllerSettings.ReturnDecreaseButton();
		increaseButton = controllerSettings.ReturnIncreaseButton();
	}
	
	// Update is called once per frame
	void Update () {

		decreaseButton = controllerSettings.ReturnDecreaseButton();
		increaseButton = controllerSettings.ReturnIncreaseButton();

		if((Input.GetKey("joystick 1 button "+decreaseButton) || Input.GetKey(KeyCode.A) ) && r<1){
			r+=increment;
		}else if((Input.GetKey("joystick 1 button "+increaseButton) || Input.GetKey(KeyCode.Z) ) && r>increment){
			r-=increment;
		}

		if((Input.GetKey("joystick 2 button "+decreaseButton) || Input.GetKey(KeyCode.S) ) && g<1){
			g+=increment;
		}else if((Input.GetKey("joystick 2 button "+increaseButton) || Input.GetKey(KeyCode.X) ) && g>increment){
			g-=increment;
		}

		if((Input.GetKey("joystick 3 button "+decreaseButton) || Input.GetKey(KeyCode.D) ) && b<1){
			b+=increment;
		}else if((Input.GetKey("joystick 3 button "+increaseButton) || Input.GetKey(KeyCode.C) ) && b>increment){
			b-=increment;
		}

		pickedColor = PickColor();

	}

	public Color PickColor(){ 
		return new Color(r,g,b);
	}

	void OnGUI(){
		GUI.Box(new Rect(0,0,1136,65),"",colorBar);
		/* each bar = 352 px
		 * r 0-352
		 * g 392-744
		 * b 784-1136
		 */ 
		float rMapped,gMapped,bMapped;
		rMapped = r*352;
		gMapped = g*352 + 352 + 40;
		bMapped = b*352 + (2*352) + (2*40);

		GUI.Box(new Rect(rMapped-colorIndicatorOffset,29,24,36),"",colorIndicator);
		GUI.Box(new Rect(gMapped-colorIndicatorOffset,29,24,36),"",colorIndicator);
		GUI.Box(new Rect(bMapped-colorIndicatorOffset,29,24,36),"",colorIndicator);

	}

}
