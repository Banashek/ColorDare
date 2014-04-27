using UnityEngine;
using System.Collections;

public class platformScript : MonoBehaviour {

	public float colorRange = 256;
	[Range(0,256)] public float r,g,b;
	public float rotation;
	private ColorControlledObjectScript colorProperties;
	private colorPicker colorPicker;

	
	void Awake(){
		colorProperties = GetComponent<ColorControlledObjectScript>(); 
		colorPicker = GameObject.FindWithTag("Spectrum").GetComponent<colorPicker>();
	}

	// Use this for initialization
	void Start () {
		rotation = transform.rotation.eulerAngles.z;
	}
	
	// Update is called once per frame
	void Update () {
		GetColors();
		SetRotation();
	}

	void GetColors ()
	{
		if(colorProperties.red){
			r = colorPicker.PickedColor.r * colorRange;
			rotation = (r/256)*360;
		}
		
		if(colorProperties.green){
			g = colorPicker.PickedColor.g * colorRange;
			rotation = (g/256)*360;
			/*gameObject.transform.Translate(gameObject.transform.position.x - (g/256),
			                               gameObject.transform.position.y,
			                               gameObject.transform.position.z); */
		}
		
		if(colorProperties.blue){
			b = colorPicker.PickedColor.b * colorRange;
			rotation = (b/256)*360;
			/*gameObject.transform.Translate(gameObject.transform.position.x,
			                               gameObject.transform.position.y - (b/256),
			                               gameObject.transform.position.z); */
		}
		
	}

	void SetRotation(){
		transform.rotation = Quaternion.Euler(0,0,rotation);
	}
}
