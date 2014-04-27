using UnityEngine;
using System.Collections;

public class SawScript : MonoBehaviour {

	public float colorRange = 256;
	[Range(0,256)] public float r,g,b;

	private ColorControlledObjectScript colorProperties;
	private colorPicker colorPicker;
	
	void Awake(){
		colorProperties = GetComponent<ColorControlledObjectScript>(); 
		colorPicker = GameObject.FindWithTag("Spectrum").GetComponent<colorPicker>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetColors();
	}

	void GetColors ()
	{
		if(colorProperties.red){
			r = colorPicker.PickedColor.r * colorRange;
		}
		
		if(colorProperties.green){
			g = colorPicker.PickedColor.g * colorRange;
		}
		
		if(colorProperties.blue){
			b = colorPicker.PickedColor.b * colorRange;
		}
		
	}
}
