using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject player, starterRoom;
    public GameObject[] Rooms;
    public GameObject[] allRooms;
	// Use this for initialization
    private bool starter = false;
    static public GameManager init;
    public int numberOfRoomX;
    public int numberOfRoomY;

    public float spawnAreaWidth;
    public float spawnAreaHeight;


    //private GameObject player;

	void Start () {
        init = this;
        int id = 0;
        allRooms = new GameObject[numberOfRoomX * numberOfRoomY];

        for (int i = 0; i < numberOfRoomX; i++) {
            for (int j = 0; j < numberOfRoomY; j++) {
                Vector3 spawnPosition = transform.position;
                spawnPosition.x += i * (spawnAreaWidth / numberOfRoomX);
                spawnPosition.y += j * (spawnAreaHeight / numberOfRoomY);
                spawnPosition.z += 0;

                if (!starter) {
                    GameObject newstarterroomObject = Instantiate(starterRoom, spawnPosition, transform.rotation) as GameObject;
                    newstarterroomObject.transform.parent = transform;
                    starter = true;
                    newstarterroomObject.transform.name = "Room:" + id;
                }
                else {
                    GameObject RoomObject = Instantiate(Rooms[0], spawnPosition, transform.rotation) as GameObject;
                    RoomObject.transform.parent = transform;
                    RoomObject.transform.name = "Room:" + id;
                    
                }
                GameObject r = GameObject.Find("Room:" + id);
                r.SendMessage("SetID", id);
                allRooms[id] = r; 
                id++;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void changeRoom(int toid, int fromid, string from){
        //GameObject 
    }

    void OnDrawGizmos() {

        for (int i = 0; i < numberOfRoomX; i++) {
            for (int j = 0; j < numberOfRoomY; j++) {

                Vector3 spawnPosition = transform.position;
                spawnPosition.x += i * (spawnAreaWidth / numberOfRoomX);
                spawnPosition.y += j * (spawnAreaHeight / numberOfRoomY);
                Gizmos.DrawLine(spawnPosition + Vector3.left, spawnPosition + Vector3.right);
                Gizmos.DrawLine(spawnPosition + Vector3.up, spawnPosition + Vector3.down);
                Gizmos.DrawLine(spawnPosition + Vector3.forward, spawnPosition + Vector3.back);

              
            }
        }

    }
}
