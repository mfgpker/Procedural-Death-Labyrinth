using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
    public int maxHealth = 3;
    public int health;
    public float healthprocent = 100;
    public bool holdthekey = false;
    public GameObject[] drops;
    public GameObject bosskey;
    public bool isBoss = false;
    public bool isMinions = false;

   

    void start() {
        health = maxHealth;
    }
    public void setkeyholder() {
        holdthekey = true;
        
    }




    void Update() {

        checkifdead();
        if (isBoss) {
            healthprocent = (int)(((float)(health) / (float)(maxHealth)) * 100);
           
        }
        //audio.PlayOneShot(diesound);
    }


    void randommovement() {
        float speed = 10.0f;

        Vector3 vel;

        vel = Random.insideUnitSphere * speed;

        vel.z = 0.0f;

        transform.Translate (vel * Time.deltaTime);
    }

    void checkifdead() {
        if (health <= 0) {

            die();
        }
    }

    void die() {
       
        //GameManager.init.getRoomByCurrently().
        if (!isBoss) {
            int dropitem = Random.Range(0, drops.Length);
            if (holdthekey) Instantiate(bosskey, transform.position, bosskey.transform.rotation);
            else Instantiate(drops[dropitem], transform.position, drops[dropitem].transform.rotation);
            if (!isMinions) {
                GameObject g = transform.parent.gameObject;
                g.SendMessage("mobdown");
            }
        }
        else {
            Room bs = GameManager.init.getRoomByBoss();
            bs.NewFloor.SetActive(true);

        }
        Destroy(transform.gameObject);
    }

    void OnCollisionEnter(Collision col) {

        if (col.gameObject.tag == "bullet") {
            health--;
        }
    }


}
