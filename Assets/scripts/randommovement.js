#pragma strict

var stuff : Transform; // Needs rigidbody attached with a collider

var vel : Vector3; // Holds the random velocity

var switchDirection : float = 3;

var curTime : float = 0;



function Start()

{

    SetVel();

}

 

function SetVel()

{

    if (Random.value > .5) {

        vel.x = 10 * Random.value;

    }

    else {

        vel.x = -10 * Random.value;

    }

    if (Random.value > .5) {

        vel.y = 10 * Random.value;

    }

    else {

        vel.y = -10 * Random.value;

    }

}

 

function Update()

{

    if (curTime < switchDirection) {

        curTime += 1 * Time.deltaTime;

    }

    else {

        SetVel();

        if (Random.value > .5) {

            switchDirection += Random.value;
        }
        else {

            switchDirection -= Random.value;

        }

        if (switchDirection < 1) {

            switchDirection = 1 + Random.value;

        }

        curTime = 0;

    }

}

 

function FixedUpdate()

{

    stuff.rigidbody.velocity = vel;

}
