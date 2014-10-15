using UnityEngine;
using System.Collections;

public class MainController : MonoBehaviour
{
    public int gameMode
    {
        get;
        set;
    }
    /*
	    0 = FreeRoam, default
	    1 = Time Attack
	    2 = Multiplayer
    */
    public int charNum
    {
        get;
        set;
    }
    /*
	    0 = none selected
	    1 = normal girl
	    2 = slacker girl
	    3 = spirit girl
	    4 = normal guy
	    5 = slacker guy
	    6 = spirit guy
    */
    public int transNum
    {
        get;
        set;
    }
    /*
        0 = none selected
        1 = shoes
        2 = rollerblade
        3 = skateboard
        4 = scooter
        5 = bike
    */

    public string startLoc
    {
        get;
        set;
    }

    public string endLoc
    {
        get;
        set;
    }

    void Start()
    {
        gameMode = 0;
        charNum = 0;
        transNum = 1;
    }

    public void goToGame()
    {
        Debug.Log("Starting Game with: " + startLoc + " and ending with " + endLoc);
        PlayerPrefs.SetString("StartLoc", startLoc);
        PlayerPrefs.SetString("EndLoc", endLoc);
		Application.LoadLevel("Demo Terrain"); // JNN: temp
        /*
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
	    }//*/
    }
}
