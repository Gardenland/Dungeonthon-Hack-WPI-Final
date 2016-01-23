using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour {
    public float speed = 2.5f;
    public float rotateSpeed = 2.5f;

	
	// Update is called once per frame
	void Update () {
        CharacterController charController = GetComponent<CharacterController>();
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 backward = transform.TransformDirection(Vector3.back);
        float currentSpeed; 
        /*
        if (Input.GetAxis("Vertical") > 0){
            currentSpeed = speed * Input.GetAxis("Vertical");
            charController.SimpleMove(forward * currentSpeed);
        }
        if (Input.GetAxis("Vertical") < 0){
            currentSpeed = speed * Input.GetAxis("Vertical");
            charController.SimpleMove(backward * -currentSpeed);
        }
         */
        currentSpeed = speed * Input.GetAxis("Vertical");
        charController.Move(forward *currentSpeed);

        
	}
}
