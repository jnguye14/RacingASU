/*
 Script for Map Selection GUI Screen. Made by Adam and Jordan.
 */
#pragma strict

//import System.IO;

var mapTexture : Texture;
var fileName = "/buildings.txt";

// dimensions
private var hBuffer : float;
private var mapWidth : float;
private var dropWidth : float;
private var buttonWidth : float;
private var vBuffer : float;
private var mapHeight : float;
private var dropHeight : float;
private var buttonHeight : float;

// other variables for main controllerer
var startNum : int = 0;
var endNum : int = 0;


function Start ()
{
/*
    // grab building data from text file 
    var sr = new StreamReader(Application.dataPath + fileName);
    var fileContents = sr.ReadToEnd();
    sr.Close();
 
    var lines = fileContents.Split("\n"[0]);
    for (line in lines)
    {
        Debug.Log(line);
    }*/
}

function Update ()
{
	hBuffer = Screen.width*0.05;
	mapWidth = Screen.width*0.6;
	dropWidth = Screen.width*0.25;
	buttonWidth = Screen.width*0.2;
	
	vBuffer = Screen.height*0.05;
	mapHeight = Screen.height*0.75;
	dropHeight = (mapHeight-vBuffer)/2;
	buttonHeight = Screen.height*0.1;
}


function OnGUI()
{
    // back button
    if (GUI.Button(Rect(hBuffer,2*vBuffer+mapHeight,buttonWidth,buttonHeight), "Back"))
    {
        Debug.Log("Going Back");
		gameObject.GetComponent(CharacterSelect).enabled = true;
		gameObject.GetComponent(mapSelect).enabled = false;
	}
        
    // map
    GUI.Box(Rect(hBuffer,vBuffer,mapWidth,mapHeight), mapTexture);
    
    // start comboBox
    GUI.Box(Rect(2*hBuffer+mapWidth,vBuffer,dropWidth,dropHeight), "Choose a Start");
    // end comboBox
    GUI.Box(Rect(2*hBuffer+mapWidth,2*vBuffer+dropHeight,dropWidth,dropHeight), "Choose an End");

    // text label
    if(startNum == 0)
    {
        GUI.Label(Rect(Screen.width*0.3, 2*vBuffer+mapHeight, Screen.width*0.4, buttonHeight), "Please Choose a Starting Point");
    }
    else if(endNum == 0)
    {
        GUI.Label(Rect(Screen.width*0.3, 2*vBuffer+mapHeight, Screen.width*0.4, buttonHeight), "Please Choose an Ending Point");
    }
    else
    {
        GUI.Label (Rect(Screen.width*0.3, 2*vBuffer+mapHeight, Screen.width*0.4, buttonHeight), "Press Start when you're Ready");
    }
    

    // Start button
    if(startNum > 0 && endNum > 0)
    {
        if (GUI.Button(Rect(Screen.width-Screen.width*0.25,2*vBuffer+mapHeight,buttonWidth,buttonHeight), "Start"))
        {
            Debug.Log("Continue");//go to game
			gameObject.GetComponent(MainController).goToGame();
        }
    }
}