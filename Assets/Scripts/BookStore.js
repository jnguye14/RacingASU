/*
 Script for Bookstore Screen. Made by Jordan.
 */
#pragma strict

// button textures
var rollerbladePic : Texture;
var skateboardPic : Texture;
var scooterPic : Texture;
var bikePic : Texture;

var hasRollerblade : boolean = false;
var hasSkateboard : boolean = false;
var hasScooter : boolean = false;
var hasBike : boolean = false;

var currentMG : int = 0;

private var showMe : boolean = false;
private var selected : int = 0;
private var costText : String = "";
private var totalCost : int = 0;

// dimensions
private var buttonWidth = Screen.width*0.45; // charSelect
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
    // in case user changes size of screen
    buttonWidth = Screen.width*0.45;
    buttonHeight = Screen.height*0.3;
    buttonWidth2 = Screen.width*0.1;
    buttonHeight2 = Screen.height*0.125;
    vBuffer = Screen.height*0.035;
    row1 = 2*vBuffer+Screen.height*0.10;
    row2 = row1+buttonHeight+vBuffer;
    row3 = row2+buttonHeight+vBuffer;
    
    // change cost label accordingly
    switch(selected)
    {
    case 0 :
    	costText = "You have $" + currentMG + " (M&G)";
    	totalCost = 0;
    	break;
    case 1 :
    	costText = "Rollerblades cost $20.00 (M&G). You have $" + currentMG + " (M&G)";
    	totalCost = 20;
    	break;
    case 2 :
    	costText = "Skateboards cost $40.00 (M&G). You have $" + currentMG + " (M&G)";
    	totalCost = 40;
    	break;
    case 3 :
    	costText = "Scooters cost $80.00 (M&G). You have $" + currentMG + " (M&G)";
    	totalCost = 80;
    	break;
    case 4 :
    	costText = "Bikes cost $160.00 (M&G). You have $" + currentMG + " (M&G)";
    	totalCost = 160;
    	break;
    case 5 :
	    costText = "You already own this";
    	break;
 	case 6 :
	 	costText = "You do not have enough M&G to buy that. Cost: $" + totalCost
 			   	+ " (M&G), You have: $" + currentMG + " (M&G)";
 		break;
    default :
    	costText = "You have $" + currentMG + " (M&G)";
    	totalCost = 0;
    	break;
    }
}

function OnTrigger()
{
	showMe = true;
}

function OnGUI()
{
	// back button
	if (GUI.Button(Rect(Screen.width*0.03,vBuffer,buttonWidth/2,Screen.height*0.10), "Exit"))
	{
		Debug.Log("Exiting Store");
		showMe = false;
		return;
	}
    
    // Title label
    GUI.Label(Rect(Screen.width*0.5, vBuffer, Screen.width*0.5, Screen.height*0.05), "Welcome to the ASU bookstore");
    // directions label
    GUI.Label(Rect(Screen.width*0.5, vBuffer+Screen.height*0.05, Screen.width*0.5, Screen.height*0.05), costText);

 	// character select buttons
	if (GUI.Button(Rect(Screen.width*0.03,row1,buttonWidth,buttonHeight), rollerbladePic))
	{
		Debug.Log("Roller blade selected");
		if(hasRollerblade)
			selected = 5;
		else
			selected = 1;
	}
	if (GUI.Button(Rect(Screen.width*0.5,row1,buttonWidth,buttonHeight), skateboardPic))
	{
		Debug.Log("Skateboard selected");
		if(hasSkateboard)
			selected = 5;
		else
			selected = 2;
	}
	if (GUI.Button(Rect(Screen.width*0.03,row2,buttonWidth,buttonHeight), scooterPic))
	{
		Debug.Log("scooter selected");
		if(hasScooter)
			selected = 5;
		else
			selected = 3;
	}
	if (GUI.Button(Rect(Screen.width*0.5,row2,buttonWidth,buttonHeight), bikePic))
	{
		Debug.Log("bike selected");
		if(hasBike)
			selected = 5;
		else
			selected = 4;
	}
	
    
    // after selecting what you want to buy
	if(selected > 0)
	{
		if (GUI.Button(Rect(Screen.width*0.68,row3,Screen.width*0.29,buttonHeight2), "Buy"))
		{
			if(currentMG < totalCost)
			{
				selected = 6;	
			}
			else
			{
				currentMG = currentMG - totalCost;
				switch(selected)
				{
				case 1:
					hasRollerblade = true;
					break;
				case 2:
					hasSkateboard = true;
					break;
				case 3:
					hasScooter = true;
					break;
				case 4:
					hasBike = true;
					break;
				default:
					Debug.Log("error, invalid item was purchased");
					break;
				}
				
				Debug.Log("Item purchased");
				selected = 0;
				showMe = false;
			}
		}
	}	
}