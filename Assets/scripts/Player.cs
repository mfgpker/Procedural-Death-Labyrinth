using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public int health = 3;
    public float speed = 0;
	public float walkSpeed = 8;
	public float runSpeed = 12;
    public GameObject bullet;
    public float range = 100;
	private Vector3 moveDirection;
    //private BoxCollider collider;
   static public  Room currentRoom;
   public Texture fullheart, halvheart, key, bossKey;
   private int keys = 2;
   private int bosskeys = 0;
   public GUISkin skin;


   public bool godmode = false;
    void Start () {
        FloorManager.init.show = true;
        //collider = GetComponent<BoxCollider>();
        GameManager.init.roomdoor();
        makebossholder();
        FloorManager.init.ne = false;
       // GameObject.FindWithTag("MainCamera").camera.transform.position = new Vector3(3.092722f, -0.6933255f, -13.43808f);
	}
    public float damp = 0.9f; // adjust the damp factor if necessary



    private void makebossholder() {
        GameObject[] mon = GameObject.FindGameObjectsWithTag("monster");
        int theone = Random.Range(0, mon.Length);
        mon[theone].SendMessage("setkeyholder");
    }



    public float fireRate = 0.0001f;
    private float lastShot = 0.0f;

    void FixedUpdate() {
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftShift)) {
            speed = runSpeed;
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

        if (Input.GetKey(KeyCode.UpArrow)) {
            shoot("up");
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            shoot("down");
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            shoot("left");
            
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            shoot("rigth");
        }

        if (health <= 0) {
            died();
            
        }

        if (godmode) health = 100;
    }

    private void died() {
        
        GameManager.init.playerdie();
        DestroyObject(gameObject);
       
    }

    private void shoot(string dir) {
        if (Time.time > fireRate + lastShot) {
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
            lastShot = Time.time;
        }
       
    }

    
    void OnGUI() {
        GUI.skin = skin;
        GUI.DrawTexture(new Rect(15, Screen.height - 100, 50,50), key);
        GUI.Label(new Rect(85, Screen.height - 110, 90, 90), keys.ToString());

        GUI.DrawTexture(new Rect(160, Screen.height - 100, 50, 50), bossKey);
        GUI.Label(new Rect(220, Screen.height - 110, 90, 90), bosskeys.ToString());

        for (int i = 0; i < health; i++) {
            GUI.DrawTexture(new Rect(15 + i * 50, Screen.height - 50, 50, 50), fullheart);
        }

        
    }


    public int getKey() {
        return keys;
    }
    public void useKey() {
        keys--;
    }

    public int getbossKey() {
        return bosskeys;
    }

    public void TakeDamage() {
        health--;
    }

    public void usebossKey() {
        bosskeys--;

        GameObject[] doors = GameObject.FindGameObjectsWithTag("door");
        Debug.Log(doors);
        foreach (GameObject door in doors) {
            door.SendMessage("setbosskey");
        }
    }
    void OnCollisionEnter(Collision theCollision){
         
         if(theCollision.gameObject.tag == "wall"){
             Debug.Log("Hit the walln");
             //transform.position = new Vector3(p.x, p.y, p.z);
         }
         else if (theCollision.gameObject.name == "DoorN") {
             Debug.Log("Hit the DoorN");
             GameManager.init.teleport("north");
         }
         else if (theCollision.gameObject.name == "DoorS") {
             Debug.Log("Hit the DoorS");
             GameManager.init.teleport("south");
         }
         else if (theCollision.gameObject.name == "DoorE") {
             Debug.Log("Hit the DoorE");
             GameManager.init.teleport("east");
         }
         else if (theCollision.gameObject.name == "DoorW") {
             Debug.Log("Hit the DoorW");
             GameManager.init.teleport("west");
         }
         else if (theCollision.gameObject.tag == "monster") {
             health--;
         }
         else if (theCollision.gameObject.tag == "bulleten") {
             health--;
         }

         else if (theCollision.gameObject.tag == "key") {
             Debug.Log("Hit the key");
             keys++;
             Destroy(theCollision.gameObject);
         }
         else if (theCollision.gameObject.tag == "heart") {
             Debug.Log("Hit the heart");
             health++;
             Destroy(theCollision.gameObject);
         }
         else if (theCollision.gameObject.tag == "bosskey") {
             Debug.Log("Hit the bosskey");
             bosskeys++;
             Destroy(theCollision.gameObject);
         }
         else if (theCollision.gameObject.tag == "newfloor") {
             Debug.Log("Hit the newfloor");
             FloorManager.init.addFloor();
             Application.LoadLevel("level1");
         }
        
    }
    

}
