using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {

	/* Turret rules:
	 * R - rotation
	 * G - rate of fire
	 * B - projectile speed
	 */ 

	public GameObject muzzle;
	public GameObject bulletPrefab;
	[Range(0,256)] public float r,g,b;
	private float rotation,fireRate,bulletSpeed;
	private float fireTime;

	// Use this for initialization
	void Start () {
		fireTime=0;
		rotation=0;
		fireRate=1;//second
		bulletSpeed=5;
	}
	
	// Update is called once per frame
	void Update () {
		GetColors();
		Rotation();
		RateOfFire();
		ProjectileSpeed();
	}

	void GetColors ()
	{
		rotation = (r/256)*360;
		fireRate = (g/256)*1+.2f; // 0->.2f, 256->1.2
		bulletSpeed = (b/256)*100+.1f; //0->.1f, 256->10.1f
	}

	void Rotation(){
		Debug.Log ("red = "+rotation);
		transform.rotation = Quaternion.Euler(0,0,rotation);
	}

	void RateOfFire(){
		fireTime+=Time.deltaTime;
		if(fireTime>fireRate){
			fireTime=0;
			Shoot ();
		}
	}

	void ProjectileSpeed(){

	}

	void Shoot(){
		Debug.Log("Instantiating bullet");
		GameObject bullet = Instantiate(bulletPrefab,muzzle.transform.position,bulletPrefab.transform.rotation) as GameObject;
		Debug.Log("zrot: "+transform.rotation.eulerAngles.z+" cos(zrot)= "+Mathf.Cos(transform.rotation.eulerAngles.z*Mathf.Deg2Rad));
		bullet.rigidbody2D.AddForce(new Vector2(Mathf.Cos(transform.rotation.eulerAngles.z*Mathf.Deg2Rad),Mathf.Sin(transform.rotation.eulerAngles.z*Mathf.Deg2Rad))*bulletSpeed);

	}
}
