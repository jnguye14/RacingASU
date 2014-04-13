using System;
using UnityEngine;
public class MinimapHandler:MonoBehaviour{
	//I made a controller for some reason!
	Minimap map;
    public GameObject player;
    public Vector3 originPosition; // i.e. upper left
    public Vector3 bottomRightPosition;
	void Start(){
		map=new Minimap(new Rect(Screen.width-220,Screen.height-220,200,200));
	}
	void Update(){
        float width = Mathf.Abs(bottomRightPosition.x - originPosition.x);
        float height = Mathf.Abs(bottomRightPosition.z - originPosition.z);
        float xOffset = Mathf.Abs(player.transform.position.x - originPosition.x);
        float zOffset = Mathf.Abs(player.transform.position.z - originPosition.z);
        Debug.Log(xOffset + " " + zOffset);
        map.setPosition((int)(xOffset / width * map.map.width),
                (int)(zOffset/ height * map.map.height));
	}
	void OnGUI(){
		map.draw();
	}
}