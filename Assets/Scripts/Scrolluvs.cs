using UnityEngine;
using System.Collections;

public class Scrolluvs : MonoBehaviour {
	public float offset = 0.5F;
	public float scrollSpeed = 2f;
	public Renderer rend;

	void Start() {
		rend = GetComponent<Renderer>();
	}
	void Update() {
		float offset = Time.time * scrollSpeed;
		rend.material.SetTextureOffset("_MainTex", new Vector2(.2f * offset, -1f * offset ));
	}
}