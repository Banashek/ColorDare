using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	float time;

	// Use this for initialization
	void Start () {
		time = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		time+=Time.deltaTime;

		if(time>5.0f) DestroyImmediate(gameObject);
	}
}
