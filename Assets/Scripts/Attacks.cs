using UnityEngine;
using System.Collections;

public class Attacks : MonoBehaviour
{
    public bool FriendlyFire;

    public string MeleeWeaponName;
    public float MeleeAnimSpeed;
    public float MeleeCooldown;
    private float lastSwingTime;
    private bool Swinging = false;
    private GameObject swingingWeapon;

    public string RangedWeaponName;
    public float RangedCooldown;
    private float lastShotTime;
    private float arrow_spawn_dist = 1.0f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void RangedAttack()
    {
        if (Time.time > lastShotTime + RangedCooldown)
        {
            GameObject arrow;
            arrow = Instantiate(Resources.Load(RangedWeaponName), transform.position + Vector3.up + arrow_spawn_dist * transform.forward, transform.rotation) as GameObject;
            arrow.GetComponent<ImpactDamage>().objectsHit.Add(gameObject);
            Destroy(arrow, 10f);
            lastShotTime = Time.time;
        }
    }

    public void MeleeAttack()
    {
        if (!Swinging && Time.time > lastSwingTime + MeleeCooldown)
        {
            Quaternion rot = Quaternion.Euler(gameObject.transform.rotation.eulerAngles + new Vector3(0, 90, 0));
            swingingWeapon = Instantiate(Resources.Load(MeleeWeaponName), transform.position + Vector3.up, rot) as GameObject;

            swingingWeapon.GetComponent<ImpactDamage>().objectsHit.Add(gameObject);
            swingingWeapon.transform.parent = transform;

            if (FriendlyFire)
                swingingWeapon.GetComponent<ImpactDamage>().Faction = "None";
            else
                swingingWeapon.GetComponent<ImpactDamage>().Faction = gameObject.tag;

            Swinging = true;
            lastSwingTime = Time.time;

            StartCoroutine(PlayAnimation(gameObject.transform.rotation.eulerAngles + new Vector3(0, -89, 0), MeleeAnimSpeed));
        }
    }

    public IEnumerator PlayAnimation(Vector3 byAngles, float inTime)
    {
        var fromAngle = swingingWeapon.transform.rotation;
        var toAngle = Quaternion.Euler(byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime * inTime)
        {
            swingingWeapon.transform.rotation = Quaternion.Lerp(fromAngle, toAngle, t);
            yield return null;
        }
        Destroy(swingingWeapon);
        Swinging = false;
    }


}
