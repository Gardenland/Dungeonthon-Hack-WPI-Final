using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    //public GameObject Camera;
    //Need transform object
	public Vector3 playerOffset = new Vector3(-12f, 15f, 2f);
    Transform player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
		transform.position = player.transform.position + playerOffset;
		transform.rotation = Quaternion.Euler(45, 90, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if(player != null)
		    transform.position = Vector3.LerpUnclamped(transform.position, player.transform.position + playerOffset,  Time.smoothDeltaTime *2);
        //transform.rotation = Quaternion.Euler(45, 90, 0);
	}
}
