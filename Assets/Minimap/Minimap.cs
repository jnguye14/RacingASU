using UnityEngine;
using System.Collections;

public class Minimap{
	private float w;
	private float h;
	private float x;
	private float y;
	private bool hidden = false;
	private int px=100;
	private int py=200;

	//This could use some work!
	public Minimap(Rect drawArea){
		x=drawArea.x;
		y=drawArea.y;
		w=drawArea.width;
		h=drawArea.height;
		loadAssets();
	}
	//Set the player's position
	public void setPosition(int x,int y){
		px = x;
		py = y;
	}

	//Load the assets!
    public Texture map;//private Texture map;
	private Texture playerMarker;
	private Texture coverPlate;
	private Texture bg;
	private void loadAssets(){
		//map = (Texture)Resources.Load("mm_map") as Texture;
        map = (Texture)Resources.Load("ASU map 1") as Texture;
		playerMarker=(Texture)Resources.Load("mm_player") as Texture;
		coverPlate=(Texture)Resources.Load("mm_cover") as Texture;
		bg=(Texture)Resources.Load("mm_bg") as Texture;
	}

	//Simulates player movement
	private int offsetC=0;
	private void offset(){
		offsetC++;
		px = (int)Mathf.Abs(Mathf.Sin((offsetC+200)/1000f)*map.width);
		py = (int)Mathf.Abs(Mathf.Sin(offsetC/1000f)*map.height);
	}

	public void draw(){
		//offset (); //testing player position
		if(hidden)return;
		//Draw map stuff!
		GUI.DrawTexture(new Rect(x,y,w,h),bg);
		//Draw the map at screen coords x and y, with clipping mask!
		DrawTextureClipped(map,x,y,new Rect(px-(w/2),py-(w/2),w,h));
		//Draw the player marker!
		GUI.DrawTexture(new Rect(x+(w/2)-(playerMarker.width/2),y+(w/2)-(playerMarker.width/2),playerMarker.width,playerMarker.height),playerMarker);
		//This will be used to draw different icons and whatever else
		drawPoints();
		//Finally, draw the cover plate!
		GUI.DrawTexture(new Rect(x,y,w,h),coverPlate);
	}
	public void drawPoints(){
		//loop through mapPoint objects
		//if position is within the map's bounds, draw
		//mapPoints will support text and images
	}

	public void DrawTextureClipped(Texture textureToDraw,float x, float y, Rect textureCoords){
		//Start Magic
		GUI.BeginGroup(new Rect (x, y, textureCoords.width, textureCoords.height));
		GUI.Label(new Rect(-textureCoords.x,-textureCoords.y,textureToDraw.width,textureToDraw.height), textureToDraw);
		GUI.EndGroup ();
		//End Magic
	}

	public void hide(){
		hidden = true;
	}

	public void show(){
		hidden = false;
	}
}
