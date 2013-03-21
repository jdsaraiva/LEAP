#pragma strict
var someText : String = "this is some tex fwafwafwafw fawfawfaw ffwafawfwat";

function Start () {

}

function Update () {

}

function OnGUI () {
	if (GUI.Button (Rect (Screen.width / 2 - 75, Screen.height / 2 -25,150,50), "this is a button")) {
		print ("button clicked");
	}
	
		GUI.Label (Rect (200,40,600,90), someText );
		
			GUI.Box(Rect(10,10,100,90), "Menu");


	if(GUI.Button(Rect(20,40,80,20), "Level 1")) {
		print ("button 1 clicked");
	}
	
	if(GUI.Button(Rect(20,70,80,20), "Level 2")) {
		print ("button 2 clicked");
	}

	
}
