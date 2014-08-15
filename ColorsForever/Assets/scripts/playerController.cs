using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	public float maxSpeed = 10f;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask isGround;
	public float jumpForce = 700f;
	public int playerNumber = 1;
	public string playerInputName;
	public Vector3 playerResetPoint;
	public int jumpButton; 

	private ControllerControllerPanelScript controllerSettings;

	void Awake(){
		controllerSettings = GameObject.FindWithTag("ControllerController").GetComponent<ControllerControllerPanelScript>();

	}

	// Use this for initialization
	void Start () {
		jumpButton = controllerSettings.ReturnJumpButton();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, isGround);
		float move = Input.GetAxis (playerInputName);

		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
	}

	void Update() {
		jumpButton = controllerSettings.ReturnJumpButton();

		if(grounded && Input.GetKeyDown("joystick "+playerNumber.ToString()+" button "+jumpButton))
		{
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}
	}

	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Bullet" || coll.gameObject.tag == "Saw")
			Dead ();
	}
	
	void Dead(){
		gameObject.transform.position = playerResetPoint;
		//Application.LoadLevel (0);
	}
}
