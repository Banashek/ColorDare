using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {

	public GUIStyle colorPicker;

	// Update is called once per frame
	void OnGUI () {
	
		GUI.Label (new Rect(0, 0, Screen.width, 65), "", colorPicker);

	}
}
