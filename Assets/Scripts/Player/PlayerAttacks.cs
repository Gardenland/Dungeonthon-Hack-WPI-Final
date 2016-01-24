using UnityEngine;
using System.Collections;

public class PlayerAttacks : Attacks {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            //Debug.Log ("Pressed left click.");
            MeleeAttack();

        }
        if (Input.GetButtonUp("Fire2"))
        {
            Shoot();
        }

    }
}
