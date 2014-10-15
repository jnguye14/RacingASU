using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{
	private Vector3 SpawnPoint = Vector3.zero;

	// Use this for initialization
	void Start ()
	{
        GameObject startPos = GameObject.Find(PlayerPrefs.GetString("StartLoc"));

        this.transform.position = startPos.transform.position;
        this.transform.position += Vector3.up * 10*0f;

        /*
		if (PlayerPrefs.HasKey ("SpawnX")
		    	&& PlayerPrefs.HasKey ("SpawnY")
		    	&& PlayerPrefs.HasKey ("SpawnZ"))
		{
			SpawnPoint = new Vector3(
					PlayerPrefs.GetFloat("SpawnX"),
					PlayerPrefs.GetFloat("SpawnY"),
					PlayerPrefs.GetFloat("SpawnZ"));
			this.transform.position = SpawnPoint;
		}//*/
	}
	
	// Update is called once per frame
	void Update () { }

	void Respawn()
	{
		this.transform.position = SpawnPoint;
	}
}
