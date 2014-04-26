using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {

	/* Turret rules:
	 * R - rotation
	 * G - rate of fire
	 * B - projectile speed
	 */ 

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
		rotation=0;
	}
	
	// Update is called once per frame
	void Update () {
		GetColors();
		SetRotation();
		SetRateOfFire();
		Shoot ();
	}

	void GetColors ()
	{
		if(colorProperties.red){
			r = colorPicker.PickedColor.r * colorRange;
			rotation = (r/256)*360;
		}

		if(colorProperties.green){
			g = colorPicker.PickedColor.g * colorRange;
			fireRate = (g/256)*1+.2f; // 0->.2f, 256->1.2
		}

		if(colorProperties.blue){
			b = colorPicker.PickedColor.b * colorRange;
			bulletSpeed = (b/256)*100+5; //0->5, 256->105f
		}

	}

	void SetRotation(){
		Debug.Log ("red = "+rotation);
		transform.rotation = Quaternion.Euler(0,0,rotation);
	}

	void SetRateOfFire(){
		fireTime+=Time.deltaTime;
		if(fireTime>fireRate){
			fireTime=0;
			shoot=true;
		}
	}
	

	void Shoot(){
		if(shoot){
			Debug.Log("Instantiating bullet");
			GameObject bullet = Instantiate(bulletPrefab,muzzle.transform.position,bulletPrefab.transform.rotation) as GameObject;
			Debug.Log("zrot: "+transform.rotation.eulerAngles.z+" cos(zrot)= "+Mathf.Cos(transform.rotation.eulerAngles.z*Mathf.Deg2Rad));
			bullet.rigidbody2D.AddForce(new Vector2(Mathf.Cos(transform.rotation.eulerAngles.z*Mathf.Deg2Rad),Mathf.Sin(transform.rotation.eulerAngles.z*Mathf.Deg2Rad))*bulletSpeed*10);
			shoot=false;
		}

	}
}
