var player : GameObject;
var destination : GameObject;
var Target : GameObject;

var height : float = 5.0f;
var farColor : Color = Color(128.0f/255.0f, 0, 0, 1); // maroon
var nearColor : Color = Color(255.0f/255.0f, 215.0f/255.0f, 0, 1); // gold

var distance;
function Start()
{
    if(destination == null)
    {
        destination = GameObject.Find(PlayerPrefs.GetString("EndLoc"));
        Instantiate (Target, destination.transform.position, Quaternion.identity);
    }
    distance = (player.transform.position - destination.transform.position).magnitude;
}

function Update()
{
    var percentage = (player.transform.position - destination.transform.position).magnitude / distance;
    transform.Find("Default/Object_1").GetComponent(MeshRenderer).renderer.material.color = Color.Lerp(nearColor,farColor,percentage);

	transform.position = player.transform.position;
	//transform.position.y = GameObject.Find("Main Camera").transform.position.y;
    transform.position.y = Camera.main.ScreenToWorldPoint(new Vector3(0,0,0)).y;
	transform.position.y += height;
	var lookTarget = Vector3(destination.transform.position.x, destination.transform.position.y, destination.transform.position.z);
	lookTarget.y -= 180;
	transform.LookAt(lookTarget);
}
