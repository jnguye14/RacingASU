/*
 Script for Character Selection GUI Screen. Made by Adam and Jordan.
 */

using UnityEngine;
using System.Collections;

public class CharacterSelect : MonoBehaviour
{
    // button textures
    public Texture2D charPic1;
    public Texture2D charPic2;
    public Texture2D charPic3;
    public Texture2D charPic4;
    public Texture2D charPic5;
    public Texture2D charPic6;
    public Texture2D shoesPic;
    public Texture2D rollerbladePic;
    public Texture2D skateboardPic;
    public Texture2D scooterPic;
    public Texture2D bikePic;

    // dimensions
    private float buttonWidth; // charSelect
    private float buttonHeight; // charSelect
    private float buttonWidth2; // transSelect
    private float buttonHeight2; // transSelect
    private float vBuffer;
    private float row1; // vPos for charSelect buttons 1-3
    private float row2; // vPos for charSelect buttons 4-6
    private float row3; // vPos for transSelect

    private MainController mc;

    void Start()
    {
        buttonWidth = Screen.width * 0.3f;
        buttonHeight = Screen.height * 0.3f;
        buttonWidth2 = Screen.width * 0.1f;
        buttonHeight2 = Screen.height * 0.125f;
        vBuffer = Screen.height * 0.035f;
        row1 = 2.0f * vBuffer + Screen.height * 0.10f;
        row2 = row1 + buttonHeight + vBuffer;
        row3 = row2 + buttonHeight + vBuffer;

        mc = this.gameObject.GetComponent<MainController>();
    }

    void Update ()
    {
        // in case user changes size of screen?
        buttonWidth = Screen.width * 0.3f;
        buttonHeight = Screen.height * 0.3f;
        buttonWidth2 = Screen.width * 0.1f;
        buttonHeight2 = Screen.height * 0.125f;
        vBuffer = Screen.height * 0.035f;
        row1 = 2.0f * vBuffer + Screen.height * 0.10f;
        row2 = row1 + buttonHeight + vBuffer;
        row3 = row2 + buttonHeight + vBuffer;
    }

    void OnGUI()
    {
	    // back button
	    if (GUI.Button(new Rect(Screen.width*0.03f, vBuffer, buttonWidth/2.0f, Screen.height*0.10f), "Back"))
	    {
		    //Debug.Log("Going Back");
            gameObject.GetComponent<Title>().enabled = true;
            this.enabled = false;
	    }
    
    
        // Title label
        GUI.Box(new Rect(Screen.width*0.2f, vBuffer, Screen.width*0.5f, Screen.height*0.05f), "Character Selection Screen");
        // directions label
        if(mc.charNum == 0)
        {
            GUI.Box(new Rect(Screen.width*0.2f, vBuffer+Screen.height*0.05f, Screen.width*0.5f, Screen.height*0.05f), "Choose a Character");
        }
        else if(mc.transNum == 0)
        {
            GUI.Box(new Rect(Screen.width * 0.2f, vBuffer + Screen.height * 0.05f, Screen.width * 0.5f, Screen.height * 0.05f), "Choose a Method of Transport");
        }
        else
        {
            GUI.Box(new Rect(Screen.width * 0.2f, vBuffer + Screen.height * 0.05f, Screen.width * 0.5f, Screen.height * 0.05f), "Press Continue when you're Ready");
        }

    
	    // character select buttons
	    if (GUI.Button(new Rect(Screen.width*0.03f,row1,buttonWidth,buttonHeight), charPic1))
	    {
		    Debug.Log("Character 1 chosen");
            mc.charNum = 1;
	    }
	    if (GUI.Button(new Rect(Screen.width*0.35f,row1,buttonWidth,buttonHeight), charPic2))
	    {
		    Debug.Log("Character 2 chosen");
            mc.charNum = 2;
	    }
	    if (GUI.Button(new Rect(Screen.width*0.67f,row1,buttonWidth,buttonHeight), charPic3))
	    {
		    Debug.Log("Character 3 chosen");
            mc.charNum = 3;
	    }
	    if (GUI.Button(new Rect(Screen.width*0.03f,row2,buttonWidth,buttonHeight), charPic4))
	    {
		    Debug.Log("Character 4 chosen");
		    mc.charNum = 4;
	    }
	    if (GUI.Button(new Rect(Screen.width*0.35f,row2,buttonWidth,buttonHeight), charPic5))
	    {
		    Debug.Log("Character 5 chosen");
		    mc.charNum = 5;
	    }
	    if (GUI.Button(new Rect(Screen.width*0.67f,row2,buttonWidth,buttonHeight), charPic6))
	    {
		    Debug.Log("Character 6 chosen");
		    mc.charNum = 6;
	    }
	
    
        /*// after selecting character: mode of transport select buttons appear
	    if(mc.charNum > 0)
	    {
		    if (GUI.Button(new Rect(Screen.width*0.03f,row3,buttonWidth2,buttonHeight2), shoesPic))
		    {
			    Debug.Log("Trans 1 chosen: shoes");
			    mc.transNum = 1;
		    }
		    if (GUI.Button(new Rect(Screen.width*0.16f,row3,buttonWidth2,buttonHeight2), rollerbladePic))
		    {
			    Debug.Log("Trans 2 chosen: rollerblades");
			    mc.transNum = 2;
		    }
		    if (GUI.Button(new Rect(Screen.width*0.29f,row3,buttonWidth2,buttonHeight2), skateboardPic))
		    {
			    Debug.Log("Trans 3 chosen: skateboard");
			    mc.transNum = 3;
		    }
		    if (GUI.Button(new Rect(Screen.width*0.42f,row3,buttonWidth2,buttonHeight2), scooterPic))
		    {
			    Debug.Log("Trans 4 chosen: scooter");
			    mc.transNum = 4;
		    }
		    if (GUI.Button(new Rect(Screen.width*0.55f,row3,buttonWidth2,buttonHeight2), bikePic))
		    {
			    Debug.Log("Trans 5 chosen: bike");
			    mc.transNum = 5;
		    }
	    }//*/
	
    
	    // after both character and transport are selected, continue button becomes active
	    if(mc.charNum > 0 && mc.transNum > 0)
	    {
		    if (GUI.Button(new Rect(Screen.width*0.68f,row3,Screen.width*0.29f,buttonHeight2), "Continue"))
		    {
			    //Debug.Log(
				//	    "Char selected = " + mc.charNum +
				//	    "; Trans selected = " + mc.transNum
				//	    );
			    gameObject.GetComponent<mapSelect>().enabled = true;
			    this.enabled = false;
		    }
	    }
	
    }
}
