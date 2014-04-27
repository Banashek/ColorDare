﻿using UnityEngine;
using System.Collections;

public class colorPicker : MonoBehaviour {


	public Color pickedColor;
	public float r,g,b;

	public float increment = .01f;

	public Color PickedColor{
		get{return pickedColor;}
	}

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey("joystick 1 button 1") && r<=(1-increment)){
			r+=increment;
		}else if(Input.GetKey("joystick 1 button 2") && r>=increment){
			r-=increment;
		}

		if(Input.GetKey("joystick 2 button 1") && g<=(1-increment)){
			g+=increment;
		}else if(Input.GetKey("joystick 2 button 2") && g>=increment){
			g-=increment;
		}

		if(Input.GetKey("joystick 3 button 1") && b<=(1-increment)){
			b+=increment;
		}else if(Input.GetKey("joystick 3 button 2") && b>=increment){
			b-=increment;
		}

		pickedColor = PickColor();

	}

	public Color PickColor(){ 
		return new Color(r,g,b);
	}

}
