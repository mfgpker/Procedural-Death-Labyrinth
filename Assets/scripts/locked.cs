using UnityEngine;
using System.Collections;

public class locked : MonoBehaviour {
    
    public bool islocked = true;
    public bool needkey = false;
    public bool bosskey = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void setbosskey() {
        bosskey = false;
    }
}
