using UnityEngine;
using System.Collections;

public class SawScript : MonoBehaviour {

	public float colorRange = 256;
	[Range(0,256)] public float r,g,b;

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

	void AssignRandomColorsToObjectProperties(){
		int random = (int) Random.Range(1,3);
		if(random==1){
			
		}else if(random==2){
			
		}else{
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		GetColors();

	}
	


	void GetColors ()
	{
		if(colorProperties.red){
			r = colorPicker.PickedColor.r;
			sawBladeScript.ModifyXSpeed(r);
		}
		
		if(colorProperties.green){
			g = colorPicker.PickedColor.g;
			sawBladeScript.ModifyYSpeed(g);
		}
		
		if(colorProperties.blue){
			b = colorPicker.PickedColor.b;
		}
		
	}
}
