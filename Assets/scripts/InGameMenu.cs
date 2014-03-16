using UnityEngine;
using System.Collections;

public class InGameMenu : MonoBehaviour {

    public GUISkin skin;
    public bool isMenu = false;
   
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            isMenu = !isMenu;
        }

        if (isMenu) {
           Time.timeScale = 0;
        }
        else {
            Time.timeScale = 1;
        }
	}


    void OnGUI() {
        GUI.skin = skin;
        if (isMenu) {
            if(GUI.Button(new Rect(Screen.width / 2 - 125, 30, 250, 50), "Resume")) {
                isMenu = false;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 125, 90, 250, 50), "Restart")) {
                FloorManager.init.reset();
                Application.LoadLevel("level1");
            }
            GUI.Label(new Rect(Screen.width / 2 - 140, Screen.height/2-70, 320, 250), "PAUSE");

            if (GUI.Button(new Rect(Screen.width / 2 - 125, Screen.height - 140, 250, 50), "Go to the Main Menu")) {
                Application.LoadLevel(0);
                DestroyObject(GameObject.FindGameObjectWithTag("floormanager"));
            }
            if(GUI.Button(new Rect(Screen.width / 2 - 125, Screen.height - 80, 250, 50), "Exit to desktop")){
                Application.Quit();

            }
        }
    }
}
