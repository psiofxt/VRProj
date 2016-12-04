using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {

	public float theSpeed;
	public float mouseSens;
	public float mouseYRange = 60.0f;
	private float verticalRotation = 0;

	private float verticalVelocity = 0;
	public float jumpSpeed = 0;
	private CharacterController cc;

	void Start(){
		if (GetComponent<CharacterController>() != null){
			cc = GetComponent<CharacterController>();
		}
		//Screen.lockCursor = true;
		//transform.position = new Vector3(47, 8, 1);
	}

	void Update () {

		/*CAMERA CONTROL*/
		float rotLeftRight = Input.GetAxis("Mouse X") * mouseSens;
		transform.Rotate(0, rotLeftRight, 0);
		verticalRotation -= Input.GetAxis("Mouse Y") * mouseSens;
		verticalRotation = Mathf.Clamp(verticalRotation, -mouseYRange, mouseYRange);
		Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

		/*MOVEMENT*/
		float forwardSpeed = Input.GetAxis("Vertical");
		float sideSpeed = Input.GetAxis("Horizontal");
		if (Input.GetButton("Fire3") && cc.isGrounded){
			forwardSpeed = forwardSpeed * 5;
		}
		Vector3 speed = new Vector3(sideSpeed*theSpeed, 0, forwardSpeed*theSpeed);
		verticalVelocity += Physics.gravity.y * Time.deltaTime;

		if (cc.isGrounded && Input.GetButton("Jump")){
			verticalVelocity = jumpSpeed;
		}

		speed = transform.rotation * speed;
		cc.Move(speed * Time.deltaTime);

	}
}
