using UnityEngine;
using System.Collections;

public class CSpotLight : CLight {
    [SerializeField] private float _angle;

	private void Awake ()
    {
        _angle = this.gameObject.GetComponent<Light>().spotAngle;
	}

	private void Update ()
    {
	}

    override public bool CheckForPlayer (Transform player)
    {
        Vector3 targetDir = player.position - transform.position;
        Vector3 forward = transform.forward;
        float angle = Vector3.Angle(targetDir, forward);
        if (angle < _angle*0.5f && angle > _angle*-0.5f)
        {
            return true;
        }
        return false;
    }
}
