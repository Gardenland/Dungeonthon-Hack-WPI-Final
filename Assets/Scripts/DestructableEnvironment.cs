using UnityEngine;
using System.Collections;

public class DestructableEnvironment : MonoBehaviour {
	public int cooldown = 10;
	public void OnDeath()
	{
		//Destroy(gameObject);
		StartCoroutine ("respawn");
	}

	IEnumerator respawn(){
		Renderer rend;
		rend = GetComponent<Renderer> ();
		rend.enabled = false;

		Collider collider;
		collider = GetComponent<Collider> ();
		collider.enabled = false;


		yield return new WaitForSeconds(cooldown);
		rend.enabled = true;
		collider.enabled = true;

		



	}

}
