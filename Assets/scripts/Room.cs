using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour {

    private GameObject doorE, doorW, doorN, doorS;
    private GameObject spawnE, spawnW, spawnN, spawnS;
    private Vector3 size;
    static Room init;
    static float x, y;
    static public int ID;
    public bool clear;
    private Camera mainCamera;

    private static Room instance = null;
    public static Room SharedInstance {
        get {
            if (instance == null) {
                instance = new Room();
            }
            return instance;
        }
    }

	// Use this for initialization
	void Start () {
        init = this;
        x = transform.position.x;
        y = transform.position.y;
        mainCamera = GameObject.FindWithTag("MainCamera").camera;

        doorN =transform.FindChild("DoorN").gameObject;
        doorS = transform.FindChild("DoorS").gameObject;
        doorW = transform.FindChild("DoorW").gameObject;
        doorE = transform.FindChild("DoorE").gameObject;

        spawnN = transform.FindChild("spawnN").gameObject;
        spawnE = transform.FindChild("spawnS").gameObject;
        spawnW = transform.FindChild("spawnW").gameObject;
        spawnS = transform.FindChild("spawnE").gameObject;

        size = transform.FindChild("ground").renderer.bounds.size;
       
	}

    void SetID(int id) {
        ID = id;
    }
	
	// Update is called once per frame
	void Update () {
       
	}


    public bool controlexist() {

        return false;
    }

    public void moveCamera() {
        Vector3 campos = mainCamera.transform.position;
        mainCamera.transform.position = new Vector3(campos.x, campos.y, campos.z);
    }
}
