using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHeater : HeatSource {
	Light light;
	Collider collider;

	void Start() {
		collider = GetComponent<MeshCollider>();
		light = GetComponent<Light>();
	}

	public void Toggle() {
		light.enabled = !light.enabled;
	}
}
