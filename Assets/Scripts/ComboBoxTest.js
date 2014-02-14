/*
coded by Jordan Nguyen (Jordan.N.Nguyen@asu.edu)
WARNING: make sure to have at least five buildings in the script
*/

#pragma strict

var buildings = new ArrayList();

private var startCode : String = "Click Here to Type Code";
private var startNum : int = 0;
private var startDropText : String = "Drop Down Menu";
private var startDropOn : boolean = false;
private var startScrollPosition : Vector2 = Vector2.zero;

function Start ()
{
	// TODO: add buildings from text file
	buildings.Add("building 1");
	buildings.Add("building 2");
	buildings.Add("building 3");
	buildings.Add("building 4");
	buildings.Add("building 5");
	buildings.Add("building 6");
}

function Update ()
{
	// code from Unity references Input.inputString
	// http://docs.unity3d.com/Documentation/ScriptReference/Input-inputString.html
	// useful if this script is attached to guiText object
	/*
	for (var c : char in Input.inputString)
	{
		// Backspace - Remove the last character
		if (c == "\b"[0])
		{
			if (guiText.text.Length != 0)
				guiText.text = guiText.text.Substring(0, guiText.text.Length - 1);
		}
		// End of entry
		else if (c == "\n"[0] || c == "\r"[0])
		{ // "\n" for Mac, "\r" for windows.
			print ("User entered his name: " + guiText.text);
		}
		// Normal text input - just append to the end
		else
		{
			guiText.text += c;
		}
	}
	*/
}

function OnGUI ()
{
	GUI.Label(Rect(10,10,200,20), "Enter a building code: ");
	startCode = GUI.TextField(Rect (210, 10, 200, 20), startCode, 25);
	
	// TODO: figure out how controller knows user had entered a code
	// TODO: check if code valid (i.e. corresponds w/ code for a building)
	
	GUI.Label(Rect(10,40,200,20), "Else, choose from dropdown:");
	if(GUI.Button(Rect(210,40,200,20), startDropText))
	{
		if(startDropOn) startDropOn = false;
		else startDropOn = true;
	}
	
	if(startDropOn)
	{
		GUI.Box(Rect(210,60,200,100), "");		
	    startScrollPosition = GUI.BeginScrollView(
	    		Rect(210,60,200,100), // same as GUI.Box (i.e. viewable area on screen)
	    		startScrollPosition, // zero
	    		Rect(0,0,184,buildings.Count*20), // size of content area
	    		false, // do not horizontal scrollbar unless necessary
	    		true // always show vertical scrollbar
	    );
    	
    	for(var i:int=0; i<buildings.Count; i++)
		{
			var temp : String = buildings[i];
			if(GUI.Button(Rect(0,i*20,184,20), temp))
			{
				startNum = i+1;
				startDropText = buildings[i];
				startDropOn = false;
				Debug.Log("Choose building number: " + startNum);
			}
		}
    	
	    GUI.EndScrollView();
	}
	
	// TODO: copy & paste code to add second drop down for end point
}