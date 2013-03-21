#pragma strict
var targetObject : GameObject;
targetObject = GameObject.Find("FPS");

function OnTriggerStay  (other : Collider) { 

if(other.gameObject.tag=="FingerTip"){ 
var translation : float = Time.deltaTime * 5;
targetObject.transform.Translate (0, 0, translation);
 }

 } 
 



