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
	private Transform rigg;
	private Transform eye;
	private GameObject rig;

	void Start(){
		rig = GameObject.Find("TEST");
		Debug.Log(rig.transform.GetChild(0));
		rigg = rig.transform.GetChild(0);
		eye = rigg.transform.GetChild(2);
		if (GetComponent<CharacterController>() != null){
			cc = GetComponent<CharacterController>();
		}
		//Screen.lockCursor = true;
		//transform.position = new Vector3(47, 8, 1);
	}

	void Update () {
		//eye = rig.transform.GetChild(2);
		//this.transform.position = eye.position - eye.localPosition;
		//Debug.Log(this.transform.position.y);
		//this.transform.parent.parent.transform.position = new Vector3(0, this.transform.position.y, 0);
		//Vector3 offset = this.transform.position - eye.position;
		//Debug.Log(offset);
		//this.transform.position += offset;
		//foreach (Transform child in this.transform) {
            //Debug.Log(child.position);
        //}
		cc = GetComponent<CharacterController>();
		if (cc.isGrounded){
			//Debug.Log(cc.isGrounded);
			//this.transform.position = eye.position;
			//FOLLOW THE EYES
			}
		else{
			//eye.parent.parent.transform.position = new Vector3(0, this.transform.position.y, 0);
			//Debug.Log(cc.isGrounded);
		}

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
		Vector3 speed = new Vector3(sideSpeed*theSpeed, verticalVelocity, forwardSpeed*theSpeed);
		verticalVelocity += Physics.gravity.y * Time.deltaTime;

		//if (cc.isGrounded){
			//verticalVelocity = 0;
		//}

		if (cc.isGrounded && Input.GetButton("Jump")){
			verticalVelocity = jumpSpeed;
		}

		speed = transform.rotation * speed;
		cc.Move(speed * Time.deltaTime);

	}
}
