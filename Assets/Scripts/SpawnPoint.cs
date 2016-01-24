using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

    public string EnemyType;
    public bool SpawnOnStart;
    public bool WaitForMobDeath;
    public float RespawnTime;
    public GameObject Mob;

	// Use this for initialization
	void Start () {
        if (Mob == null)
        {
            if (SpawnOnStart)
                SpawnMob();
            else
                StartCoroutine(DelayedSpawn());
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.75F);
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
    }

    public IEnumerator DelayedSpawn()
    {
        yield return new WaitForSeconds(RespawnTime);
        SpawnMob();
    }

    public void SpawnMob()
    {
        Mob = Instantiate(Resources.Load(EnemyType), transform.position, transform.rotation) as GameObject;
        if(WaitForMobDeath)
            Mob.GetComponent<EnemyBehavior>().Spawn = this;
        else
            StartCoroutine(DelayedSpawn());
    }
}
