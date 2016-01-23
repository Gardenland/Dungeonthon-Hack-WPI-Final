using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileMotion : MonoBehaviour {
    public System.Collections.Generic.List<GameObject> collidingObjects = new System.Collections.Generic.List<GameObject>();
    //public Rigidbody arrow_body;
    public float shot_delay = 5;
    public float shot_cooldown = 5;
    public float speed = 1.5f;
    GameObject arrow;
    GameObject player;
    public int damage = 10;


    void OnTriggerEnter(Collider collider)
    {
        if (!collidingObjects.Contains(collider.gameObject))
        {
            collidingObjects.Add(collider.gameObject);
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
        Rigidbody arrow_body = arrow.GetComponent<Rigidbody>();
        shot_delay = 3f;
        shot_cooldown = 1f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetButtonUp("Fire2"))
        {
            Shoot();
        }
	}

    void Shoot() {
        if(Time.time - shot_cooldown > shot_delay)
        {
            GameObject arrow_clone;
            Rigidbody clone_body;
            //shoot
                Vector3 arrow_spawn = player.transform.position + new Vector3(0, 0, 2);
                arrow_clone = Instantiate(arrow, arrow_spawn, player.transform.rotation) as GameObject;
                clone_body = arrow_clone.GetComponent<Rigidbody>();
                clone_body.velocity = player.transform.position * -speed;
                clone_body.AddForce(Vector3.forward, ForceMode.Force);
                Destroy(arrow_clone, 3f);
            

            foreach (GameObject obj in collidingObjects)
            {
                if (obj.Equals(GameObject.FindGameObjectWithTag("Enemy")) && obj != null)
                {
                    obj.GetComponent<Stats>().ApplyDamage(damage); // TODO get players str
                }

            }


            shot_cooldown = Time.time;
        }
    }
}
