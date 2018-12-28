using UnityEngine;
using System.Collections;

public abstract class CLight : MonoBehaviour {

    abstract public bool CheckForPlayer(Transform player);
    abstract public void Toggle();
}
