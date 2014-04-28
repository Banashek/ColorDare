using UnityEngine;
using System.Collections;

public class nextLevelLoad : MonoBehaviour {

	public int nextLevel;
	
	void OnCollisionEnter2D(Collision2D coll) {
		//Debug.Log (coll.gameObject.tag);
		//Debug.Log (nextLevel);
		if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Saw") {
			Application.LoadLevel(nextLevel);
		}
	}
}
