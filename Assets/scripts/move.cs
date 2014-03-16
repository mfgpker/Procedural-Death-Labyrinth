using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
    Vector3 speed;
    float timing;
 
    void Start() { 
        // I reckon you are in 2D so z is 0
        speed = new Vector3(Random.Range(-5, 5),Random.Range(-5, 5),0); 
        timing = 0;
    }

    void FixedUpdate() { 
        timing+=Time.deltaTime;
        rigidbody.MovePosition(rigidbody.position + speed * Time.deltaTime); 
        if(timing > 3){
            ChangeDirection();
            timing = 0;
        }
    }

    void ChangeDirection() {

        speed = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
    }

}
