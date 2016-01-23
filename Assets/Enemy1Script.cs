using UnityEngine;
using System.Collections;

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


	// Update is called once per frame
	void Update () {
		followdist = Vector3.Distance(transform.position, Player.transform.position);
		step = speed - Time.deltaTime;
		if ((followdist < huntRange) && ( Vector3.Distance(transform.position, Player.transform.position) > Playerradius)) {
			transform.position = Vector3.MoveTowards (transform.position, Player.transform.position, step);
			if (Player != null) {
				transform.LookAt(Player.transform.position);
			}
		}

	}
}




