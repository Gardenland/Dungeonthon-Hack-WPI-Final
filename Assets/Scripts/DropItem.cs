using UnityEngine;
using System.Collections;

public class DropItem : MonoBehaviour {

    public string Drop;
    public int Percntage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDeath()
    {
        int num = Random.Range(0, 100);
        if (num < Percntage)
            Instantiate(Resources.Load(Drop), gameObject.transform.position, gameObject.transform.rotation);
    }

}
