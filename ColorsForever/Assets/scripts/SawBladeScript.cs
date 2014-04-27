using UnityEngine;
using System.Collections;

public class SawBladeScript : MonoBehaviour {

	public float xRange, yRange;
	public float topSpeed=1f, slowestSpeed=.2f;
	public float overallSpeedModifier=.5f;
	public float xSpeed, ySpeed;
	private bool xInc=true, yInc=true;

	public float waitTimeBeforeBegin = 1f;
	public float timer = 0f;


	void Start(){
		xSpeed = slowestSpeed;
		ySpeed = slowestSpeed;
	}

	// Update is called once per frame
	void Update () {
		if(timer>waitTimeBeforeBegin){
			if(xInc){
				transform.Translate(Vector3.right * xSpeed * overallSpeedModifier);
				if(transform.localPosition.x>xRange)
					xInc = false;
				//Debug.Log ("moving right");
			}else{
				transform.Translate(-Vector3.right * xSpeed * overallSpeedModifier);
				if(transform.localPosition.x < -xRange)
					xInc = true;
			}

			if(yInc){
				transform.Translate(Vector3.up * ySpeed * overallSpeedModifier);
				if(transform.localPosition.y>yRange)
					yInc = false;
				//Debug.Log ("moving up");
			}else{
				transform.Translate(-Vector3.up * ySpeed * overallSpeedModifier);
				if(transform.localPosition.y < -yRange)
					yInc = true;
			}
		}
		timer+=Time.deltaTime;
	}

	public void ModifyXSpeed(float xModPercentage){
		xSpeed = (xModPercentage*(topSpeed-slowestSpeed)) + slowestSpeed;
	}

	public void ModifyYSpeed(float yModPercentage){
		ySpeed = (yModPercentage*(topSpeed-slowestSpeed)) + slowestSpeed;
	}
}
