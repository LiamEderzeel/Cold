using EventArgs = System.EventArgs;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHUD : MonoBehaviour {
	public GameManager gameManager;

	void Start() {
		gameManager.GameOver += OnGameOver;
		gameObject.SetActive(true);
	}

	void OnGameOver(object sender, EventArgs e) {
		gameObject.SetActive(false);
	}
}
