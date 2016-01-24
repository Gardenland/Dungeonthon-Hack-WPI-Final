using UnityEngine;
using System.Collections;
[RequireComponent(typeof(CharacterController))]
public class EnemyBehavior : MonoBehaviour
{

    public GameObject Player;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    /* IDEA:
    * Don't target player
    * Target any enemy that enter's its aggro radius
    * Will allow factions to fight
    */

    public float huntRange = 9f;
    public float speed = 0.1f;
    public float step;
    public float followdist;// = transform.position - Player.transform.position;
    public float Playerradius = 1f;// Player.GetComponent;
    public Vector3 enemy_direction;
    public Vector3 enemy_movement;
    public float enemy_health;
    public float gravity = 10.0f;

    // Update is called once per frame
    void Update()
    {

        CharacterController enemyController = GetComponent<CharacterController>();
        enemy_direction = Player.transform.position - transform.position;
        enemy_movement = enemy_direction.normalized * speed * Time.deltaTime;
        enemy_movement.y -= gravity * Time.deltaTime;
        enemy_health = this.GetComponent<Stats>().Health;

        followdist = Vector3.Distance(transform.position, Player.transform.position);
        step = speed - Time.deltaTime;
        if ((followdist < huntRange))
        {
            if (Vector3.Distance(transform.position, Player.transform.position) > Playerradius)
            {
                //transform.position = Vector3.MoveTowards (transform.position, Player.transform.position, step);
                if (enemy_movement.magnitude > enemy_direction.magnitude)
                    enemy_movement = enemy_direction;
                enemyController.Move(enemy_movement);
            }
            else
            {
                gameObject.GetComponent<Attacks>().MeleeAttack();
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
        Destroy(gameObject);
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        Destroy(this);
    }
}




