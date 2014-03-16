using UnityEngine;
using System.Collections;

public class Boss : EnemyAI {

    public GameObject minminions;
    public GameObject[] minminionsSpawn;

    
    public Texture2D clockBG;
    public Texture2D clockFG;
    public  float clockFGMaxWidth; //the starting width of the foreground bar

    private bool round1 = false, round2 = false, round3 = false;

	// Use this for initialization
	void Start () {
        minminionsSpawn = GameObject.FindGameObjectsWithTag("spawnmin");
        clockFGMaxWidth = clockFG.width;
        
	}
	
	// Update is called once per frame
	void LateUpdate () {
        

        if (healthprocent < 75 && !round1) {
            round1 = true;
            for (int i = 0; i < minminionsSpawn.Length; i++) {
                Instantiate(minminions, minminionsSpawn[i].transform.position, transform.rotation);
            }
        }

        if (healthprocent < 50 && !round2) {
            round2 = true;
            for (int i = 0; i < minminionsSpawn.Length; i++) {
                Instantiate(minminions, minminionsSpawn[i].transform.position, transform.rotation);
            }
        }

        if (healthprocent < 25 && !round3) {
            round3 = true;
            for (int i = 0; i < minminionsSpawn.Length; i++) {
                Instantiate(minminions, minminionsSpawn[i].transform.position, transform.rotation);
            }
        }
	}


    Room rm;
    void OnGUI() {
        float newBarWidth = ((float)healthprocent / 100) * clockFGMaxWidth;
        int gap = 20;


        rm = GameManager.init.getRoomByCurrently();
        if (rm.currentRoom && rm.getBossRoom()) {
            GUI.BeginGroup(new Rect(Screen.width - 200 - clockBG.width - gap, gap, clockBG.width, clockBG.height));
            GUI.DrawTexture(new Rect(0, 0, clockBG.width, clockBG.height), clockBG);

            GUI.BeginGroup(new Rect(0, 0, newBarWidth, clockFG.height));
            GUI.DrawTexture(new Rect(0, 0, clockFG.width, clockFG.height), clockFG);
            GUI.EndGroup();
            GUI.EndGroup();
        }

        

    }
}

