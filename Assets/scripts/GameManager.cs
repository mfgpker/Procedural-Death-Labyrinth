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
        bool bossroom = false;


        for (int i = 0; i < numberOfRoomX; i++) {
            for (int j = 0; j < numberOfRoomY; j++) {
                Vector3 spawnPosition = transform.position;
                spawnPosition.x += i * (spawnAreaWidth / numberOfRoomX);
                spawnPosition.y += j * (spawnAreaHeight / numberOfRoomY);
                spawnPosition.z += 0;
                int ran = Random.Range(0, 10);
               // Debug.Log(ran);
                if (ran < 5) {
                    if (!starter) {
                        GameObject newstarterroomObject = Instantiate(starterRoom, spawnPosition, transform.rotation) as GameObject;
                        newstarterroomObject.transform.parent = transform;
                        starter = true;
                        newstarterroomObject.transform.name = "Room:" + id;
                        newstarterroomObject.SendMessage("SetRoom", true);
                    }else{
                        GameObject RoomObject = Instantiate(Rooms[0], spawnPosition, transform.rotation) as GameObject;
                        RoomObject.transform.parent = transform;
                        RoomObject.transform.name = "Room:" + id;
                    }
                }
                else if (ran >= 6 && ran < 9) {
                    if (!bossroom) {
                        GameObject RoomObject = Instantiate(Rooms[1], spawnPosition, transform.rotation) as GameObject;
                        RoomObject.transform.parent = transform;
                        RoomObject.transform.name = "Room:" + id;
                        bossroom = true;
                        RoomObject.SendMessage("setBossroom", true);
                    }
                    else {
                        GameObject RoomObject = Instantiate(Rooms[0], spawnPosition, transform.rotation) as GameObject;
                        RoomObject.transform.parent = transform;
                        RoomObject.transform.name = "Room:" + id;
                    }
                } else {
                    GameObject RoomObject = Instantiate(Rooms[2], spawnPosition, transform.rotation) as GameObject;
                    RoomObject.transform.parent = transform;
                    RoomObject.transform.name = "Room:" + id;
                }
               
                GameObject r = GameObject.Find("Room:" + id);
                r.SendMessage("SetID", id);
                allRooms[id] = r; 
                id++;
            }
        }
        roomdoor();
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    public int MoveRoom2(int id, string dir) {
        int toid = -1;
        if (dir == "north") { // +1

            if (id != 2 || id != 5 || id != 8 || id != 11) {
                toid = id + 1;
            }
        }
        else if (dir == "east") { //+3
            if (id != 9 || id != 10 || id != 11) {
                toid = id + 3;
            }
        }
        else if (dir == "south") { // -1
            if (id != 0 || id != 3 || id != 6 || id != 9) {
                toid = id - 1;
            }
        }
        else if (dir == "west") { //-3
            if (id != 0 || id != 1 || id != 2) {
                toid = id - 3;
            }
        }
        return toid;
    }

    public int MoveRoom(int id, string dir) {
        int toid = -1;
        if (dir == "north") { // +1
            if (id == 0) {
                toid = 1;
            }
            else if(id == 1) {
                toid = 2;
            }
            else if (id == 3) {
                toid = 4;
            }
            else if (id == 4) {
                toid = 5;
            }
            else if (id == 6) {
                toid = 7;
            }
            else if (id == 7) {
                toid = 8;
            }
            else if (id == 9) {
                toid = 10;
            }
            else if (id == 10) {
                toid = 11;
            }
            else {
                toid = -1;
            }
        }
        else if (dir == "east") { //+3
            if (id == 0) {
                toid = 3;
            }
            else if (id == 1) {
                toid = 4;
            }
            else if (id == 2) {
                toid = 5;
            }
            else if (id == 3) {
                toid = 6;
            }
            else if (id == 4) {
                toid = 7;
            }
            else if (id == 5) {
                toid = 8;
            }
            else if (id == 6) {
                toid = 9;
            }
            else if (id == 7) {
                toid = 10;
            }
            else if (id == 8) {
                toid = 11;
            }
            else {
                toid = -1;
            }
        }
        else if (dir == "south") { // -1
            if (id == 2) {
                toid = 1;
            }
            else if (id == 1) {
                toid = 0;
            }
            else if (id == 5) {
                toid = 4;
            }
            else if (id == 4) {
                toid = 3;
            }
            else if (id == 8) {
                toid = 7;
            }
            else if (id == 7) {
                toid = 6;
            }
            else if (id == 11) {
                toid = 10;
            }
            else if (id == 10) {
                toid = 9;
            }
            else {
                toid = -1;
            }
        }
        else if (dir == "west") { //-3
            if (id == 3) {
                toid = 0;
            }
            else if (id == 4) {
                toid = 1;
            }
            else if (id == 5) {
                toid = 2;
            }
            else if (id == 6) {
                toid = 3;
            }
            else if (id == 7) {
                toid = 4;
            }
            else if (id == 8) {
                toid = 5;
            }
            else if (id == 9) {
                toid = 6;
            }
            else if (id == 10) {
                toid = 7;
            }
            else if (id == 11) {
                toid = 8;
            }
            else {
                toid = -1;
            }
        }
        return toid;
    }

    public void changeRoom(string dir){
        int fromid = whatroom();
        int toid = MoveRoom(fromid, dir);
        if (toid == -1) {
            Debug.Log("Cant move that way!");
            return;
        }
        GameObject p = GameObject.FindGameObjectWithTag("Player");       
        GameObject fromm = GameObject.Find("Room:"+fromid);
        Room rfrom = (Room)fromm.GetComponent(typeof(Room)); 
        GameObject to = GameObject.Find("Room:"+toid); 
        Room rto = (Room)to.GetComponent(typeof(Room));

        if (rto.notroom == true) {
            Debug.Log("Cant move that way!");
            return;
        }
        rfrom.SetRoom(false);
        rfrom.disablecam();
        rto.teleport(dir, p);
    }

    public void roomdoor() {
		for(GameObject rg in allRooms){
			Room ro = (Room)rg.GetComponent<Room>();
			int id = ro.getID();
			int n,s,w,e;
			n = MoveRoom(id, "north");
			s = MoveRoom(id, "south");
			w = MoveRoom(id, "west");
			e = MoveRoom(id, "east");
			
			if(n == -1){
				ro.setDoorTexture("doorN", "none")
			}
			if(s == -1){
				ro.setDoorTexture("doorS", "none")
			}
			if(w == -1){
				ro.setDoorTexture("doorW", "none")
			}
			if(e == -1){
				ro.setDoorTexture("doorE", "none")
			}
		}
    }

    public int whatroom(){
        for (int i = 0; i < allRooms.Length; i++) {
            GameObject p = GameObject.Find("Room:"+i);
            
            Room r = (Room)p.GetComponent(typeof(Room));
            if (r.currentRoom) {

                return r.getID();
            }

        }
            return -1;
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
