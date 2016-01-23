using UnityEngine;
using System.Collections;

public class User_Attack : MonoBehaviour
{

   
    public float cooldown = 0.0f;
    public float MeleeAnimTime = 1f;
    bool Swinging = false;
    public int damage = 5;
    public int arrow_damage = 20;
    public float shot_delay = 0;
    public float shot_cooldown = 0;
    public float speed = 0;

    private GameObject swingingWeapon;

    float arrow_spawn_dist = 2.0f;
    GameObject arrow;



    // Use this for initialization
    void Start()
    {
        
        MeleeAnimTime = 1;
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
            StartAnimation();
            cooldown = Time.time;
        }
    }

    void StartAnimation()
    {
        Swinging = true;
        Quaternion rot = Quaternion.Euler(gameObject.transform.rotation.eulerAngles + new Vector3(0, 90, 0));
        swingingWeapon = Instantiate(Resources.Load("Sword"), transform.position, rot) as GameObject;
        swingingWeapon.transform.parent = transform;

        StartCoroutine(PlayAnimation(gameObject.transform.rotation.eulerAngles + new Vector3(0, -89, 0), MeleeAnimTime));
        StartCoroutine("StopAnimation");
    }

    IEnumerator PlayAnimation(Vector3 byAngles, float inTime)
    {
        var fromAngle = swingingWeapon.transform.rotation;
        var toAngle = Quaternion.Euler(byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            swingingWeapon.transform.rotation = Quaternion.Lerp(fromAngle, toAngle, t);
            yield return null;
        }
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
