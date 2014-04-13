using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour
{
    public int buffer = 10;
    public float creditSpeed = 50.0f;
    public TextAsset credits;

    public Rect RestartButton = new Rect(0f, 60f, 50f, 20f);

    public GUISkin skin;
    public Font titleFont;
    private Font defaultFont;
    public Texture2D creditBanner;
    private string titleText = "CREDITS";

    private float amount; // credit offset amount
    private int repeatNum = 0;
    private string creditText = "";
    private int creditLength = 0;
    private float startTime = 0.0f;

    
    private int showThis = 0;
    /*
	0 default menu screen
	1 instructions
	2 credits
	3 high scores?
    */
    //var fileName = "/Scripts/credits.txt";
    public Rect menuBox = new Rect(5,5,30,50);
    private int numButtons = 6;

	void Start ()
    {
        if (skin != null)
        {
            defaultFont = skin.font;
        }
        creditText = credits.text;
        startTime = Time.time;

        /* // to grab credit text from text file using System.IO
        var sr = new StreamReader(Application.dataPath + fileName); // "..UnityGameProject/Assets" + fileName
        var fileContents = sr.ReadToEnd();
        sr.Close();
        creditText = fileContents;//*/
    }
	
	void Update ()
    {
        if (showThis != 2)
        {
            return;
        }

        amount = (Time.time - startTime) * creditSpeed - (float)((creditLength + Screen.height) * repeatNum);
		if(amount >= creditLength + Screen.height)
		{
			amount = 0;
			repeatNum++;
		}
    }

    void OnGUI()
    {
        GUI.skin = skin;

        switch(showThis)
        {
        case 0 : // Default Menu Screen
            DrawMenu();
            break;
        case 1 : // Instructions Screen
            DrawInstruct();
            break;
        case 2 : // Credits Screen
            DrawCredits();
            break;
        default :
            Debug.Log("Error Showing Menu Screen");
            break;
        }
    }

    void DrawMenu()
    {
        GUI.Box(adjRect(menuBox), "");

        Rect tempRect = adjRect(new Rect(menuBox.x, menuBox.y, menuBox.width, menuBox.height / (float)numButtons));
        tempRect.x += buffer;
        tempRect.y += buffer;
        tempRect.width -= 2.0f * buffer;
        tempRect.height -= buffer * (float)numButtons / ((float)numButtons - 1.0f);
        float btnHeight = tempRect.height;

        if (GUI.Button(tempRect, "Free Roam"))
        {
            Debug.Log("Clicked Free Roam, go to game");
            gameObject.GetComponent<MainController>().gameMode = 0;
            gameObject.GetComponent<CharacterSelect>().enabled = true;
            this.enabled = false;
        }

        tempRect.y += buffer + btnHeight;
        if (GUI.Button(tempRect, "Time Attack"))
        {
            Debug.Log("Clicked Time Attack button, go to game");
            //gameObject.GetComponent<MainController>().gameMode = 1;
            //gameObject.GetComponent<CharacterSelect>().enabled = true;
            //this.enabled = false;
        }

        tempRect.y += buffer + btnHeight;
        if (GUI.Button(tempRect, "Multiplayer"))
        {
            Debug.Log("Clicked Multiplayer button, go to game");
            //gameObject.GetComponent<MainController>().gameMode = 2;
            //gameObject.GetComponent<CharacterSelect>().enabled = true;
            //this.enabled = false;
        }

        /*
        if (GUI.Button(Rect(50,200,150,25),"High Scores?"))
        {
            Debug.Log("...High Scores?");
            showThis = 3;
        }
        */

        tempRect.y += buffer + btnHeight;
        if (GUI.Button(tempRect, "Instructions"))
        {
            //Debug.Log("clicked Instructions, show instructions");
            showThis = 1;
        }

        tempRect.y += buffer + btnHeight;
        if (GUI.Button(tempRect, "Credits"))
        {
            //Debug.Log("clicked credits, show credits");
            showThis = 2;
            startTime = Time.time;
        }

        tempRect.y += buffer + btnHeight;
        if (GUI.Button(tempRect, "Exit"))
        {
            Debug.Log("Exiting Application");
            Application.Quit();
        }
    }

    void DrawInstruct()
    {
        Rect tempRect = adjRect(new Rect(menuBox.x, menuBox.y, menuBox.width, menuBox.height / (float)numButtons));
        tempRect.x += buffer;
        tempRect.width -= 2.0f * buffer;
        tempRect.height -= buffer * (float)numButtons / ((float)numButtons - 1.0f);
        float btnHeight = tempRect.height;
        tempRect.y += buffer + ((float)numButtons - 1.0f) * (buffer + btnHeight);

        string text1 = "How to Play:\nUse WASD to move\nShift to run\nand P to pause\n\n...\n\nHave fun! :)";
        GUI.Box(adjRect(menuBox), text1);
        if (GUI.Button(tempRect, "Back"))
        {
            showThis = 0;
        }
    }

    void DrawCredits()
    {
        // Draw the "Credits" Label
        if (titleFont != null)
        {
            GUI.skin.font = titleFont;
        }
        GUI.contentColor = Color.black;
        if (creditBanner == null)
        {
            GUI.Box(new Rect(Screen.width * 0.2f, Screen.height * 0.1f, Screen.width * 0.6f, Screen.height * 0.1f), titleText);
        }
        else
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height * 0.2f), creditBanner);
            guiTexture.enabled = false;
        }
        GUI.skin.font = defaultFont;

        GUILayout.BeginArea(new Rect(0, Screen.height * 0.2f, Screen.width, Screen.height * 0.8f));

        // Draw the Scrolling Box
        GUI.skin.box.alignment = TextAnchor.MiddleCenter;
        //Vector2 sizeOfBox = GUI.skin.GetStyle("Box").CalcSize(new GUIContent(creditText));
        Vector2 sizeOfBox = GUI.skin.GetStyle("label").CalcSize(new GUIContent(creditText));
        creditLength = (int)(sizeOfBox.y + 2.0f * buffer);
        GUI.Box(new Rect((Screen.width - sizeOfBox.x) / 2.0f - buffer, Screen.height - amount, sizeOfBox.x + 2.0f * buffer, creditLength), creditText);

        GUILayout.EndArea();

        // Replay Button
        if (GUI.Button(adjRect(RestartButton), "Back"))//"Replay?"))
        {
            showThis = 0;
            guiTexture.enabled = true;
            //Application.LoadLevel("Title");
        }
    }

    // returns Rectangle adjusted to screen size
    Rect adjRect(Rect r)
    {
        return new Rect(
                r.x * Screen.width / 100.0f,
                r.y * Screen.height / 100.0f,
                r.width * Screen.width / 100.0f,
                r.height * Screen.height / 100.0f);
    }
}