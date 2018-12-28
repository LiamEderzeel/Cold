using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {
	public int temprature = 50;
	Slider slider;

	void Awake () {
		slider = GameObject.Find("HUD/Heat").GetComponent<Slider>();
	}

	void Update () {
		if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) {
			RaycastHit hit;
			if (Physics.Raycast(transform.position, Camera.main.transform.forward, out hit, 10)) {
				print(hit.transform.name);
				Switch _switch = hit.transform.gameObject.GetComponent<Switch>();
				print(hit.transform.name);
				if (_switch != null) {
					print("test");
					_switch.Interact(this);
				}
			}
		}
	}

	void FixedUpdate () {
		slider.value -= .001f;
		if (slider.value <= 0f) {
			// GameManger.Instance.GameOver();
		}
	}

	public void TransferHeat () {
		slider.value = 1;
	}
}
