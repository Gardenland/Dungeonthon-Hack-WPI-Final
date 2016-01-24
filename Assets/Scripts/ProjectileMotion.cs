using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileMotion : MonoBehaviour {
    public float ArrowSpeed = 0;


    void OnTriggerEnter(Collider collider)
    {
            if ( collider.gameObject != null)
            {
				Rigidbody arrowBody = gameObject.GetComponent<Rigidbody>();
				arrowBody.velocity = Vector3.zero;
                //Destroy(gameObject,0.05f);
            }
    }

	void OnCollision(Collider collider)
	{
		
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
