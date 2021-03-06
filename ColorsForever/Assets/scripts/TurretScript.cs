﻿using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {

	/* Turret rules:
	 * R - rotation
	 * G - rate of fire
	 * B - projectile speed
	 */ 

	[Range (1,3)] public int seed;

	public float colorRange = 256;
	public GameObject muzzle;
	public GameObject bulletPrefab;
	[Range(0,256)] public float r,g,b;
	public float rotation, fireRate, bulletSpeed;
	private float fireTime;
	private bool shoot;
	private ColorControlledObjectScript colorProperties;
	private colorPicker colorPicker;

	void Awake(){
		colorProperties = GetComponent<ColorControlledObjectScript>(); 
		colorPicker = GameObject.FindWithTag("Spectrum").GetComponent<colorPicker>();
	}

	// Use this for initialization
	void Start () {
		fireTime=0;
		rotation = transform.rotation.eulerAngles.z;
		fireRate = g;
		bulletSpeed = b;

		seed = Random.Range(1,3);
	}

	void UpdateRandomColorsToProperties(){
		if(seed==1){
			SetRotation(r);
			SetRateOfFire(g);
			SetBulletSpeed(b);
		}else if(seed==2){
			SetRotation(g);
			SetRateOfFire(b);
			SetBulletSpeed(r);
		}else{
			SetRotation(b);
			SetRateOfFire(r);
			SetBulletSpeed(g);
		}
	}
	

	// Update is called once per frame
	void Update () {
		GetColors();
		UpdateRandomColorsToProperties();
		Shoot ();
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
		transform.rotation = Quaternion.Euler(0,0,amount*colorRange);
	}

	void SetRateOfFire(float amount){
		fireRate=amount+.2f;
	}

	void SetBulletSpeed(float amount){
		bulletSpeed = amount*100+5;
	}
	

	void Shoot(){
		fireTime+=Time.deltaTime;
		if(fireTime>fireRate){
			fireTime=0;
			shoot=true;
		}

		if(shoot){
			GameObject bullet = Instantiate(bulletPrefab,muzzle.transform.position,bulletPrefab.transform.rotation) as GameObject;
			bullet.transform.parent = gameObject.transform;
			bullet.rigidbody2D.AddForce(new Vector2(Mathf.Cos(transform.rotation.eulerAngles.z*Mathf.Deg2Rad),Mathf.Sin(transform.rotation.eulerAngles.z*Mathf.Deg2Rad))*bulletSpeed*10);
			shoot=false;
		}

	}
}
