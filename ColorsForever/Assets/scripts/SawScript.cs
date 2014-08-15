using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SawScript : MonoBehaviour {

	[Range (1,3)] public int seed;

	public float colorRange = 256;
	[Range(0,256)] public float r,g,b;
	private List<float> colorComponents;
	private ColorControlledObjectScript colorProperties;
	private colorPicker colorPicker;
	private SawBladeScript sawBladeScript;
	public GameObject sawBlade; 

	private float verticalTrackXSpeed, horizontalTrackYSpeed, trackRotation;
	
	void Awake(){
		colorProperties = GetComponent<ColorControlledObjectScript>(); 
		colorPicker = GameObject.FindWithTag("Spectrum").GetComponent<colorPicker>();
		sawBladeScript = sawBlade.GetComponent<SawBladeScript>();
	}

	// Use this for initialization
	void Start () {
		AssignRandomColorsToObjectProperties();
	}

	void AssignRandomColorsToObjectProperties ()
	{
		seed = Random.Range(1,3);
	}

	void UpdateRandomColorsToObjectProperties(){
		if(seed==1){
			sawBladeScript.ModifyXSpeed(r);
			sawBladeScript.ModifyYSpeed(g);
			RotateSawPackage(b);
		}else if(seed==2){
			sawBladeScript.ModifyXSpeed(g);
			sawBladeScript.ModifyYSpeed(b);
			RotateSawPackage(r);
		}else{
			sawBladeScript.ModifyXSpeed(b);
			sawBladeScript.ModifyYSpeed(r);
			RotateSawPackage(g);
		}

	}
	
	// Update is called once per frame
	void Update () {
		GetColors();

		UpdateRandomColorsToObjectProperties();
	}

	void RotateSawPackage(float amount){
		transform.rotation = Quaternion.Euler(0,0,(amount*360));
	}


	void GetColors ()
	{
		if(colorProperties.red){
			r = colorPicker.PickedColor.r;
		}
		
		if(colorProperties.green){
			g = colorPicker.PickedColor.g;
		}
		
		if(colorProperties.blue){
			b = colorPicker.PickedColor.b;
		}
		
	}
}
