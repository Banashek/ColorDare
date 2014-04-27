using UnityEngine;
using System.Collections;

public class colorChanger : MonoBehaviour {

	private colorPicker pickedColor;

	// Use this for initialization
	void Start () {
		pickedColor = GameObject.FindWithTag("Spectrum").GetComponent<colorPicker>();
	}
	
	// Update is called once per frame
	void Update () {
		renderer.material.color = pickedColor.PickedColor;
	}
}
