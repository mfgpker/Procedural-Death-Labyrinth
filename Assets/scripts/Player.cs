using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	
	public Player instance;
	private int health = 3;
    public float speed = 0;
	public float walkSpeed = 8;
	public float runSpeed = 12;


	private Vector3 moveDirection;

	// Use this for initialization
	void Start () {
		instance = this;
		
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
        transform.position = newPosition;
    }

}
