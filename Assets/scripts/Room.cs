using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour {

    private GameObject doorE, doorW, doorN, doorS;
    private GameObject spawnE, spawnW, spawnN, spawnS;
    private Vector3 size;
    private bool isBoosRoom = false;

    public Texture open, locke, none;
    
    public int ID;
    public bool clear;
    private GameObject mainCamera;
    public bool notroom = false;
    public bool currentRoom = false;

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
	// Use this for initialization
	void Start () {
        if (!notroom) {
            mainCamera = transform.FindChild("Camera").gameObject;
            doorN = transform.FindChild("DoorN").gameObject;
            doorS = transform.FindChild("DoorS").gameObject;
            doorW = transform.FindChild("DoorW").gameObject;
            doorE = transform.FindChild("DoorE").gameObject;

            doorN.renderer.material.mainTexture = open;
            doorS.renderer.material.mainTexture = open;
            doorW.renderer.material.mainTexture = open;
            doorE.renderer.material.mainTexture = open;

            spawnN = transform.FindChild("spawnN").gameObject;
            spawnE = transform.FindChild("spawnE").gameObject;
            spawnW = transform.FindChild("spawnW").gameObject;
            spawnS = transform.FindChild("spawnS").gameObject;
        }

	}

    public void setDoorTexture(string door, string texture){
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
        else if (door == "DoorS") {
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
        else if (door == "DoorW") {
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
        else if (door == "DoorE") {
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
