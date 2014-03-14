using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private int health = 3;
    public float speed = 0;
	public float walkSpeed = 8;
	public float runSpeed = 12;
    public GameObject bullet;
    public float range = 100;
	private Vector3 moveDirection;
    //private BoxCollider collider;
   static public  Room currentRoom;

	void Start () {
        //collider = GetComponent<BoxCollider>();

        GameManager.init.roomdoor();
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

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            shoot("up");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            shoot("down");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            shoot("left");
            
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            shoot("rigth");
        } 
    }

    private void shoot(string dir) {
        GameObject bul;
        if (dir == "up") {
            bul = (Instantiate(bullet, transform.FindChild("spawnU").gameObject.transform.position, transform.rotation)) as GameObject;
            bul.SendMessage("setDir", dir);
        }
        else if (dir == "down") {
            bul = (Instantiate(bullet, transform.FindChild("spawnD").gameObject.transform.position, transform.rotation)) as GameObject;
            bul.SendMessage("setDir", dir);
        }
        else if (dir == "rigth") {
            bul = (Instantiate(bullet, transform.FindChild("spawnR").gameObject.transform.position, transform.rotation)) as GameObject;
            bul.SendMessage("setDir", dir);
        }
        else if (dir == "left") {
            bul = (Instantiate(bullet, transform.FindChild("spawnL").gameObject.transform.position, transform.rotation)) as GameObject;
            bul.SendMessage("setDir", dir);
            
        } 
       
       
    }

    void OnCollisionEnter(Collision theCollision){
         
         if(theCollision.gameObject.tag == "wall"){
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
