﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour {
	public float speed;

	void Start() {
	}

	void Update() {
		transform.Rotate(Vector3.up * speed * Time.deltaTime, Space.World);
	}
}