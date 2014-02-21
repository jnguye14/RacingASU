#pragma strict

import System.IO;

var showThis : int = 0;
/*
	0 default menu screen
	1 instructions
	2 credits
	3 high scores?
*/
var creditSpeed : int = 50;
private var amount : double;
private var repeatNum : int = 0;
public var creditsTextFile : TextAsset;
private var creditText : String = "";
private var creditLength : int = 2000;

function Start()
{
	// grab credit text from text file
	creditText = creditsTextFile.text;
}

function Update()
{
	if(showThis == 2)
	{
		amount = Time.time*creditSpeed - (creditLength+Screen.height)*repeatNum;
		if(amount >= creditLength+Screen.height)
		{
			amount = 0;
			repeatNum++;
		}
	}
}

function OnGUI()
{
	if(showThis == 0) // default menu screen
	{
		GUI.Box(new Rect(25,25,200,325), "  ");

		// TODO: replace text in buttons with textures 
		if (GUI.Button(Rect(50,50,150,25),"Free Roam"))
		{
			Debug.Log("Clicked Free Roam, go to game");
			gameObject.GetComponent(MainController).setGameMode(0);
			gameObject.GetComponent(CharacterSelect).enabled = true;
			gameObject.GetComponent(Title).enabled = false;
		}
		if (GUI.Button(Rect(50,100,150,25),"Time Attack"))
		{
			Debug.Log("Clicked Time Attack button, go to game");
			gameObject.GetComponent(MainController).setGameMode(1);
			gameObject.GetComponent(CharacterSelect).enabled = true;
			gameObject.GetComponent(Title).enabled = false;
		}
		if (GUI.Button(Rect(50,150,150,25),"Multiplayer"))
		{
			Debug.Log("Clicked Multiplayer button, go to game");
			gameObject.GetComponent(MainController).setGameMode(2);
			gameObject.GetComponent(CharacterSelect).enabled = true;
			gameObject.GetComponent(Title).enabled = false;
		}
		/*
		if (GUI.Button(Rect(50,200,150,25),"High Scores?"))
		{
			Debug.Log("...High Scores?");
			showThis = 3;
		}
		*/
		if (GUI.Button(Rect(50,200,150,25),"Instructions"))
		{
			//Debug.Log("clicked Instructions, show instructions");
			showThis = 1;
		}
		if (GUI.Button(Rect(50,250,150,25),"Credits"))
		{
			//Debug.Log("clicked credits, show credits");
			showThis = 2;
		}
		if (GUI.Button(Rect(50,300,150,25),"Exit"))
		{
			Debug.Log("Exiting Application");
			Application.Quit();
		}
	}
	else if(showThis == 1) // instructions screen
	{
		var text1 : String = "\n\nHow to Play:\n\nUse WASD to move\n\nShift to run\n\nSpace to jump\n\n...\n\nHave fun! :)";
		GUI.Box(new Rect(25,25,200,325), text1);
		if (GUI.Button(Rect(50,250,150,25),"Back"))
			showThis = 0;
	}
	else if(showThis == 2) // credits screen
	{
		GUI.Box(new Rect(Screen.width/2-150,Screen.height - amount,300, creditLength),creditText);
		if (GUI.Button(Rect(50,250,150,25),"Back"))
			showThis = 0;
	}
	else
		Debug.Log("error showing menu screen");
}