using UnityEngine;
using System.Collections;

public class DestructableEnvironment : MonoBehaviour {

	public void OnDeath()
	{
		Destroy(gameObject);
	}
}
