using UnityEngine;
using System.Collections;

public class User_Attack : MonoBehaviour {

    public System.Collections.Generic.List<GameObject> collidingObjects = new System.Collections.Generic.List<GameObject>();

    public float cooldown =  0.0f;
    public float MeleeAnimTime = 3f;
    bool Swinging = false;
    public int damage = 5;

    private GameObject swingingWeapon;

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
        if(!Swinging && Time.time - cooldown > 1.5f)
        {
            PlayAnimation();
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

    void PlayAnimation()
    {
        Swinging = true;
        // spawn weapon
        // lerp from y:-90 to y:90 over MeleeAnimTime
        StartCoroutine("StopAnimation");
    }

    IEnumerator StopAnimation()
    {
        yield return new WaitForSeconds(MeleeAnimTime);
        Destroy(swingingWeapon);
        Swinging = false;
    }
}
