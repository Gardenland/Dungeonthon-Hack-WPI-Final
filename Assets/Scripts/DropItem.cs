using UnityEngine;
using System.Collections;

public class DropItem : MonoBehaviour {

    public string Drop;
    public int Percentage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDeath()
    {
		//Debug.Log("Drop Item!!!");
        int num = Random.Range(0, 100);
        if (num < Percentage)
			Instantiate(Resources.Load(Drop), gameObject.transform.position + Vector3.up, gameObject.transform.rotation);
    }

}
