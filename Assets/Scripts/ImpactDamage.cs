using UnityEngine;
using System.Collections;

public class ImpactDamage : MonoBehaviour {

    public System.Collections.Generic.List<GameObject> objectsHit = new System.Collections.Generic.List<GameObject>();

    public int Damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log ("There was a collision");
        if (collider.gameObject != null && !objectsHit.Contains(collider.gameObject))
        {
            collider.gameObject.GetComponent<Stats>().ApplyDamage(Damage);
            objectsHit.Add(collider.gameObject);
        }
    }

}
