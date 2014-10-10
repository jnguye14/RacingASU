#pragma strict

// make sure this is the same as CircleEmitter.cs's Torus prefab's Primitives.cs's segmentRadius
public var radius : float = 1f;
private var player : GameObject;
public var finished : boolean = false;
private var startDistance : float = 0.0f;

function Start ()
{
	player = GameObject.FindGameObjectWithTag("Player");
	startDistance = (player.transform.position - this.transform.position).magnitude;
}

function Update ()
{
	var distance = (player.transform.position - this.transform.position).magnitude;
	if(distance < radius)
	{
		this.SendMessage("StopClock");
		finished = true;
	}
}

function OnGUI()
{
	if(finished)
	{
		var medal = "\nGold!";
		/*
		if(time < goldTime)
		{
			medal += "Gold!";
		}
		else if(time < silverTime)
		{
			medal += "Silver!";
		}
		else
		{
			medal += "Bronze!";
		}
		//*/
		GUI.Box(new Rect(0,0,Screen.width,Screen.height), "You Win!\nFinished " + guiText.text+medal);	
		if(GUI.Button(new Rect(Screen.width*0.25f,Screen.height*0.25f,Screen.width*0.5f,Screen.height*0.5f),"Go To Main Menu"))
		{
			Application.LoadLevel("Title");
		}
	}
}