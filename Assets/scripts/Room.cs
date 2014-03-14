using UnityEngine;
using System.Collections;
using System.Linq;
public class Room : MonoBehaviour {

    private GameObject doorE, doorW, doorN, doorS;
    private GameObject spawnE, spawnW, spawnN, spawnS;
    private Vector3 size;
    private bool isBoosRoom = false;
    public GameObject[] monsters;
    public GameObject[] spawnsm;
    public Texture open, locke, none;
    
    public int ID;
    public bool clear;
    private GameObject mainCamera;
    public bool notroom = false;
    public bool currentRoom = false;


	void Start () {
        if (!notroom) {
           
            //var spawnsm1 = transform.Cast<GameObject>().Where(c => c.gameObject.tag == "spawnM").ToArray();
            mainCamera = transform.FindChild("Camera").gameObject;
            doorN = transform.FindChild("DoorN").gameObject;
            doorS = transform.FindChild("DoorS").gameObject;
            doorW = transform.FindChild("DoorW").gameObject;
            doorE = transform.FindChild("DoorE").gameObject;

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

    private void SpawnMonster(){
        int spawnIndex = Random.Range(0, spawnsm.Length - 1);
        int ran = Random.Range(0, 16);
        if (ran <= 4) {
            for (int i = 0; i < spawnsm.Length; i++) {
                GameObject m =  (Instantiate(monsters[0], spawnsm[i].transform.position, spawnsm[i].transform.rotation)) as GameObject;
                m.transform.parent = transform;
            }
                
        }
        else if (ran >= 5 && ran <= 8) {
            for (int i = 0; i < spawnsm.Length; i++) {
                GameObject m = (Instantiate(monsters[1], spawnsm[i].transform.position, spawnsm[i].transform.rotation)) as GameObject;
                m.transform.parent = transform;
            }
        }
        else if (ran >= 9 && ran <= 12) {
            for (int i = 0; i < spawnsm.Length; i++) {
                GameObject m = (Instantiate(monsters[2], spawnsm[i].transform.position, spawnsm[i].transform.rotation)) as GameObject;
                m.transform.parent = transform;
            }
        }
        else if (ran >= 13 && ran <= 16) {
            Debug.Log("FREE ROOM");
        }
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
    

    public void setDoorTexture(string door, string texture){

        if (!notroom) {
            if (door == "doorN") {
                if (texture == "open") {
                    doorN.renderer.material.mainTexture = open;
                }
                else if (texture == "lock") {
                    doorN.renderer.material.mainTexture = locke;
                }
                else {
                    doorN.renderer.material.mainTexture = none;
                }
            }
            else if (door == "doorS") {
                if (texture == "open") {
                    doorS.renderer.material.mainTexture = open;
                }
                else if (texture == "lock") {
                    doorS.renderer.material.mainTexture = locke;
                }
                else {
                    doorS.renderer.material.mainTexture = none;
                }
            }
            else if (door == "doorW") {
                if (texture == "open") {
                    doorW.renderer.material.mainTexture = open;
                }
                else if (texture == "lock") {
                    doorW.renderer.material.mainTexture = locke;
                }
                else {
                    doorW.renderer.material.mainTexture = none;
                }
            }
            else if (door == "doorE") {
                if (texture == "open") {
                    doorE.renderer.material.mainTexture = open;
                }
                else if (texture == "lock") {
                    doorE.renderer.material.mainTexture = locke;
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


    public void moveCamera() {
        //ector3 campos = mainCamera.transform.position;
        //mainCamera.transform.position = new Vector3(campos.x, campos.y, campos.z);
    }
}
