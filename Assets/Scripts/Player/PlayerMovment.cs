using UnityEngine;
using System.Collections;

public class PlayerMovment : MonoBehaviour {
	public float MovementSpeed = 5.0f;
	public float SprintSpeed = 15.0f;
	private float speed;

	void Start() {
		speed = MovementSpeed;
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.LeftShift)) {
			speed = SprintSpeed;
		}
		if(Input.GetKeyUp(KeyCode.LeftShift)) {
			speed = MovementSpeed;
		}

		if(Input.GetKey(KeyCode.W)) {
			transform.Translate(Vector3.forward * Time.deltaTime * speed);
		}
		else if(Input.GetKey(KeyCode.S)) {
			transform.Translate(Vector3.back * Time.deltaTime * speed);
		}
		else if(Input.GetKey(KeyCode.A)) {
			transform.Translate(Vector3.left * Time.deltaTime * speed);
		}
		else if(Input.GetKey(KeyCode.D)) {
			transform.Translate(Vector3.right * Time.deltaTime * speed);
		}
	}
}
