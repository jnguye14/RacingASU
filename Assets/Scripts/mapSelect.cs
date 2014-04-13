/*
 Script for Map Selection GUI Screen. Made by Adam and Jordan.
 */

using UnityEngine;
using System.Collections;

public class mapSelect : MonoBehaviour
{
    public Texture2D mapTexture;
    public string fileName = "/buildings.txt";

    // dimensions
    private float hBuffer;
    private float mapWidth;
    private float dropWidth;
    private float buttonWidth;
    private float vBuffer;
    private float mapHeight;
    private float dropHeight;
    private float buttonHeight;

    // Dropdown variables
    public GameObject startDropDown;
    public GameObject endDropDown;
    private ComboBoxTest startCB;
    private ComboBoxTest endCB;
    private Rect startDropDownRect;
    private Rect endDropDownRect;

    // other variables
    private bool startSelected = false;
    private bool endSelected = false;

	void Start ()
    {
        /*
        // grab building data from text file 
        var sr = new StreamReader(Application.dataPath + fileName);
        var fileContents = sr.ReadToEnd();
        sr.Close();
 
        var lines = fileContents.Split("\n"[0]);
        for (line in lines)
        {
            Debug.Log(line);
        }*/

        startCB = startDropDown.GetComponent<ComboBoxTest>();
        endCB = endDropDown.GetComponent<ComboBoxTest>();
	}
	
	void Update ()
    {
	    if(!startDropDown.activeSelf)
        {
            startDropDown.SetActive(true);
        }
        if(!endDropDown.activeSelf)
        {
            endDropDown.SetActive(true);
        }
        
        hBuffer = Screen.width * 0.05f;
	    mapWidth = Screen.width*0.5f;
	    dropWidth = Screen.width*0.35f;
	    buttonWidth = Screen.width*0.2f;
	
	    vBuffer = Screen.height*0.05f;
	    mapHeight = Screen.height*0.75f;
	    dropHeight = (mapHeight-vBuffer)/2.0f;
	    buttonHeight = Screen.height*0.1f;

        startDropDownRect = new Rect(2 * hBuffer + mapWidth, vBuffer, dropWidth, dropHeight);
        startDropDownRect.x += hBuffer/2.0f;
        startDropDownRect.y += vBuffer;
        startDropDownRect.width -= hBuffer;
        startDropDownRect.height -= 2.0f * vBuffer;
        startCB.boundingBox = startDropDownRect;
        startDropDownRect.x -= hBuffer/2.0f;
        startDropDownRect.y -= vBuffer;
        startDropDownRect.width += hBuffer;
        startDropDownRect.height += 2.0f * vBuffer;

        startSelected = startCB.hasBuilding;

        endDropDownRect = new Rect(2 * hBuffer + mapWidth, 2 * vBuffer + dropHeight, dropWidth, dropHeight);
        endDropDownRect.x += hBuffer/2.0f;
        endDropDownRect.y += vBuffer;
        endDropDownRect.width -= hBuffer; 
        endDropDownRect.height -= 2.0f * vBuffer;
        endCB.boundingBox = endDropDownRect;
        endDropDownRect.x -= hBuffer/2.0f;
        endDropDownRect.y -= vBuffer;
        endDropDownRect.width += hBuffer;
        endDropDownRect.height += 2.0f * vBuffer;

        endSelected = endCB.hasBuilding;

        /*
        var temp : ComboBoxTest = startDropDown.GetComponent("ComboBoxTest");
        var spawnLoc : Vector3 = temp.GetSelectedLocation();
        if(spawnLoc != Vector3.zero)
        {
            startSelected = true;
            PlayerPrefs.SetFloat("SpawnX", spawnLoc.x);
		    PlayerPrefs.SetFloat("SpawnY", spawnLoc.y);
		    PlayerPrefs.SetFloat("SpawnZ", spawnLoc.z);
            Debug.Log("Spawn location set to: " + spawnLoc);
        }//*/
        /*
        temp = endDropDown.GetComponent("ComboBoxTest");
        var finishLoc : Vector3 = temp.GetSelectedLocation();
        //var finishLoc : Vector3 = (ComboBoxTest)endDropDown.GetComponent("ComboBoxTest").GetSelectedLocation();
        if(finishLoc != Vector3.zero)
        {
            endSelected = true;
            PlayerPrefs.SetFloat("endX", finishLoc.x);
		    PlayerPrefs.SetFloat("endY", finishLoc.y);
		    PlayerPrefs.SetFloat("endZ", finishLoc.z);
            Debug.Log("Finish location set to: " + finishLoc);
        }//*/
	}

    void OnGUI()
    {
        // back button
        if (GUI.Button(new Rect(hBuffer, 2.0f * vBuffer + mapHeight, buttonWidth, buttonHeight), "Back"))
        {
            //Debug.Log("Going Back");
            gameObject.GetComponent<CharacterSelect>().enabled = true;
            this.enabled = false;
            startDropDown.SetActive(false);
            endDropDown.SetActive(false);
        }

        // map
        GUI.Box(new Rect(hBuffer, vBuffer, mapWidth, mapHeight), mapTexture);

        // start comboBox
        GUI.Box(startDropDownRect, "Choose a Start");
        // end comboBox
        GUI.Box(endDropDownRect, "Choose an End");

        // text label
        if (!startSelected)
        {
            GUI.Box(new Rect(Screen.width * 0.3f, 2.0f * vBuffer + mapHeight, Screen.width * 0.4f, buttonHeight), "Please Choose a Starting Point");
        }
        else if (!endSelected)
        {
            GUI.Box(new Rect(Screen.width * 0.3f, 2.0f * vBuffer + mapHeight, Screen.width * 0.4f, buttonHeight), "Please Choose an Ending Point");
        }
        else
        {
            GUI.Box(new Rect(Screen.width * 0.3f, 2.0f * vBuffer + mapHeight, Screen.width * 0.4f, buttonHeight), "Press Start when you're Ready");
        }


        // Start button
        if (startSelected && endSelected)
        {
            if (GUI.Button(new Rect(Screen.width - Screen.width * 0.25f, 2.0f * vBuffer + mapHeight, buttonWidth, buttonHeight), "Start"))
            {
                //Debug.Log("Continue");//go to game
                MainController mc = gameObject.GetComponent<MainController>();
                mc.startLoc = startCB.selectedBuilding.Name;
                mc.endLoc = endCB.selectedBuilding.Name;
                mc.goToGame();
            }
        }
    }
}