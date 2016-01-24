using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour {

    public int HealthValue;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject != null)
        {
            Stats stats = collider.gameObject.GetComponent<Stats>();
			if (stats != null) {
				stats.Health += HealthValue;
				Destroy (gameObject);
			}
        }
    }
}
