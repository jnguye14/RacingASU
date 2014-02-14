/*
 Script for Character Selection GUI Screen. Made by Adam and Jordan.
 */
#pragma strict

// button textures
var charPic1 : Texture;
var charPic2 : Texture;
var charPic3 : Texture;
var charPic4 : Texture;
var charPic5 : Texture;
var charPic6 : Texture;
var shoesPic : Texture;
var rollerbladePic : Texture;
var skateboardPic : Texture;
var scooterPic : Texture;
var bikePic : Texture;

// dimensions
private var buttonWidth = Screen.width*0.3; // charSelect
private var buttonHeight = Screen.height*0.3; // charSelect
private var buttonWidth2 = Screen.width*0.1; // transSelect
private var buttonHeight2 = Screen.height*0.125; // transSelect
private var vBuffer = Screen.height*0.035;
private var row1 = 2*vBuffer+Screen.height*0.10; // vPos for charSelect buttons 1-3
private var row2 = row1+buttonHeight+vBuffer; // vPos for charSelect buttons 4-6
private var row3 = row2+buttonHeight+vBuffer; // vPos for transSelect

function Start ()
{ }

function Update ()
{
    // in case user changes size of screen?
    buttonWidth = Screen.width*0.3;
    buttonHeight = Screen.height*0.3;
    buttonWidth2 = Screen.width*0.1;
    buttonHeight2 = Screen.height*0.125;
    vBuffer = Screen.height*0.035;
    row1 = 2*vBuffer+Screen.height*0.10;
    row2 = row1+buttonHeight+vBuffer;
    row3 = row2+buttonHeight+vBuffer;
}


function OnGUI()
{
	// back button
	if (GUI.Button(Rect(Screen.width*0.03,vBuffer,buttonWidth/2,Screen.height*0.10), "Back"))
	{
		Debug.Log("Going Back");
		gameObject.GetComponent(Title).enabled = true;
		gameObject.GetComponent(CharacterSelect).enabled = false;
	}
    
    
    // Title label
    GUI.Label(Rect(Screen.width*0.2, vBuffer, Screen.width*0.5, Screen.height*0.05), "Character Selection Screen");
    // directions label
    if(gameObject.GetComponent(MainController).charNum == 0)
    {
        GUI.Label(Rect(Screen.width*0.2, vBuffer+Screen.height*0.05, Screen.width*0.5, Screen.height*0.05), "Choose a Character");
    }
    else if(gameObject.GetComponent(MainController).transNum == 0)
    {
        GUI.Label(Rect(Screen.width*0.2, vBuffer+Screen.height*0.05, Screen.width*0.5, Screen.height*0.05), "Choose a Method of Transport");
    }
    else
    {
        GUI.Label (Rect(Screen.width*0.2, vBuffer+Screen.height*0.05, Screen.width*0.5, Screen.height*0.05), "Press Continue when you're Ready");
    }

    
	// character select buttons
	if (GUI.Button(Rect(Screen.width*0.03,row1,buttonWidth,buttonHeight), charPic1))
	{
		Debug.Log("Character 1 chosen");
		gameObject.GetComponent(MainController).setCharNum(1);
	}
	if (GUI.Button(Rect(Screen.width*0.35,row1,buttonWidth,buttonHeight), charPic2))
	{
		Debug.Log("Character 2 chosen");
		gameObject.GetComponent(MainController).setCharNum(2);
	}
	if (GUI.Button(Rect(Screen.width*0.67,row1,buttonWidth,buttonHeight), charPic3))
	{
		Debug.Log("Character 3 chosen");
		gameObject.GetComponent(MainController).setCharNum(3);
	}
	if (GUI.Button(Rect(Screen.width*0.03,row2,buttonWidth,buttonHeight), charPic4))
	{
		Debug.Log("Character 4 chosen");
		gameObject.GetComponent(MainController).setCharNum(4);
	}
	if (GUI.Button(Rect(Screen.width*0.35,row2,buttonWidth,buttonHeight), charPic5))
	{
		Debug.Log("Character 5 chosen");
		gameObject.GetComponent(MainController).setCharNum(5);
	}
	if (GUI.Button(Rect(Screen.width*0.67,row2,buttonWidth,buttonHeight), charPic6))
	{
		Debug.Log("Character 6 chosen");
		gameObject.GetComponent(MainController).setCharNum(6);
	}
	
    
    // after selecting character: mode of transport select buttons appear
	if(gameObject.GetComponent(MainController).charNum > 0)
	{
		if (GUI.Button(Rect(Screen.width*0.03,row3,buttonWidth2,buttonHeight2), shoesPic))
		{
			Debug.Log("Trans 1 chosen: shoes");
			gameObject.GetComponent(MainController).setTransNum(1);
		}
		if (GUI.Button(Rect(Screen.width*0.16,row3,buttonWidth2,buttonHeight2), rollerbladePic))
		{
			Debug.Log("Trans 2 chosen: rollerblades");
			gameObject.GetComponent(MainController).setTransNum(2);
		}
		if (GUI.Button(Rect(Screen.width*0.29,row3,buttonWidth2,buttonHeight2), skateboardPic))
		{
			Debug.Log("Trans 3 chosen: skateboard");
			gameObject.GetComponent(MainController).setTransNum(3);
		}
		if (GUI.Button(Rect(Screen.width*0.42,row3,buttonWidth2,buttonHeight2), scooterPic))
		{
			Debug.Log("Trans 4 chosen: scooter");
			gameObject.GetComponent(MainController).setTransNum(4);
		}
		if (GUI.Button(Rect(Screen.width*0.55,row3,buttonWidth2,buttonHeight2), bikePic))
		{
			Debug.Log("Trans 5 chosen: bike");
			gameObject.GetComponent(MainController).setTransNum(5);
		}
	}
	
    
	// after both character and transport are selected, continue button becomes active
	if(gameObject.GetComponent(MainController).charNum > 0 && gameObject.GetComponent(MainController).transNum > 0)
	{
		if (GUI.Button(Rect(Screen.width*0.68,row3,Screen.width*0.29,buttonHeight2), "Continue"))
		{
			Debug.Log(
					"Char selected = " + gameObject.GetComponent(MainController).charNum +
					"; Trans selected = " + gameObject.GetComponent(MainController).transNum
					);
			gameObject.GetComponent(mapSelect).enabled = true;
			gameObject.GetComponent(CharacterSelect).enabled = false;
		}
	}
	
}