using UnityEngine;

public class CustomImageEffect : MonoBehaviour {
	public Material Effect;
	void OnRenderImage(RenderTexture src, RenderTexture dst) {
		Graphics.Blit(src, dst, Effect);
	}
}
