using UnityEngine;
using System.Collections;

public class EyeballBehavior : EnemyBehavior {

    // Use this for initialization
    public new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
   public new void Update()
    {
        base.Update();
    }

    override public void Attack()
    {
        gameObject.GetComponent<Attacks>().RangedAttack();
    }
}
