using UnityEngine;
using System.Collections;
[RequireComponent(typeof(CharacterController))]
public class Enemy1Script : MonoBehaviour {

	public GameObject Player;
	public GameObject Enemy1;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
	}

	public float huntRange = 9f;
	public float speed = 0.1f;
	public float step;
	public float followdist;// = transform.position - Player.transform.position;
	public float Playerradius = 1f ;// Player.GetComponent;
    public Vector3 enemy_direction;
    public Vector3 enemy_movement;
	// Update is called once per frame
	void Update () {
        CharacterController enemyController = GetComponent<CharacterController>();
        enemy_direction = Player.transform.position - transform.position;
        enemy_movement = enemy_direction.normalized * speed * Time.deltaTime;

		followdist = Vector3.Distance(transform.position, Player.transform.position);
		step = speed - Time.deltaTime;
		if ((followdist < huntRange) && ( Vector3.Distance(transform.position, Player.transform.position) > Playerradius)) {
            //transform.position = Vector3.MoveTowards (transform.position, Player.transform.position, step);
            if(enemy_movement.magnitude > enemy_direction.magnitude) enemy_movement = enemy_direction;
            enemyController.Move(enemy_movement);
			
		}
        if (Player != null)
        {
            transform.LookAt(Player.transform.position);
        }

    }

    public void OnDeath()
    {
        Destroy(gameObject);
    }
}




