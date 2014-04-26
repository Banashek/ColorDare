using UnityEngine;
using System.Collections;

public class colorPicker : MonoBehaviour {

	/*
	 * 
	black - 380 (top left)
	v -420
	b - 475
	g - 520
	y - 575
	o - 590
	r - 620
	black - 750 (top right)
	spectrum = abs(380 - 750) = 370 total points
	*
	*/

	enum ColorValues{ultraviolet=380,violet=420,blue=475,green=520,yellow=575,orange=590,red=620,infrared=750}
	enum ColorIndex{black,violet,blue,green,yellow,orange,red,infrared}
	Color[] colors = new Color[] {Color.black,Color.Lerp(Color.red,Color.blue,.5f),Color.blue,Color.green,Color.yellow,Color.Lerp(Color.red,Color.yellow,.5f),Color.red,Color.black};
	int numOfXPixels;
	float range = 370;
	int lowestColorNumber = 380;

	// Use this for initialization
	void Start () {
		numOfXPixels = Screen.width;


	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)){
			float mouseX = Input.mousePosition.x;
			float mouseToScreenRatio = mouseX/numOfXPixels;
			float colorNumber = (mouseToScreenRatio*range)+ lowestColorNumber;

			renderer.material.color = PickColor(colorNumber);
		}
	}

	public Color PickColor(float colorNum){ 
		float lerpRatio;
		if(colorNum<(int)ColorValues.violet){

			lerpRatio = (colorNum-(int)ColorValues.ultraviolet)/((int)ColorValues.violet-(int)ColorValues.ultraviolet);
			return Color.Lerp(colors[(int)ColorIndex.black],colors[(int)ColorIndex.violet],lerpRatio);
		
		}else if(colorNum<(int)ColorValues.blue){

			lerpRatio = (colorNum-(int)ColorValues.violet)/((int)ColorValues.blue-(int)ColorValues.violet);
			return Color.Lerp(colors[(int)ColorIndex.violet],colors[(int)ColorIndex.blue],lerpRatio);
		
		}else if(colorNum<(int)ColorValues.green){

			lerpRatio = (colorNum-(int)ColorValues.blue)/((int)ColorValues.green-(int)ColorValues.blue);
			return Color.Lerp(colors[(int)ColorIndex.blue],colors[(int)ColorIndex.green],lerpRatio);
		
		}else if(colorNum<(int)ColorValues.yellow){

			lerpRatio = (colorNum-(int)ColorValues.green)/((int)ColorValues.yellow-(int)ColorValues.green);
			return Color.Lerp(colors[(int)ColorIndex.green],colors[(int)ColorIndex.yellow],lerpRatio);
		
		}else if(colorNum<(int)ColorValues.orange){

			lerpRatio = (colorNum-(int)ColorValues.yellow)/((int)ColorValues.orange-(int)ColorValues.yellow);
			return Color.Lerp(colors[(int)ColorIndex.yellow],colors[(int)ColorIndex.orange],lerpRatio);
		
		}else if(colorNum<(int)ColorValues.red){

			lerpRatio = (colorNum-(int)ColorValues.orange)/((int)ColorValues.red-(int)ColorValues.orange);
			return Color.Lerp(colors[(int)ColorIndex.orange],colors[(int)ColorIndex.red],lerpRatio);
		
		}else{

			lerpRatio = (colorNum-(int)ColorValues.red)/((int)ColorValues.infrared-(int)ColorValues.red);
			return Color.Lerp(colors[(int)ColorIndex.red],colors[(int)ColorIndex.black],lerpRatio);

		}
	}

}
