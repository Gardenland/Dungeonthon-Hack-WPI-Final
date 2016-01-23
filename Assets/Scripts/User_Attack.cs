using UnityEngine;
using System.Collections;

public class User_Attack : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("Pressed left click.");

			RaycastHit hit;

			if (Physics.SphereCast(this.transform.position, 0.8f, Vector3.forward, out hit, 1)){
				hit.transform.gameObject.SendMessage("ApplyDamage", 25);
			}    





		}
	
	}
}
