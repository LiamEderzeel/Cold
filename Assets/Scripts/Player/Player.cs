using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public bool _inLight;
    private LightManager _lightManager;

	private void Awake ()
    {
        _lightManager = Object.FindObjectOfType(typeof(LightManager)) as LightManager;
        print(_lightManager);
	}

	private void Update ()
    {
        _inLight = _lightManager.CheckForLights(this);
	}
}
