using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileMotion : MonoBehaviour {
    public float ArrowSpeed = 0;


    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(gameObject + " Triggered");
            if ( collider.gameObject != null)
            {
				Rigidbody arrowBody = gameObject.GetComponent<Rigidbody>();
				arrowBody.velocity = Vector3.zero;
                Destroy(gameObject,0.25f);
            }
    }

	void OnCollision(Collider collider)
	{
        Debug.Log(gameObject + " Collided");
        Rigidbody arrowBody = gameObject.GetComponent<Rigidbody>();
		arrowBody.velocity = Vector3.zero;
		Destroy(gameObject, 0.5f);
	}

	// Use this for initialization
	void Start () {
        Rigidbody clone_body;
        clone_body = gameObject.GetComponent<Rigidbody>();
        clone_body.velocity = transform.forward * ArrowSpeed;
        clone_body.AddForce(transform.forward * ArrowSpeed, ForceMode.Force);
    }
	
	// Update is called once per frame
	void Update () {

	}

   
}
