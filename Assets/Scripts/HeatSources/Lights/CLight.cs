using UnityEngine;
using System.Collections;

public interface ICLight {
	bool CheckForPlayer(Transform player);
	void Toggle();
}
