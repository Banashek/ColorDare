﻿using UnityEngine;
using System.Collections;

public class AudioScript : MonoBehaviour {


	void Awake(){
		DontDestroyOnLoad(gameObject);
	}


}
