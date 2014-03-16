using UnityEngine;
using System.Collections;

public class FloorManager : MonoBehaviour {

    static public FloorManager init;
    public GUISkin skin;
    int floor = 0;
    public bool ne = false;
    public bool show = true;
    public bool first = false;
	// Use this for initialization
	void Start () {
        getobj();
        GameObject[] fl = GameObject.FindGameObjectsWithTag("floormanager");

        if(fl.Length == 1){
            first = true;
        }
        init = this;
	}

    GameObject getobj() {
        GameObject[] fl = GameObject.FindGameObjectsWithTag("floormanager");
        foreach (GameObject f in fl) {
            FloorManager g = f.GetComponent<FloorManager>();
            if(!g.first){
                DestroyObject(g);
            }
        }

        return null;
    }
    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
	// Update is called once per frame
	void Update () {
	
	}

    public void reset() {
        floor = 0;
    }

    public void addFloor() {
        if(!ne)
            floor++;
        ne = true;
    }

    void OnGUI() {
        GUI.skin = skin;
        if(show)
            GUI.Label(new Rect(70, 40, 150, 150), "floor: " + floor);
    }
}
