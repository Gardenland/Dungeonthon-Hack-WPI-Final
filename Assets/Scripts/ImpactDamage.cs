using UnityEngine;
using System.Collections;

public class ImpactDamage : MonoBehaviour {

    public System.Collections.Generic.List<GameObject> objectsHit = new System.Collections.Generic.List<GameObject>();

    public string Faction;
    public int Damage;

    // Use this for initialization
    void Start()
    {

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject != null && !objectsHit.Contains(collider.gameObject))
        {
            Stats stats = collider.gameObject.GetComponent<Stats>();
            if (stats != null && (stats.gameObject.tag.Equals("None") || !stats.gameObject.tag.Equals(Faction)))
                stats.ApplyDamage(Damage);
            objectsHit.Add(collider.gameObject);
        }
    }

}
