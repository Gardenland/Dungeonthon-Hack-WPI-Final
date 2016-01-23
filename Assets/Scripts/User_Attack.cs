using UnityEngine;
using System.Collections;

public class User_Attack : MonoBehaviour
{

    public System.Collections.Generic.List<GameObject> collidingObjects = new System.Collections.Generic.List<GameObject>();

    public float cooldown = 0.0f;
    public float MeleeAnimTime = 3f;
    bool Swinging = false;
    public int damage = 5;
    public int arrow_damage = 20;
    public float shot_delay = 0;
    public float shot_cooldown = 0;
    public float speed = 0;

    private GameObject swingingWeapon;

    float arrow_spawn_dist = 2.0f;
    GameObject arrow;

    void OnTriggerEnter(Collider collider)
    {
        //Debug.Log ("There was a collision");
        if (!collidingObjects.Contains(collider.gameObject))
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
    void Start()
    {
        
        MeleeAnimTime = 3;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            //Debug.Log ("Pressed left click.");
            Attack();

        }
        if (Input.GetButtonUp("Fire2"))
        {
            Shoot();
        }

    }

    void Attack()
    {
        if (!Swinging && Time.time - cooldown > 1.5f)
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
        Debug.Log("Playing Anim in class: " + this);
        Swinging = true;
        swingingWeapon = Instantiate(Resources.Load("Sword"), transform.position + arrow_spawn_dist * transform.right, transform.rotation) as GameObject;
        swingingWeapon.transform.parent = transform;
        // lerp from y:-90 to y:90 over MeleeAnimTime
        StartCoroutine("StopAnimation");
    }

    IEnumerator StopAnimation()
    {
        yield return new WaitForSeconds(MeleeAnimTime);
        Destroy(swingingWeapon);
        Swinging = false;
    }

    void Shoot()
    {
        if (Time.time - shot_cooldown > shot_delay)
        {
            GameObject arrow_clone;
            Rigidbody clone_body;
            //shoot
            //Vector3 arrow_spawn = transform.position + new Vector3(0, 0, transform.localPosition.z + 1);
            arrow_clone = Instantiate(Resources.Load("FireArrow"), transform.position + arrow_spawn_dist * transform.forward, transform.rotation) as GameObject;
            clone_body = arrow_clone.GetComponent<Rigidbody>();
            clone_body.velocity = transform.forward * speed;
            clone_body.AddForce(transform.forward * speed, ForceMode.Force);
            Destroy(arrow_clone, 1.5f);



            shot_cooldown = Time.time;
        }
    }
}
