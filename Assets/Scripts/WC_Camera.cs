using UnityEngine;
using System.Collections;

public class WC_Camera : MonoBehaviour {

public Vector3 staticPosition;	
public bool startMoving = false;
public Transform target;
public Vector3 oldPos;	
public float targetHeight = 0f; 
public float distance = 4.0f; 
public float maxDistance = 7f; 
public float minDistance = 3f; 
public float xSpeed = 250f; 
public float ySpeed = 120f; 
public float yMinLimit = -40f; 
public float yMaxLimit = 80f; 
public float zoomRate = 60f; 
public float rotationDampening = 1.5f; 
private float x = 0.0f; 
private float y = 0.0f; 
public float nv = .3f; 
public Vector3 lagPos;
private Vector3 resetPosition;	
private bool resetPosBlocked;	
public float delay = 7f;
public LayerMask layerMask;	
	
	void FixedUpdate (){
	  lagPos.y = (target.position.y + lagPos.y)*.5f;
	  lagPos = Vector3.Slerp( lagPos, target.position, Time.deltaTime * delay);
	}
	
	
void Start () { 
		lagPos = target.position;
		oldPos = target.position;
		staticPosition = target.position;
   // Vector3 angles = transform.eulerAngles; 
	Vector3	angles = target.eulerAngles;
    x = angles.y; 
    y = angles.x; 
	//InvokeRepeating("storePosition", 0f, .5f);	
   // Make the rigid body not change rotation 
      if (GetComponent<Rigidbody>()) 
      GetComponent<Rigidbody>().freezeRotation = true; 
	
	//GetTarget();
		
	layerMask = ~( 1 << 2 | 1<< 14 ); 
} 

/*void GetTarget(){
	while(target==null){
		GameObject tempObj= GameObject.FindWithTag("cameraTarget");
		if(tempObj!=null) target=tempObj.transform;
		return;
			//yield return null;  
	}
}*/

private bool reset=true;
private float  timeReset=0f;
public float resetDuration=1.5f;
public float defaultDistance=4f;
public bool enableResetWhileMoving=true;

	void storePosition(){
		oldPos = target.position;//	Debug.Log ("StoredPos");	
	}
	
	
	
	
void LateUpdate () { 

		

 /* if (!startMoving)
		{
			if (staticPosition == target.position) return;
			else
			{startMoving = true;}
		}*/
				 
		
   if(!target) 
      return; 
     
 
    if(enableResetWhileMoving){
		if( (Input.GetMouseButtonDown(1) ) && Input.GetAxis("Vertical")>=0){
			reset=true;
			timeReset=Time.time;
			distance=defaultDistance;
			x=target.eulerAngles.y;
			y=5;
		}
    }

   // If either mouse buttons are down, let them govern camera position 
  
  //if (Input.GetMouseButton(0) || (Input.GetMouseButton(1))){ 
	
		if (Input.GetMouseButton(0)) {// if left mouse button
			
   		if(reset) {
   			reset=false;
//   			x=transform.eulerAngles.x;
//   			y=transform.eulerAngles.y;
   		}
   		else{
				
		   if ((Input.GetAxis("Mouse X")!=0 || Input.GetAxis("Mouse Y")!=0) && Input.GetMouseButton(0))
		   		{x += Input.GetAxis("Mouse X") * xSpeed * 0.02f; 
		   		y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f; }
   		}
	// otherwise, ease behind the target if any of the directional keys are pressed 
	} else if(Input.GetAxis("Vertical")>0f || Input.GetAxis("Horizontal") != 0) { 
   		if(reset) {
   			reset=false;
//   			x=transform.position.x;
//   			y=transform.position.y;
   		}
   		else{
	      var targetRotationAngle = target.eulerAngles.y; 
	      var currentRotationAngle = transform.eulerAngles.y; 
	      x = Mathf.LerpAngle(currentRotationAngle, targetRotationAngle, rotationDampening * Time.deltaTime);
   		} 
	}
    else if( Input.GetMouseButtonDown(1)  && Input.GetAxis("Vertical")>=0){
    	reset=true;
		timeReset=Time.time;
		distance=defaultDistance;
		x=target.eulerAngles.y;
		y=5;
    }
   
      
	if(!reset){
			if (Input.GetAxis("Mouse ScrollWheel") != 0){
	   distance -= (Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime) * 3f  * zoomRate * Mathf.Abs(distance);}
	   distance = Mathf.Clamp(distance, minDistance, maxDistance); 
	}
    
   	y = ClampAngle(y, yMinLimit, yMaxLimit); 
   
  
   // ROTATE CAMERA:
   // POSITION CAMERA:
	//lagPos = target.position;
   Quaternion rotation = Quaternion.Euler(y, x, 0); //original
		
   Vector3 position = lagPos - (rotation * Vector3.forward * distance + new Vector3(0,-targetHeight,0)); //original
  //Vector3 position = (Vector3.Lerp (target.position,oldPos, delay * Time.deltaTime) )- (rotation * Vector3.forward * distance + new Vector3(0,-targetHeight,0));
		// position = Vector3.Lerp(transform.position, position, delay * Time.deltaTime);/////// added code to make delay in camera
	//position = transform.Translate((position - transform.position) * (delay * Time.deltaTime), Space.World);
		if(!reset){
	  	transform.rotation = rotation; //original
		transform.position = position;// Vector3.Lerp (transform.position,position, delay * Time.deltaTime); //original
	}
	else {
		//if (!resetPosBlocked) {resetPosition = position;}	
		float timeEscalated =(Time.time-timeReset); /// reset time should be based on distance to reset position normalized
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, timeEscalated/resetDuration/10);
		transform.position = Vector3.Slerp(transform.position, position, timeEscalated/resetDuration/10);
		if(timeEscalated>=resetDuration+0.5f) reset=false; //{reset=false; resetPosBlocked=false;}
	}
 
   
    
    
   
	// IS VIEW BLOCKED?
    RaycastHit hit;
		  Vector3 trueTargetPosition = lagPos - new Vector3(0,-( targetHeight),0);
   // Vector3 trueTargetPosition = target.transform.position - new Vector3(0,-( targetHeight),0);
	// Cast the line to check:
		
	//Vector3 ntpPlus = new Vector3 (transform.position.x, transform.position.y -.05f, transform.position.z);
 
		if (Physics.Linecast (trueTargetPosition, transform.position , out hit,layerMask) ) {
	    	// If so, shorten distance so camera is in front of object:
			float tempDistance = Vector3.Distance (trueTargetPosition, hit.point) - 0.28f; 
			// Finally, rePOSITION the CAMERA: 
			position = lagPos - (rotation * Vector3.forward * tempDistance + new Vector3(0,-targetHeight,0)); 
			//position = target.position - (rotation * Vector3.forward * tempDistance + new Vector3(0,-targetHeight,0)); 
			transform.position = position; reset= false; 
			
		//if (reset)	{resetPosition = position; resetPosBlocked = true;}
		
	}
//if (Physics.Linecast (trueTargetPosition, transform.position, out hit) )adjustCam (hit,rotation, Vector3.zero); 		
//else if (Physics.Linecast (trueTargetPosition, (transform.position + new Vector3 (-nv,0,0)), out hit) )adjustCam (hit,rotation, new Vector3 (nv,0,0) ); 
//else if (Physics.Linecast (trueTargetPosition, (transform.position + new Vector3 (0,-nv,0)), out hit) )adjustCam (hit,rotation, new Vector3 (0,nv,0)); 		
//else if (Physics.Linecast (trueTargetPosition, (transform.position + new Vector3 (0,0,-nv)), out hit) )adjustCam (hit,rotation, new Vector3 (0,0,nv)); 
//else if (Physics.Linecast (trueTargetPosition, (transform.position + new Vector3 (nv,0,0)), out hit) )adjustCam (hit,rotation, new Vector3 (-nv,0,0)); 	
//else if (Physics.Linecast (trueTargetPosition, (transform.position + new Vector3 (0,nv,0)), out hit) )adjustCam (hit,rotation, new Vector3 (0,-nv,0)); 		
//else if (Physics.Linecast (trueTargetPosition, (transform.position + new Vector3 (0,0,nv)), out hit) )adjustCam (hit,rotation, new Vector3 (0,0,-nv)); 		
		//if  (!IsInvoking("storePosition"))
  //          Invoke("storePosition", .33f);	
		
		
		
		
}
	
void adjustCam ( RaycastHit hit, Quaternion rotation, Vector3 nudge  )	
	{
		//  shorten distance so camera is in front of object:
			float tempDistance = hit.distance - 0.28f; 
			// Finally, rePOSITION the CAMERA:
			transform.position = (target.position - (rotation * Vector3.forward * tempDistance + new Vector3(0,-targetHeight,0)))+ (hit.normal * .03f); 
	}
	

static float ClampAngle ( float angle, float min, float max) { 
   if (angle < -360) 
      angle += 360; 
   if (angle > 360) 
      angle -= 360; 
   return Mathf.Clamp (angle, min, max); 
   
}
}
