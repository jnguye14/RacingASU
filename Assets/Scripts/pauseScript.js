/*
 Script to Pause Game. Made by Adam and Jordan.
 */
#pragma strict

var isPaused : boolean = false;
private var boxW : int = 100;
private var boxH : int = 30;

function Start()
{ }

function Update ()
{
    if(Input.GetKeyDown("p"))
    {
        if(isPaused)
        {
            isPaused = false;
            Time.timeScale = 1.0;
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0.0;
        }
    }
}

function OnGUI()
{
    if(isPaused)
    {
        GUI.Box(Rect((Screen.width-boxW)/2, (Screen.height-boxH)/2,boxW,boxH), "Paused");
        /* TODO: make box bigger & add option buttons:
        	"continue"
        	"restart"
        	"return to title" (or character select/map select screen?)
        	"audio settings" -> mute/change music (play from personal music?), adjust volume
        	"exit" (probably don't need)
        */
    }
}