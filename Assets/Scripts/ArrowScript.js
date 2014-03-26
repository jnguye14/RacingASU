var player : GameObject;
var destination : GameObject;

var height : float = 5.0f;

function Update()
{
	transform.position = player.transform.position;
	//transform.position.y = GameObject.Find("Main Camera").transform.position.y;
    transform.position.y = Camera.main.ScreenToWorldPoint(new Vector3(0,0,0)).y;
	//transform.position.y += height;
	var lookTarget = Vector3(destination.transform.position.x, destination.transform.position.y, destination.transform.position.z);
	lookTarget.y -= 180;
	transform.LookAt(lookTarget);
}
