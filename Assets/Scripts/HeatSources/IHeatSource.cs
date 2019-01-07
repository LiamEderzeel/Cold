using UnityEngine;
using System.Collections;

public interface IHeatSource {
	bool CheckForPlayer(Transform player);
	void Toggle();
}
