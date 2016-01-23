using UnityEngine;
using System.Collections;

public class User_Attack : MonoBehaviour {

    public System.Collections.Generic.List<GameObject> collidingObjects = new System.Collections.Generic.List<GameObject>();

	void OnTriggerEnter(Collider collider)
    {
		//Debug.Log ("There was a collision");
        if(!collidingObjects.Contains(collider.gameObject))
        {
            collidingObjects.Add(collider.gameObject);
        }
    }

	void OnTriggerExit(Collider collider)
    {
		//Debug.Log ("There is no longer a collision");
        if (collidingObjects.Contains(collider.gameObject))
        {
            collidingObjects.Remove(collider.gameObject);
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			//Debug.Log ("Pressed left click.");
            foreach(GameObject obj in collidingObjects)
            {
                if(obj.Equals(GameObject.FindGameObjectWithTag("Enemy")))
                obj.GetComponent<Stats>().ApplyDamage(30); // TODO get players str
            }
		}
	
	}
}
