using EventHandler = System.EventHandler;
using EventArgs = System.EventArgs;

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {
	public float temprature = 1f;
	public float heatLost = .003f;
	Slider slider;
	FrostEffect frost;
	BurnEffect burn;
	new Camera camera;

	public event EventHandler Died;
	public float Temprature {
		get { return temprature; }
		set {
			temprature = value;
			slider.value = temprature;
			frost.FrostAmount = Mathf.Clamp(1 - temprature, 0, 1);
			burn.FrostAmount = Mathf.Clamp(temprature - 1, 0, 1);
			if(temprature <= 0f) {
				OnDied(null);
			}
			if(temprature > 1.2f) {
				OnDied(null);
			}
		}
	}

	void Awake() {
		slider = GameObject.Find("HUD/Heat").GetComponent<Slider>();
		camera = GetComponentInChildren<Camera>();
		frost = camera.GetComponent<FrostEffect>(); ;
		burn = camera.GetComponent<BurnEffect>(); ;
	}

	void Update() {
		if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) {
			RaycastHit hit;
			if(Physics.Raycast(transform.position, Camera.main.transform.forward, out hit, 10)) {
				Switch _switch = hit.transform.gameObject.GetComponent<Switch>();
				if(_switch != null) {
					_switch.Interact(this);
				}
			}
		}
	}

	void FixedUpdate() {
		Temprature -= heatLost;
	}

	void OnDied(EventArgs e) {
		Died(this, e);
		gameObject.GetComponent<PlayerMovement>().enabled = false;
		gameObject.GetComponent<MouseLook>().enabled = false;
		camera.gameObject.GetComponent<MouseLook>().enabled = false;
	}
}
