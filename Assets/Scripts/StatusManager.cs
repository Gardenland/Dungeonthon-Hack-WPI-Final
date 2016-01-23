using UnityEngine;
using System.Collections;

public class StatusManager : MonoBehaviour {

	public int health = 100;
	public int attack = 30;

	void ApplyDamage(int damage){
		health -= damage;
		if (health <= 0) {
			Destroy (this.gameObject);
		}
	
	
	}
		
}
