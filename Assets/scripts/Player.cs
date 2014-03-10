using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private int health = 3;
    public float speed = 0;
	public float walkSpeed = 8;
	public float runSpeed = 12;

	private Vector3 moveDirection;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
    void Update(){
        if (Input.GetKey(KeyCode.LeftShift)){
            speed = runSpeed;
            Debug.Log("speed; " + speed);
        }
        else{
            speed = walkSpeed;
        }
        
        Vector3 newPosition = transform.position;
        newPosition.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        newPosition.y += Input.GetAxis("Vertical") * speed * Time.deltaTime;
        newPosition.z = -2.16366f;
        transform.position = newPosition;
    }

    void OnCollisionEnter(Collision theCollision){
        Debug.Log("Hit something");
     if(theCollision.gameObject.tag == "wall"){
         Debug.Log("Hit the wall");
     }
     else if (theCollision.gameObject.tag == "door") {
         Debug.Log("Hit the door");
     }
    }

}
