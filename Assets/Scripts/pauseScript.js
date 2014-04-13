/*
 Script to Pause Game. Made by Adam and Jordan.
 */
#pragma strict

var pauseBox : Rect = Rect(40,30,20,30);
var buffer : int = 5;
var isPaused : boolean = false;
private var numButtons : int = 5;
//private var boxW : int = 100;
//private var boxH : int = 30;

function Start()
{ }

function Update ()
{
    if(Input.GetKeyDown("p"))
    {
        TogglePause();
    }
}

function TogglePause()
{
    if(isPaused)
    {
        isPaused = false;
        Time.timeScale = 1.0;
    }
    else
    {
        isPaused = true;
        Time.timeScale = 0.0;
    }
}

function OnGUI()
{
    if(isPaused)
    {
        //GUI.Box(Rect((Screen.width-boxW)/2, (Screen.height-boxH)/2,boxW,boxH), "Paused");
        GUI.Box(adjRect(pauseBox), "Paused");

        var tempRect : Rect = adjRect(new Rect(pauseBox.x, pauseBox.y, pauseBox.width, pauseBox.height / numButtons));
        tempRect.x += buffer;
        tempRect.y += buffer;
        tempRect.width -= 2.0f * buffer;
        tempRect.height -= buffer * numButtons / (numButtons - 1.0f);
        var btnHeight : float = tempRect.height;

        tempRect.y += buffer + btnHeight;
        if (GUI.Button(tempRect, "Continue"))
        {
            TogglePause();
        }

        tempRect.y += buffer + btnHeight;
        if (GUI.Button(tempRect, "Restart"))
        {
            TogglePause();
            Application.LoadLevel(Application.loadedLevel);
        }

        tempRect.y += buffer + btnHeight;
        if (GUI.Button(tempRect, "Return to Title"))
        {
            TogglePause();
            Application.LoadLevel("Title");
        }

        /*
        tempRect.y += buffer + btnHeight;
        if (GUI.Button(tempRect, "Audio Settings"))
        {
            // -> mute/change music (play from personal music?), adjust volume
        }//*/

        tempRect.y += buffer + btnHeight;
        if (GUI.Button(tempRect, "Exit"))
        {
            Debug.Log("Exiting Application");
            Application.Quit();
        }
    }
}

// returns Rectangle adjusted to screen size
function adjRect(r : Rect)
{
    return new Rect(
            r.x * Screen.width / 100.0f,
            r.y * Screen.height / 100.0f,
            r.width * Screen.width / 100.0f,
            r.height * Screen.height / 100.0f);
}