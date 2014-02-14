#pragma strict

var Timer = 0.0;
 
function Update ()
{
	Timer += Time.deltaTime;
 
	guiText.text = "" + Timer;
} 

function OnGUI()
{
	GUI.Label (Rect (10, 10, 100, 20), guiText.text);
	
}