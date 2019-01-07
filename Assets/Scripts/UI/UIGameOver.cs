using EventArgs = System.EventArgs;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameOver : MonoBehaviour {
	public GameManager gameManager;

	void Start() {
		gameManager.GameOver += OnGameOver;
		gameObject.SetActive(false);
	}

	void OnGameOver(object sender, EventArgs e) {
		gameObject.SetActive(true);
	}
}
