using UnityEngine;
using System.Collections;

public class colorPicker : MonoBehaviour {


	public Color pickedColor;
	public float r,g,b;
	public int decreaseButton, increaseButton;

	public float increment = .01f;

	public Color PickedColor{
		get{return pickedColor;}
	}

	// Use this for initialization
	void Start () {
		decreaseButton = 17; //1 for windows, 17 for mac
		increaseButton = 18; //2 for windows, 18 for mac
	}
	
	// Update is called once per frame
	void Update () {

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

}
