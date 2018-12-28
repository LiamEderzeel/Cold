using UnityEngine;
using System.Collections;

public class LucyGetsFood : MonoBehaviour {

	private void Start()
	{
		StartCoroutine(GetFood());
	}

	IEnumerator GetFood() {
		WWW www = new WWW("lucy.dev/service.php");
		yield return www;
		print (www.text);
	}
}