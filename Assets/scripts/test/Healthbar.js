#pragma strict

var clockBG : Texture2D;
var clockFG : Texture2D;
var clockFGMaxWidth : float; //the starting width of the foreground bar
var currentHealth:float;
 
function Start()
{
   var startTime = 10.0;
    clockFGMaxWidth = clockFG.width;
    currentHealth = 100;
}
 
function Update () 
{
    if (Input.GetButtonDown("Fire1"))
        currentHealth -= 1;
}
 
function OnGUI()
{
    //this is the width that the foreground bar should be
    var newBarWidth:float = (currentHealth/100) * clockFGMaxWidth;
 
    Debug.Log("current health " + currentHealth);
 
    //a spacing variable to help us position the clock
    var gap:int = 20;
 
    GUI.BeginGroup(new Rect (Screen.width - clockBG.width - gap, 
       gap, clockBG.width, clockBG.height));
    GUI.DrawTexture(Rect (0,0, clockBG.width, clockBG.height), clockBG);
 
    GUI.BeginGroup(new Rect(5,6, newBarWidth, clockFG.height));
    GUI.DrawTexture(Rect(0,0, clockFG.width, clockFG.height), clockFG);
    GUI.EndGroup();
    GUI.EndGroup();
}