using UnityEngine;
using System.Collections;
[RequireComponent(typeof(CharacterController))]
abstract public class EnemyBehavior : MonoBehaviour
{

    private GameObject Player;

    // Use this for initialization
    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    /* IDEA:
    * Don't target player
    * Target any enemy that enter's its aggro radius
    * Will allow factions to fight
    */

    public float AggroRange = 9f;
    public float MovementSpeed = 0.1f;
    private float currentDist;// = transform.position - Player.transform.position;
    public float AttackRange = 1f;// Player.GetComponent;
    private Vector3 enemy_direction;
    private Vector3 enemy_movement;
    public float Gravity = 10.0f;
    public SpawnPoint Spawn;

    // Update is called once per frame
    public void Update()
    {

        CharacterController enemyController = GetComponent<CharacterController>();
        enemy_direction = Player.transform.position - transform.position;
        enemy_movement = enemy_direction.normalized * MovementSpeed * Time.deltaTime;
        enemy_movement.y -= Gravity * Time.deltaTime;

        currentDist = Vector3.Distance(transform.position, Player.transform.position);
        if ((currentDist < AggroRange))
        {
            if (Vector3.Distance(transform.position, Player.transform.position) > AttackRange)
            {
                //transform.position = Vector3.MoveTowards (transform.position, Player.transform.position, step);
                if (enemy_movement.magnitude > enemy_direction.magnitude)
                    enemy_movement = enemy_direction;
                enemyController.Move(enemy_movement);
            }
            else
            {
                Attack();
            }
        }

        if (Player != null)
        {
            // Look at including x and z leaning
            transform.LookAt(Player.transform.position);

            // Euler angles are easier to deal with. You could use Quaternions here also
            // C# requires you to set the entire rotation variable. You can't set the individual x and z (UnityScript can), so you make a temp Vec3 and set it back
            Vector3 eulerAngles = transform.rotation.eulerAngles;
            eulerAngles.x = 0;
            eulerAngles.z = 0;

            // Set the altered rotation back
            transform.rotation = Quaternion.Euler(eulerAngles);
        }

    }

    public void OnDeath()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().Kills++;
        if(Spawn != null)
            Spawn.StartCoroutine("SpawnMob");
        Destroy(gameObject);
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        Destroy(this);
    }

    abstract public void Attack();
}




