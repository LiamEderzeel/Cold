using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public int temprature = 50;

	void Awake ()
    {
	}

	void Update ()
    {
	}

	public void TransferHeat (int type) {
		if (0 == type) {
			temprature += 40;
		}
		else if (1 == type) {
			if (temprature >= 50) {
				temprature += 30;
			}
			else if (temprature > 50) {
				temprature = 50;
			}
		}
		else {
			temprature += 10;
		}
	}

	void FixedUpdate () {
		temprature -= 20;

	}
}
