using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

    public string EnemyType;
    public float CheckForMobTime;
    public float RespawnTime;
    public GameObject Mob;

	// Use this for initialization
	void Start () {
        if (Mob == null)
            StartCoroutine(SpawnEnemy());
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.75F);
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
    }

    public IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(RespawnTime);
        Mob = Instantiate(Resources.Load(EnemyType), transform.position, transform.rotation) as GameObject;
        Mob.GetComponent<EnemyBehavior>().Spawn = this;
    }
}
