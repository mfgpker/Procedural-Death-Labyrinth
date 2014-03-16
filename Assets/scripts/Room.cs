using UnityEngine;
using System.Collections;
using System.Linq;
public class Room : MonoBehaviour {

    private GameObject doorE, doorW, doorN, doorS;
    private GameObject spawnE, spawnW, spawnN, spawnS;
    public GameObject NewFloor;
    private Vector3 size;
    public bool isBoosRoom = false;
    public GameObject[] monsters;
     public GameObject[] bossmonsters;
    public GameObject[] spawnsm;
    public Texture open, locke, none, boss, keyneed;
    [HideInInspector]
    public int numbermobs = 0;
    public int ID;
    public bool clear;
    private GameObject mainCamera;
    public bool notroom = false;
    public bool currentRoom = false;
    public bool starterroom = false;
    //private string[] dirs = { "doorN", "doorS", "doorE", "doorW" };
    [HideInInspector]
    public locked dw, de, dn, ds;
    public bool isinthebossroom = false;
    public GameObject objboss;



	void Start () {
        if (!notroom) {
 
            //var spawnsm1 = transform.Cast<GameObject>().Where(c => c.gameObject.tag == "spawnM").ToArray();
            mainCamera = transform.FindChild("Camera").gameObject;
            doorN = transform.FindChild("DoorN").gameObject;
            doorS = transform.FindChild("DoorS").gameObject;
            doorW = transform.FindChild("DoorW").gameObject;
            doorE = transform.FindChild("DoorE").gameObject;

            dn = (locked)doorN.GetComponent(typeof(locked));
            ds = (locked)doorS.GetComponent(typeof(locked));
            dw = (locked)doorW.GetComponent(typeof(locked));
            de = (locked)doorE.GetComponent(typeof(locked)); 
            /*
            doorN.renderer.material.mainTexture = open;
            doorS.renderer.material.mainTexture = open;
            doorW.renderer.material.mainTexture = open;
            doorE.renderer.material.mainTexture = open;
            */

            spawnN = transform.FindChild("spawnN").gameObject;
            spawnE = transform.FindChild("spawnE").gameObject;
            spawnW = transform.FindChild("spawnW").gameObject;
            spawnS = transform.FindChild("spawnS").gameObject;
            SpawnMonster();

           
        }

	}

    


    public void unlockdoor() {
        dn.islocked = false;
        de.islocked = false;
        dw.islocked = false;
        ds.islocked = false;

        string[] room = GameManager.init.getRoomsAroundyou();

        for (int i = 0; i < room.Length; i++) {
            if (room[i] != "none") {
                setDoorTexture(room[i], "open");
            }
        }
    }



    public void mobdown() {
        numbermobs--;
        Debug.Log("mobdown: " + numbermobs);
        if (numbermobs <= 0) {
            unlockdoor();
        }
        if(GameManager.init.getRoomByCurrently().currentRoom)
        audio.PlayOneShot(audio.clip);
    }

    public int getnumberofmobs() {

        return numbermobs;
    }

    private void SpawnMonster(){
       
        int ran = Random.Range(0, 16);
       
        if (ran <= 4) {
            for (int i = 0; i < spawnsm.Length; i++) {
                GameObject m =  (Instantiate(monsters[0], spawnsm[i].transform.position, spawnsm[i].transform.rotation)) as GameObject;
                m.transform.parent = transform;
                numbermobs++;
            }
                
        }
        else if (ran >= 5 && ran <= 8) {
            for (int i = 0; i < spawnsm.Length; i++) {
                GameObject m = (Instantiate(monsters[1], spawnsm[i].transform.position, spawnsm[i].transform.rotation)) as GameObject;
                m.transform.parent = transform;
                numbermobs++;
            }
        }
        else if (ran >= 9 && ran <= 12) {
            for (int i = 0; i < spawnsm.Length; i++) {
                GameObject m = (Instantiate(monsters[2], spawnsm[i].transform.position, spawnsm[i].transform.rotation)) as GameObject;
                m.transform.parent = transform;
                numbermobs++;
            }
        }
        else if (ran >= 13 && ran <= 16) {
            Debug.Log("FREE ROOM");
            numbermobs = 0;

        }
        
        //boss
        
        
    }


    public void SetRoom(bool g) {
        currentRoom = g;
    }

    public void disablecam() {
        mainCamera.SetActive(false);
    }

    public int getID() {
        return ID;
    }

    public void setBossroom(bool g) {
        isBoosRoom = g;

    }

    public bool getBossRoom() {
        return isBoosRoom;
    }


    public void setDoorTexture(string door, string texture) {

        if (!notroom) {

            if (door == "doorN") {
                if (texture == "open") {
                    doorN.renderer.material.mainTexture = open;
                    dn.islocked = false;
                }
                else if (texture == "lock") {
                    doorN.renderer.material.mainTexture = locke;
                }
                else if (texture == "boss") {
                    doorN.renderer.material.mainTexture = boss;
                    dn.bosskey = true;
                }
                else if (texture == "keyneed") {
                    doorN.renderer.material.mainTexture = keyneed;
                    dn.needkey = true;
                    dn.islocked = false;
                }
                else {
                    doorN.renderer.material.mainTexture = none;
                }
            }
            else if (door == "doorS") {
                if (texture == "open") {
                    doorS.renderer.material.mainTexture = open;
                    ds.islocked = false;
                }
                else if (texture == "lock") {
                    doorS.renderer.material.mainTexture = locke;
                }
                else if (texture == "boss") {
                    doorS.renderer.material.mainTexture = boss;
                    ds.bosskey = true;
                }
                else if (texture == "keyneed") {
                    doorS.renderer.material.mainTexture = keyneed;
                    ds.needkey = true;
                    ds.islocked = false;
                }
                else {
                    doorS.renderer.material.mainTexture = none;
                }
            }
            else if (door == "doorW") {
                if (texture == "open") {
                    doorW.renderer.material.mainTexture = open;
                    dw.islocked = false;
                }
                else if (texture == "lock") {
                    doorW.renderer.material.mainTexture = locke;
                }
                else if (texture == "boss") {
                    doorW.renderer.material.mainTexture = boss;
                    dw.bosskey = true;
                }
                else if (texture == "keyneed") {
                    doorW.renderer.material.mainTexture = keyneed;
                    dw.needkey = true;
                    dw.islocked = false;
                }
                else {
                    doorW.renderer.material.mainTexture = none;
                }
            }
            else if (door == "doorE") {
                if (texture == "open") {
                    doorE.renderer.material.mainTexture = open;
                    de.islocked = false;
                }
                else if (texture == "lock") {
                    doorE.renderer.material.mainTexture = locke;
                }
                else if (texture == "keyneed") {
                    doorE.renderer.material.mainTexture = keyneed;
                    de.needkey = true;
                    de.islocked = false;
                }
                else if (texture == "boss") {
                    doorE.renderer.material.mainTexture = boss;
                    de.bosskey = true;
                }
                else {
                    doorE.renderer.material.mainTexture = none;
                }
            }
            
        }
    }


    void SetID(int id) {
        ID = id;
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void teleport(string dir, GameObject play) {
        if (dir == "west") {
            play.transform.position = spawnE.transform.position;
        }
        else if (dir == "east") {
            play.transform.position = spawnW.transform.position;
        }
        else if (dir == "north") {
            play.transform.position = spawnS.transform.position;
        }
        else if (dir == "south") {
            play.transform.position = spawnN.transform.position;
        }
        currentRoom = true;
        mainCamera.SetActive(true);
       
    }

    void OnGUI() {
        if(currentRoom) GUI.Label(new Rect(Screen.width / 2, 25, 100, 100), "Room: " + ID);
        
        
    }



}
