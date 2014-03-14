using UnityEngine;
using System.Collections;

public class BulletAI : MonoBehaviour {

    public float speed = 10;
    public string dir;
	void Start () {
	
	}

    public void setDir(string dir) {
        this.dir = dir;
    }

    void FixedUpdate() {
        Vector3 newVelocity = Vector3.zero;
        if (dir == "up") {
            newVelocity.y += speed;
        }
        else if (dir == "down") {
            newVelocity.y -= speed;
        }
        else if (dir == "rigth") {
            newVelocity.x += speed;
        }
        else if (dir == "left") {
            newVelocity.x -= speed;
        } 
       
        
        rigidbody.velocity = newVelocity;

    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision col) {
        //make dmg
        if(col.gameObject.tag != "Player"){
            Destroy(gameObject);

        }
        
    }
}
