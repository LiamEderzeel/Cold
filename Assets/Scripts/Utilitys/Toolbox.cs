using UnityEngine;

public class Toolbox : Singleton<Toolbox> {
	protected Toolbox () {} // guarantee this will be always a singleton only - can't use the constructor!

	public string myGlobalVar = "whatever";

	public GameManager gameManager = new GameManager();

	void Awake () {

	}

	// (optional) allow runtime registration of global objects
	// static public T RegisterComponent<T> () where T: Component {
	// 	return Instance.GetOrAddComponent<T>();
	// }
}
