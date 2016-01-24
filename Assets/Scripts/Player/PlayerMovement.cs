using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour {
    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;
    public float gravity = 10.0f;

    public float look_speed = 5;
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        Vector3 next_dir = new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal")) * speed;
        if(next_dir != Vector3.zero){
            transform.rotation = Quaternion.LookRotation(next_dir);
			next_dir.y -= gravity; 
			controller.Move(next_dir * Time.deltaTime);
        }
    }

    public void GameOver()
    {
        Destroy(this);
    }
}