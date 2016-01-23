using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour
{

    protected int hp;
    protected int str;
    protected int def;

    public int Health
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
            if (hp <= 0)
                
                gameObject.BroadcastMessage("OnDeath");
        }
    }

    public int Strength { get; set; }

    public int Defense { get; set; }

    // Use this for initialization
    void Start()
    {
		hp = 50;
		str = 5;
		def = 1;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ApplyDamage(int damage)
    {
        Health -= damage * damage / def;

    }
}
