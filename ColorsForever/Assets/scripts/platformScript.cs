using UnityEngine;
using System.Collections;

public class platformScript : MonoBehaviour {

	[Range(1,3)] public int seed;
	public float colorRange = 256;
	public float xRange=2, yRange=2;
	[Range(0,256)] public float r,g,b;
	public float rotation;
	private Vector3 startingPosition;
	private ColorControlledObjectScript colorProperties;
	private colorPicker colorPicker;

	
	void Awake(){
		colorProperties = GetComponent<ColorControlledObjectScript>(); 
		colorPicker = GameObject.FindWithTag("Spectrum").GetComponent<colorPicker>();
	}

	// Use this for initialization
	void Start () {
		rotation = transform.rotation.eulerAngles.z;
		startingPosition = transform.position;
		seed = Random.Range(1,3);
	}
	
	// Update is called once per frame
	void Update () {
		GetColors();

		UpdateRandomColorsToProperties();
	}

	void UpdateRandomColorsToProperties ()
	{
		if(seed==1){
			SetRotation(r);
			MoveOnX(g);
			MoveOnY(b);
		}else if(seed==2){
			SetRotation(g);
			MoveOnX(b);
			MoveOnY(r);
		}else{
			SetRotation(b);
			MoveOnX(g);
			MoveOnY(r);
		}
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

	void SetRotation(float amount){
		transform.rotation = Quaternion.Euler(0,0,amount);
	}

	void MoveOnX(float amount){ //amount is from 0-1
		float pos = (amount*xRange) - (xRange/2);
		transform.localPosition = new Vector3(startingPosition.x+pos,transform.localPosition.y,transform.localPosition.z);
	}

	void MoveOnY(float amount){
		float pos = (amount*xRange) - (yRange/2);
		transform.localPosition = new Vector3(transform.localPosition.x,startingPosition.y + pos,transform.localPosition.z);
	}
}
