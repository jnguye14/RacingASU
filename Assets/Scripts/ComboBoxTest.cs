/*
coded by Jordan Nguyen (Jordan.N.Nguyen@asu.edu)
currently needs at least five buildings in the script
*/

using UnityEngine;
using System.Collections;


public class ComboBoxTest : MonoBehaviour
{
	private string startCode = "Click Here to Type Code";
	private int startNum = 0;
	private string startDropText = "Drop Down Menu";
	private bool startDropOn = false;
	private Vector2 startScrollPosition = Vector2.zero;
	public Building[] buildings;

	// Use this for initialization
	void Start ()
	{
		// TODO: add buildings dynamically (perhaps from text file)
		buildings = new Building[]{
			new Building("building 1"),
			new Building("building 2"),
			new Building("Building 3"),
			new Building("building 4")//,
			//new Building("building 5"),
			//new Building("building 6")
		};
	}
	
	// Update is called once per frame
	void Update () {
		// code from Unity references Input.inputString
		// http://docs.unity3d.com/Documentation/ScriptReference/Input-inputString.html
		// useful if this script is attached to guiText object
		/*if(Input.GetKeyDown(KeyCode.Return) && GUI.GetNameOfFocusedControl () == "Code Input")
		{
			Debug.Log ("Entered Text");

			foreach (char c in Input.inputString)
			{
				// Backspace - Remove the last character
				if (c == '\b')
				{
					if(startCode.Length != 0)
					{
						startCode = startCode.Substring(0,startCode.Length-1);
					}
					//if (guiText.text.Length != 0)
					//	guiText.text = guiText.text.Substring(0, guiText.text.Length - 1);
				}
				// End of entry
				else if (c == '\n' || c == '\r')
				{ // "\n" for Mac, "\r" for windows.
					Debug.Log ("User entered: " + startCode/*guiText.text*//*);
				}
				// Normal text input - just append to the end
				else
				{
					startCode += c;
					//guiText.text += c;
				}
			}//*/
		/*}//*/
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

	void OnGUI()
	{
		GUI.Label(new Rect(10,10,200,20), "Enter a building code: ");
		GUI.SetNextControlName ("Code Input");
		startCode = GUI.TextField(new Rect (210, 10, 200, 20), startCode, 25);

		// TODO: figure out how controller knows user had entered a code
		// TODO: check if code valid (i.e. corresponds w/ code for a building)
		
		GUI.Label(new Rect(10,40,200,20), "Else, choose from dropdown:");
		if(GUI.Button(new Rect(210,40,200,20), startDropText))
		{
			if(startDropOn) startDropOn = false;
			else startDropOn = true;
		}
		
		if(startDropOn)
		{
			GUI.Box(new Rect(210,60,200,100), "");		
			startScrollPosition = GUI.BeginScrollView(
				new Rect(210,60,200,100), // same as GUI.Box (i.e. viewable area on screen)
				startScrollPosition, // zero
				new Rect(0,0,184,buildings.Length/*.Count*/*20), // size of content area
				false, // do not horizontal scrollbar unless necessary
				true // always show vertical scrollbar
				);
			
			for(int i = 0; i<buildings.Length/*.Count*/; i++)
			{
				string temp = buildings[i].Name/*.ToString()*/;
				if(GUI.Button(new Rect(0,i*20,184,20), temp))
				{
					startNum = i+1;
					startDropText = buildings[i].Name/*.ToString()*/;
					startDropOn = false;
					Debug.Log("Choose building number: " + startNum);
				}
			}
			
			GUI.EndScrollView();
		}
		
		// TODO: copy & paste code to add second drop down for end point
	}
}

[System.Serializable]
public class Building
{
	public GameObject model;
	public string Name;
	public string Code;
	public Vector3 position = Vector3.zero;
	public float radius = 0.0f;
	public enum Direction
	{
		North,
		South,
		East,
		West
	}
	public Direction SpawnDirection = Direction.North; // default
	private Vector3 SpawnLocation = Vector3.zero;
	
	public Building() { }

	public Building(string name)
	{
		this.Name = name;
	}

	void Start()
	{
		if (model)
		{
			position = model.transform.position;
			switch(SpawnDirection)
			{
			case Direction.East:
				SpawnLocation = position + radius * new Vector3(0,0,1);
				break;
			case Direction.North:
				SpawnLocation = position + radius * new Vector3(1,0,0);
				break;
			case Direction.South:
				SpawnLocation = position + radius * new Vector3(-1,0,0);
				break;
			case Direction.West:
				SpawnLocation = position + radius * new Vector3(0,0,-1);
				break;
			default:
				break;
			}
		}
	}
	
	void PlacePlayer(GameObject player)
	{
		player.transform.position = SpawnLocation;
	}
}