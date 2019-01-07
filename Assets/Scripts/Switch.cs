using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {
	public List<HeatSource> lights;

	public void Interact(Player player) {
		for(int i = 0; i < lights.Count; i++) {
			((IHeatSource)lights[i]).Toggle();
		}
	}
}
