﻿using UnityEngine;
using System.Collections;

public class FloorScript : MonoBehaviour {
	public float scaleX, scaleY;

	void Start () {
		this.transform.localScale += new Vector3(0, 0, 0);
	}

}
