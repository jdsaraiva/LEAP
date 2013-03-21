
 
 
 #pragma strict
 var relativeDirection = Vector3.forward;
var targetObject : GameObject;
targetObject = GameObject.Find("FPS");

function OnTriggerStay (other : Collider) {   

print("fwafwa");

          var absoluteDirection = transform.rotation * relativeDirection;
        targetObject.transform.position += absoluteDirection * Time.deltaTime;

 }
 


 

