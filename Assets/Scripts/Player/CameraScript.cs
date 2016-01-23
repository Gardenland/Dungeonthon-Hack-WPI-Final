using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public GameObject Camera;
    //Need transform object
    Transform player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = Camera.transform.position;
        gameObject.transform.rotation = Camera.transform.rotation;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
	}
}
