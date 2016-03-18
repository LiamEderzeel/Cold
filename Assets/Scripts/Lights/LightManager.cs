﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightManager : MonoBehaviour {
    public List<CLight> _lights = new List<CLight>();
// [SerializeField] private List<CLight> _lights = new List<CLight>();
    private float _bodyHeat;

	private void Awake ()
    {
        Object[] lights = Object.FindObjectsOfType<CLight>();
        foreach(Object light in lights)
        {
            _lights.Add((CLight)light);
        }
	}

    public bool CheckForLights (Player player)
    {
        for(int i = 0; i < _lights.Count; i++)
        {
            bool inLight = _lights[i].CheckForPlayer(player.transform);
            if(inLight == true)
                return true;
        }
        return false;
    }
}
