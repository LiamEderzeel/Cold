using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatSource : MonoBehaviour {
	public float killRange = 0;

	protected virtual void OnTriggerStay(Collider other) {
		Player player = other.GetComponent<Player>();
		if(player == null) return;

		if(player.Temprature < 1f) {
			player.Temprature += .05f;
		}

		float distance = Vector3.Distance(transform.position, other.transform.position);
		if(distance < killRange) {
			player.Temprature += .01f;
		}
	}
}
