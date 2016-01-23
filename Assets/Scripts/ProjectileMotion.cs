using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileMotion : MonoBehaviour {
    public System.Collections.Generic.List<GameObject> collidingObjects = new System.Collections.Generic.List<GameObject>();
    //public Rigidbody arrow_body;
    public float speed;
    GameObject arrow;
    GameObject player;
    public int damage = 10;
    public float shot_delay = 10;
    public float shot_cooldown = 0;


    void OnTriggerEnter(Collider collider)
    {
        if (!collidingObjects.Contains(collider.gameObject))
        {
            collidingObjects.Add(collider.gameObject);
            if (collider.gameObject.Equals(GameObject.FindGameObjectWithTag("Enemy")) && collider.gameObject != null)
            {
                collider.gameObject.GetComponent<Stats>().ApplyDamage(damage); // TODO get players str
                Destroy(this);
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collidingObjects.Contains(collider.gameObject))
        {
            collidingObjects.Remove(collider.gameObject);
        }
        if (collider.gameObject.Equals(GameObject.FindGameObjectWithTag("Enemy")))
        {
            if(collider.gameObject.GetComponent<Stats>().Health <= 0)
            {
                collidingObjects.Remove(collider.gameObject);
            }
        }
    }

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        arrow = GameObject.FindGameObjectWithTag("Arrow");
        //Rigidbody arrow_body = arrow.GetComponent<Rigidbody>();
        //shot_delay = 3f;
      //  shot_cooldown = 1f;
	}
	
	// Update is called once per frame
	void Update () {

	}

   
}
