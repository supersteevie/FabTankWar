﻿using UnityEngine;
using System.Collections;

public class TurningTank : MonoBehaviour {

	private float turningSpeed = 3f;

	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up, turningSpeed * Time.deltaTime);
	}
}
