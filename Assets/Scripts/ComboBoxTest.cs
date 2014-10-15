/*
coded by Jordan Nguyen (Jordan.N.Nguyen@asu.edu)
*/

using UnityEngine;
using System.Collections;

public class ComboBoxTest : MonoBehaviour
{
    public Rect boundingBox = new Rect(10, 10, 410, 40);
    public Building[] buildings;

    public Building selectedBuilding;
    private string startCode = "Click Here to Type Code";
    private string startDropText = "Drop Down Menu";
    private bool startDropOn = false;
    private bool showError = false;
    private Vector2 startScrollPosition = Vector2.zero;
    //var fileName = "/Scripts/credits.txt";

    public bool hasBuilding
    {
        get
        {
            return (selectedBuilding.Name != "");//(selectedBuilding != null);
        }
    }

    // Use this for initialization
    void Start()
    {
        // TODO: add buildings dynamically (perhaps from text file?)
        /*
        var sr = new StreamReader(Application.dataPath + fileName); // "..UnityGameProject/Assets" + fileName
        var fileContents = sr.ReadToEnd();
        sr.Close();
        creditText = fileContents;
        //parse file contents
        //*/
        /*buildings = new Building[]{
            new Building("building 1"),
            new Building("building 2"),
            new Building("Building 3"),
            new Building("building 4")//,
            //new Building("building 5"),
            //new Building("building 6")
        };//*/
    }

    int FindBuildingCode(string input)
    {
        for (int i = 0; i < buildings.Length; i++)
        {
            if (buildings[i].Code == input || buildings[i].Name == input)
            {
                return i;
            }
        }
        return -1;
    }

    void SetCurrentBuilding(Building b)
    {
        showError = false;

        startCode = b.Code;
        startDropText = b.Name;

        selectedBuilding = b;
        // Depends on whether this is the start combobox or the end combobox
        //PlayerPrefs.SetFloat("SpawnX", b.SpawnLocation.x);
        //PlayerPrefs.SetFloat("SpawnY", b.SpawnLocation.y);
        //PlayerPrefs.SetFloat("SpawnZ", b.SpawnLocation.z);
    }

    Vector3 GetSelectedLocation()
    {
        if (selectedBuilding != null)
        {
            return selectedBuilding.SpawnLocation;
        }
        else
        {
            return Vector3.zero;
        }
    }

    void OnGUI()
    {
        // get bounding box dimensions used for determining area of GUI elements
        // box separated into four quadrants
        float x = boundingBox.x;
        float y = boundingBox.y;
        float w = boundingBox.width / 2.0f;
        float h = boundingBox.height / 4.0f;//2.0f;
        float buf = 5.0f; // buffer between quadrants
        GUI.depth = -1;

        // Text Field for user to type in building name or code
        GUI.Label(new Rect(x, y, w, h), "Enter a building code: ");
        if (GUI.GetNameOfFocusedControl() == "Code Input"
                && Event.current.type == EventType.KeyDown
                && (Event.current.keyCode == KeyCode.Return))
        {
            GUI.FocusControl("");
            int index = FindBuildingCode(startCode);
            if (index == -1)
            {
                showError = true;
                startCode = "";
            }
            else
            {
                showError = false;
                SetCurrentBuilding(buildings[index]);
            }
        }
        if (GUI.GetNameOfFocusedControl() == "Code Input" && showError)
        {
            showError = false;
        }
        GUI.SetNextControlName("Code Input");
        startCode = GUI.TextField(new Rect(x + w + buf, y, w, h), startCode, 25);

        // input error
        if (showError)
        {
            Color temp = GUI.contentColor;
            GUI.contentColor = Color.red;
            GUI.Label(new Rect(x + w + buf + 10, y, w, h), "Unable to find building");
            GUI.contentColor = temp;
        }

        // alternatively, users can use a dropdown box to find their building
        GUI.Label(new Rect(x, y + h + buf, w, h), "Else, choose from dropdown:");
        if (GUI.Button(new Rect(x + w + buf, y + h + buf, w, h), startDropText))
        {
            if (startDropOn) startDropOn = false;
            else startDropOn = true;
        }

        if (startDropOn)
        {
            GUI.Box(new Rect(x + w + buf, y + 2 * h + buf, w, Mathf.Min(100, buildings.Length * h)), "");
            startScrollPosition = GUI.BeginScrollView(
                    new Rect(x + w + buf, y + 2 * h + buf, w, Mathf.Min(100, buildings.Length * h)), // same as GUI.Box (i.e. viewable area on screen)
                    startScrollPosition, // zero
                    new Rect(0, 0, w - 16, buildings.Length * h), // size of content area
                    false, // do not horizontal scrollbar unless necessary
                    true // always show vertical scrollbar
                    );

            for (int i = 0; i < buildings.Length/*.Count*/; i++)
            {
                string temp = buildings[i].Name;
                if (GUI.Button(new Rect(0, i * h, w - 16, h), temp))
                {
                    SetCurrentBuilding(buildings[i]);
                    startDropOn = false;
                }
            }

            GUI.EndScrollView();
        }
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
    public Vector3 SpawnLocation;

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
            switch (SpawnDirection)
            {
                case Direction.East:
                    SpawnLocation = position + radius * new Vector3(0, 0, 1);
                    break;
                case Direction.North:
                    SpawnLocation = position + radius * new Vector3(1, 0, 0);
                    break;
                case Direction.South:
                    SpawnLocation = position + radius * new Vector3(-1, 0, 0);
                    break;
                case Direction.West:
                    SpawnLocation = position + radius * new Vector3(0, 0, -1);
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