#pragma strict
var targetObject : GameObject;

targetObject = GameObject.Find("FPS");

function OnTriggerStay (other : Collider) { 
  
if(other.gameObject.tag=="FingerTip"){ 
print("ESQUERDA");
targetObject.transform.rotation *= Quaternion.Euler(0, -1, 0);
   }

 }
 

