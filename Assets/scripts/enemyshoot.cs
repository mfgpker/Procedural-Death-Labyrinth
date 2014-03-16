using UnityEngine;
using System.Collections;

public class enemyshoot : MonoBehaviour {

    public GameObject bullet;
    public float mininumShootDelay = 1.0f;
    public float maxinumShootDelay = 5.0f;


    // Use this for initialization
    void Start() {
        Invoke("ShootFunction", Random.Range(mininumShootDelay, maxinumShootDelay));
    }

    void ShootFunction() {
 
            GameObject bul = (Instantiate(bullet, transform.position, transform.rotation)) as GameObject;
            //bul.transform.parent = transform;
            GameObject bul1 = (Instantiate(bullet, transform.position, transform.rotation)) as GameObject;
            //bul1.transform.parent = transform;
            GameObject bul2 = (Instantiate(bullet, transform.position, transform.rotation)) as GameObject;
            //bul2.transform.parent = transform;
            GameObject bul3 = (Instantiate(bullet, transform.position, transform.rotation)) as GameObject;
            //bul3.transform.parent = transform;

            bul.SendMessage("setDir", "up");
            bul1.SendMessage("setDir", "rigth");
            bul2.SendMessage("setDir", "down");
            bul3.SendMessage("setDir", "left");

        Invoke("ShootFunction", Random.Range(mininumShootDelay, maxinumShootDelay));
    }
}
