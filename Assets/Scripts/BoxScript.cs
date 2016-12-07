using UnityEngine;
using System.Collections;

public class BoxScript : MonoBehaviour {
	private CharacterController cc;
	private GameObject test;
	private Transform rig, eye;
	// Use this for initialization
	void Start () {
		test = GameObject.Find("TEST");
		rig = test.transform.GetChild(0);
		eye = rig.transform.GetChild(2);
		//cc = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		eye.parent.parent.transform.position = new Vector3(0, this.transform.position.y, 0);
		//Debug.Log(cc.isGrounded);
	}
}
