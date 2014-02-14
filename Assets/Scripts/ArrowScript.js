var player : GameObject;
var destination : GameObject;

function Update()
{
	transform.position = player.transform.position;
	//transform.position.y += 1;
	transform.position.y = GameObject.Find("Main Camera").transform.position.y;
	var lookTarget = Vector3(destination.transform.position.x, destination.transform.position.y, destination.transform.position.z);
	lookTarget.y -= 180;
	transform.LookAt(lookTarget);
}
