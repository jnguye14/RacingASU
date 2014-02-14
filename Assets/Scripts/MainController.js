#pragma strict

var gameMode:int = 0;
/*
	0 = FreeRoam, default
	1 = Time Attack
	2 = Multiplayer
*/
var charNum : int = 0;
/*
	0 = none selected
	1 = normal girl
	2 = slacker girl
	3 = spirit girl
	4 = normal guy
	5 = slacker guy
	6 = spirit guy
*/
var transNum : int = 0;
/*
    0 = none selected
    1 = shoes
    2 = rollerblade
    3 = skateboard
    4 = scooter
    5 = bike
*/

function Start () { }

function Update () { }

function setGameMode(x:int)
{
	gameMode = x;
	Debug.Log("Game Mode set to "+gameMode);
}

function setCharNum(x:int)
{
	charNum = x;
	Debug.Log("Char Num set to "+charNum);
}

function setTransNum(x:int)
{
	transNum = x;
	Debug.Log("Trans Num set to "+transNum);
}

function goToGame()
{
	switch(gameMode)
	{
	case 0: 
		Debug.Log("Playing Free Roam");
		// create player with transport
		// spawn at start
		break;
	case 1:
		Debug.Log("Playing Time Attack");
		// create player with transport
		// enable destination arrow
		// spawn at start
		break;
	case 2:
		Debug.Log("Playing Multiplayer");
		// create player 1 with transport
		// create player 2 with transport
		// enable desination arrow
		// spawn player 1 and 2 next to each other at start
		break;
	default:
		Application.LoadLevel("FreeRoam");
		break;
	}
}
