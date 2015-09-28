﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float playerSpeed = 5.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.W))
		{
			transform.Translate (Vector3.forward * Time.deltaTime * playerSpeed);
		} else if (Input.GetKeyDown (KeyCode.S))
		{
			transform.Translate (Vector3.forward * Time.deltaTime * playerSpeed);
		} else if (Input.GetKeyDown (KeyCode.A))
		{
			transform.Translate (Vector3.right * Time.deltaTime * playerSpeed);
		} else if (Input.GetKeyDown (KeyCode.D))
		{
			transform.Translate (Vector3.right * Time.deltaTime * playerSpeed);
		}
	}
}
