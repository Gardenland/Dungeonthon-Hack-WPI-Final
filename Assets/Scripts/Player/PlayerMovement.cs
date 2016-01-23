using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour {
    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;
    public float gravity = 10.0f;

    public float look_speed = 5;
    //Vector3 cur_loc, prev_loc;
    //******************Credit from http://answers.unity3d.com/questions/967574/rotate-a-character-controller-in-the-direction-of.html
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        Vector3 next_dir = new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal"));

        if(next_dir != Vector3.zero){
            transform.rotation = Quaternion.LookRotation(next_dir);
            next_dir.y -= gravity * Time.deltaTime; 
            controller.Move(next_dir/ 8);
        }
    }
}