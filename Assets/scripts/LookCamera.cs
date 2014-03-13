using UnityEngine;
using System.Collections;

public class LookCamera : MonoBehaviour {
    private bool isactive = false;

	// Use this for initialization
	void Start () {
        //transform.gameObject.SetActive(isactive);
        gameObject.GetComponentInChildren<Camera>().enabled = isactive;
	}
	
	// Update is called once per frame
    void Update() {
        
        if (Input.GetKeyDown(KeyCode.G)) {
            isactive = !isactive;
            gameObject.GetComponentInChildren<Camera>().enabled=isactive;
            //Debug.Log("pressed");
        }
	}
}
