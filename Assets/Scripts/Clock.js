#pragma strict

public var Timer = 0.0;
var isOn = true;
  
function Update ()
{
	if(isOn)
	{
		Timer += Time.deltaTime;
		guiText.text = timeFormat();
	}
}

function timeFormat()
{
	var minutes : int = Timer / 60;
	var seconds : int = Timer % 60;
	var milliseconds : int = (Timer % 1.0f) * 100.0f;

	var toReturn : String = "Time: ";
	if(minutes > 0)
	{
		toReturn += minutes.ToString() + ":";
		if(seconds < 10)
		{
			toReturn += "0";
		}
	}
	toReturn += seconds.ToString() + ":";
	if(milliseconds < 10)
	{
		toReturn += "0";
	}
	toReturn += milliseconds.ToString() + " Seconds";
	
	return toReturn;
}

function OnGUI()
{
	GUI.Label (Rect (10, 10, 100, 20), guiText.text);
}

function StopClock()
{
	isOn = false;
}