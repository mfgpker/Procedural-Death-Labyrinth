﻿using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour {
    public GameObject player;

	// Use this for initialization
	void Start () {

        Instantiate(player, transform.position, transform.rotation);
        //////////newObject.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
