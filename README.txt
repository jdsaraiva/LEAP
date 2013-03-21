Leap SDK Example Package -- Unity Sandbox
=============================================
Created with Unity 3.5.7

UnitySandbox illustrates how to access Leap Motion data in a Unity application. 
The example also shows how to use finger and tool direction and position
data to interact with a 3D scene.

The scene displays a cube against a reference grid. Finger positions are shown 
as colored spheres with tails indicating direction (toward the hand). You can 
select, move, rotate, and resize the objects in the scene.


Key Leap source files:

* Assets:
  * Plugins -- contains the Leap libraries for Unity
  * Scenes/UnitySandbox.unity -- A Unity scene defining the UnitySandbox scene.
  * Scripts:
    * LeapInput.cs -- Gets a frame of Leap data and makes it available to  
                      other scripts.
    * LeapUnityBridge.cs -- Provides a bridge between Uinty GameObjects and  
                            Leap data.
    * LeapUnityExtensions.cs -- Extends the UnityVector class.
    * LeapUnityHandController.cs -- Controls the representations of a hand in
                                    the scene based on changes in Leap data.
    * LeapUnitySelectionController.cs -- Provides focus, selection, and 
                                         transformation control using Leap data.
    * LeapFingerCollisionDispatcher.cs -- Notifies a LeapSelectionController
                                          when a collision occurs.


--------------------------------------------------------------------------------
Running Unity Sandbox:

1. Launch the Leap application.
2. Open the Leap application About window using the menu of the icon appearing  
   in the Windows Taskbar or Mac Finder bar.
3. Verify that the first three components of the Leap software version code
   match those of this example package.
   
   If the versions do not match, update the Leap application or download the
   latest Examples package.
   
4. Launch the UnitySandbox program. 


--------------------------------------------------------------------------------
Usage:

Select one of the objects by touching it with the sphere displayed for a finger 
tip. After a small delay, an object you are touching becomes selected.

When an object is selected, you can move it around the scene with a finger tip. 
Touch a selected object with two finger tips to scale and rotate it by pinching 
or twisting your fingers.


Other controls:

Dragging the mouse rotates the scene.
Rolling the mouse wheel changes camera distance.

R -- toggle rotation
S -- toggle scaling
T -- toggle translation


--------------------------------------------------------------------------------
Opening the project in Unity:

To open a project in the Unity editor, either navigate to the project folder
using the Open Project menu command in Unity or open a scene file in the 
Assets/Scenes subfolder within the project. If you are using Unity 4, you can 
convert the project when opening it.


* Note: Plug-in support, available with a Unity Pro license (paid or trial) is 
required to use this sample application. *

--------------------------------------------------------------------------------
Copyright © 2012-2013 Leap Motion, Inc. All rights reserved.

Leap Motion proprietary and confidential. Not for distribution. Use subject to
the terms of the Leap Motion SDK Agreement available at 
https://developer.leapmotion.com/sdk_agreement, or another agreement between 
Leap Motion and you, your company or other organization.
