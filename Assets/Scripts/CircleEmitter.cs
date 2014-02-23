using UnityEngine;
using System.Collections;

// custom particle system
public class CircleEmitter : MonoBehaviour
{
	public GameObject Circle;
	public int numCircles = 5; // number of circles at any given time
	public float interval = 1.0f; // rate at which circle spawns (1 second default)
	public float speed = 1.0f; // how fast circles move in indicated direction

	private ArrayList Circles;
	private float timer = 0;
	private Vector3 direction = Vector3.up;

	// Use this for initialization
	void Start ()
	{
		Circles = new ArrayList ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;
		if (timer > interval) // at spawn rate
		{
			timer -= interval;

			// add another circle
			GameObject c = (GameObject)Instantiate (Circle, this.transform.position, Quaternion.identity);
			Circles.Add(c);

			// remove first circle if too many circles
			if(Circles.Count > numCircles)
			{
				c = (GameObject)Circles[0];
				Circles.RemoveAt(0);
				Destroy (c);
			}
		}

		// all circles move in indicated direction
		foreach (GameObject c in Circles)
		{
			c.transform.Translate(direction * Time.deltaTime * speed);
		}
	}
}
