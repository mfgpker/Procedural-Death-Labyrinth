using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private int health = 3;
    public float speed = 0;
	public float walkSpeed = 8;
	public float runSpeed = 12;
    
	private Vector3 moveDirection;
    //private BoxCollider collider;
   static public  Room currentRoom;

	void Start () {
        //collider = GetComponent<BoxCollider>();

        
       // GameObject.FindWithTag("MainCamera").camera.transform.position = new Vector3(3.092722f, -0.6933255f, -13.43808f);
	}
    public float damp = 0.9f; // adjust the damp factor if necessary


    void FixedUpdate() {
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftShift)) {
            speed = runSpeed;
            Debug.Log("speed; " + speed);
        }
        else {
            speed = walkSpeed;
        }
        Vector3 p = transform.position;
        Vector3 newPosition = transform.position;       
        newPosition.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        newPosition.y += Input.GetAxis("Vertical") * speed * Time.deltaTime;
        newPosition.z = p.z;

        transform.position = newPosition;
         
    }


    void OnCollisionEnter(Collision theCollision){
         
         if(theCollision.gameObject.tag == "walln"){
             Debug.Log("Hit the walln");
             //transform.position = new Vector3(p.x, p.y, p.z);
         }
         else if (theCollision.gameObject.name == "DoorN") {
             Debug.Log("Hit the DoorN");
             GameManager.init.changeRoom("north");
         }
         else if (theCollision.gameObject.name == "DoorS") {
             Debug.Log("Hit the DoorS");
             GameManager.init.changeRoom("south");
         }
         else if (theCollision.gameObject.name == "DoorE") {
             Debug.Log("Hit the DoorE");
             GameManager.init.changeRoom("east");
         }
         else if (theCollision.gameObject.name == "DoorW") {
             Debug.Log("Hit the DoorW");
             GameManager.init.changeRoom("west");
         }
    }
    

}
