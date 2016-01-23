using UnityEngine;
using System.Collections;

public class User_Attack : MonoBehaviour {

    public System.Collections.Generic.List<GameObject> collidingObjects = new System.Collections.Generic.List<GameObject>();

    public float cooldown =  0.0f;
   // bool canAttack = false;
    public int damage = 5;

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
        if (collider.gameObject.Equals(GameObject.FindGameObjectWithTag("Enemy")))
        {
            if (collider.gameObject.GetComponent<Stats>().Health <= 0) //if the enemy dies, remove it from the list of collisions
            {
                collidingObjects.Remove(collider.gameObject);
            }
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButton("Fire1")) {
            //Debug.Log ("Pressed left click.");
            Attack();
            
        }
	
	}

    void Attack()
    {
        if(Time.time - cooldown > 1.5f)
        {
            //canAttack = true;
            foreach (GameObject obj in collidingObjects)
            {
                if (obj.Equals(GameObject.FindGameObjectWithTag("Enemy")) && obj != null)
                {
                    obj.GetComponent<Stats>().ApplyDamage(damage); // TODO get players str
                }

            }
            cooldown = Time.time;
        }
    }
}
