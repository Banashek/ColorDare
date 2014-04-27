using UnityEngine;
using System.Collections;

public class ControllerControllerPanelScript : MonoBehaviour {

	bool mac, windows;
	public bool switchSystemTypes;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
		mac=true;
	}
	
	// Update is called once per frame
	void Update () {
		if(switchSystemTypes){
			mac = !mac;
			windows=  !windows;
			switchSystemTypes=false;
		}
	}

	public int ReturnJumpButton(){
		if(mac) return 16;
		else return 0;
	}

	public int ReturnDecreaseButton(){
		if(mac) return 17;
		else return 1;
	}

	public int ReturnIncreaseButton(){
		if(mac) return 18;
		else return 2;
	}

}
