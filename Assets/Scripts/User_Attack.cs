using UnityEngine;
using System.Collections;

public class User_Attack : MonoBehaviour {

    System.Collections.Generic.List<GameObject> collidingObjects = new System.Collections.Generic.List<GameObject>();

    void OnCollisionEnter(Collision collision)
    {
        if(!collidingObjects.Contains(collision.gameObject))
        {
            collidingObjects.Add(collision.gameObject);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (!collidingObjects.Contains(collision.gameObject))
        {
            collidingObjects.Remove(collision.gameObject);
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("Pressed left click.");
            foreach(GameObject obj in collidingObjects)
            {
                obj.GetComponent<Stats>().ApplyDamage(30); // TODO get players str
            }
		}
	
	}
}
