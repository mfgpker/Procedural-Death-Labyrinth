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
                else if (ran >= 6 && ran < 8) {
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
    
    bool playerdead = false; public GUISkin deadskin;

    public void playerdie() {
        audio.PlayOneShot(audio.clip);
        FloorManager.init.reset();
        playerdead = true;
    }


    void OnGUI() {
        if (playerdead) {
            Debug.Log("you died");
            GUI.skin = deadskin;
            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 250, 550, 500), "Game Over");

        }
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

    public void teleport(string dir){
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


        if (dir == "north" && rfrom.dn.islocked) {
            Debug.Log("Door is lock!");
            return;
        }
        else if (dir == "south" && rfrom.ds.islocked) {
            Debug.Log("Door is lock!");
            return;
        }
        else if (dir == "west" && rfrom.dw.islocked) {
            Debug.Log("Door is lock!");
            return;
        }
        else if (dir == "east" && rfrom.de.islocked) {
            Debug.Log("Door is lock!");
            return;
        }

        Player pl = p.GetComponent<Player>();
        //
        if (dir == "north" && rfrom.dn.needkey) {
            if (pl.getKey() <= 0)
                return;
            else {
                pl.useKey();
                rfrom.dn.needkey = false;
                rfrom.setDoorTexture("doorN", "open");
            }
        }
        else if (dir == "south" && rfrom.ds.needkey) {
            if (pl.getKey() <= 0)
                return;
            else {
                pl.useKey();
                rfrom.ds.needkey = false;
                rfrom.setDoorTexture("doorS", "open");
            }
        }
        else if (dir == "west" && rfrom.dw.needkey) {
            if (pl.getKey() <= 0)
                return;
            else {
                pl.useKey();
                rfrom.dw.needkey = false;
                rfrom.setDoorTexture("doorW", "open");
            }
        }
        else if (dir == "east" && rfrom.de.needkey) {
            if (pl.getKey() <= 0)
                return;
            else {
                pl.useKey();
                rfrom.de.needkey = false;
                rfrom.setDoorTexture("doorE","open");
            }
        }

        if (dir == "north" && rfrom.dn.bosskey) {
            if (pl.getbossKey() <= 0)
                return;
            else pl.usebossKey();
        }
        else if (dir == "south" && rfrom.ds.bosskey) {
            if (pl.getbossKey() <= 0)
                return;
            else pl.usebossKey();
        }
        else if (dir == "west" && rfrom.dw.bosskey) {
            if (pl.getbossKey() <= 0)
                return;
            else pl.usebossKey();
        }
        else if (dir == "east" && rfrom.de.bosskey) {
            if (pl.getbossKey() <= 0)
                return;
            else pl.usebossKey();
        } 

        rfrom.SetRoom(false);
        rfrom.disablecam();
        rto.teleport(dir, p);
    }


    public string[] getRoomsAroundyou() {
        string[] rms = new string[4];
        int fromid = whatroom();
        int toidN = MoveRoom(fromid, "north");
        int toidS = MoveRoom(fromid, "south");
        int toidW = MoveRoom(fromid, "west");
        int toidE = MoveRoom(fromid, "east");

        if (toidN == -1) {
            rms[0] = "none";
        }
        else {
            GameObject toN = GameObject.Find("Room:" + toidN);
            Room rtoN = (Room)toN.GetComponent(typeof(Room));
            if (rtoN.notroom) {
                rms[0] = "none";
            }
            else if (rtoN.getBossRoom()) {
                rms[0] = "none";
            } else
            rms[0] = "doorN";

        }
        if (toidS == -1) {
            rms[1] = "none";
        }
        else {
            GameObject toS = GameObject.Find("Room:" + toidS);
            Room rtoS = (Room)toS.GetComponent(typeof(Room));
            if (rtoS.notroom) {
                rms[1] = "none";
            }
            else if (rtoS.getBossRoom()) {
                rms[1] = "none";
            }
            else
                rms[1] = "doorS";

        }
        if (toidW == -1) {
            rms[2] = "none";
        }
        else {
            GameObject toW = GameObject.Find("Room:" + toidW);
            Room rtoW = (Room)toW.GetComponent(typeof(Room));
            if (rtoW.notroom) {
                rms[2] = "none";
            }
            else if (rtoW.getBossRoom()) {
                rms[2] = "none";
            }
            else
                rms[2] = "doorW";
  
        }
        if (toidE == -1) {
            rms[3] = "none";

        }
        else {
            GameObject toE = GameObject.Find("Room:" + toidE);
            Room rtoE = (Room)toE.GetComponent(typeof(Room));
            if (rtoE.notroom) {
                rms[3] = "none";
            }
            else if (rtoE.getBossRoom()) {
                rms[3] = "none";
            }
            else
                rms[3] = "doorE";
           
        }
        

        return rms;
    }

    public Room getRoomByID(int id) {
        for (int i = 0; i < allRooms.Length; i++) {
            GameObject p = GameObject.Find("Room:" + i);

            Room r = (Room)p.GetComponent(typeof(Room));
            if (r.getID() == id) {

                return r;
            }

        }

        return null;

    }

    public Room getRoomByCurrently() {
        foreach (GameObject rg in allRooms) {
            Room r = (Room)rg.GetComponent(typeof(Room));
            if (r.currentRoom) {
                return r;
            }

        }

        return null;

    }

    public Room getRoomByBoss() {
        foreach (GameObject rg in allRooms) {
            Room r = (Room)rg.GetComponent(typeof(Room));
            if (r.getBossRoom()) {
                return r;
            }

        }

        return null;

    }

    public void roomdoor() {

        foreach (GameObject rg in allRooms) {
            Room ro = (Room)rg.GetComponent<Room>();
            int keyfactor = Random.Range(0, 10);
            bool fa = true;
            if (!ro.notroom) {
                int id = ro.getID();
                int n, s, w, e;
                n = MoveRoom(id, "north");
                s = MoveRoom(id, "south");
                w = MoveRoom(id, "west");
                e = MoveRoom(id, "east");

                Room rn = getRoomByID(n);
                Room rs = getRoomByID(s);
                Room rw = getRoomByID(w);
                Room re = getRoomByID(e);

                if (n == -1 || rn.notroom) {
                    ro.setDoorTexture("doorN", "none");
                }
                else if (rn.getBossRoom()) {
                    ro.setDoorTexture("doorN", "boss");
                }
                else {
                    if (keyfactor <= 3 && fa) {
                       ro.setDoorTexture("doorN", "keyneed");
                       fa = false;
                   } else {
                    if (ro.numbermobs <= 0) 
                        ro.setDoorTexture("doorN", "open");
                    else 
                        ro.setDoorTexture("doorN", "lock");
                    }
                }

                if (s == -1 || rs.notroom) {
                    ro.setDoorTexture("doorS", "none");
                }
                else if (rs.getBossRoom()) {
                    ro.setDoorTexture("doorS", "boss");
                }
                else {
                    if (keyfactor <= 3 && fa) {
                        ro.setDoorTexture("doorS", "keyneed");
                        fa = false;
                    }
                    else {
                        if (ro.numbermobs <= 0)
                            ro.setDoorTexture("doorS", "open");
                        else
                            ro.setDoorTexture("doorS", "lock");
                    }
                }

                if (w == -1 || rw.notroom) {
                    ro.setDoorTexture("doorW", "none");
                }
                else if (rw.getBossRoom()) {
                    ro.setDoorTexture("doorW", "boss");
                }
                else {
                    if (keyfactor <= 3 && fa) {
                        ro.setDoorTexture("doorW", "keyneed");
                        fa = false;
                    }
                    else {
                        if (ro.numbermobs <= 0)
                            ro.setDoorTexture("doorW", "open");
                        else
                            ro.setDoorTexture("doorW", "lock");
                    }
                }

                if (e == -1 || re.notroom) {
                    ro.setDoorTexture("doorE", "none");
                }
                else if (re.getBossRoom()) {
                    ro.setDoorTexture("doorE", "boss");
                }
                else {
                    if (keyfactor <= 3 && fa) {
                        ro.setDoorTexture("doorE", "keyneed");
                        fa = false;
                    }
                    else {
                        if (ro.numbermobs <= 0)
                            ro.setDoorTexture("doorE", "open");
                        else
                            ro.setDoorTexture("doorE", "lock");
                    }
                }
                if (ro.starterroom) {
                    ro.unlockdoor();
                }
                if (ro.getBossRoom()) ro.unlockdoor(); // kom i øjeblikket
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
