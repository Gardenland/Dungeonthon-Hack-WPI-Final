using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    //public GameObject Camera;
    //Need transform object
    Transform player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.LerpUnclamped(transform.position, player.transform.position + new Vector3(-16.1f, 17, 16.5f),  Time.smoothDeltaTime);
        transform.rotation = Quaternion.Euler(45, 90, 0);
	}
}
