using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour
{

    protected int hp;

    public int initHealth;

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
            {
                gameObject.SendMessage("OnDeath");
                Debug.Log(gameObject + " Died.");
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        Health = initHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ApplyDamage(int damage)
    {
        Health -= damage;

    }
}
