/******************************************************************************\
* Copyright (C) Leap Motion, Inc. 2011-2013.                                   *
* Leap Motion proprietary and  confidential.  Not for distribution.            *
* Use subject to the terms of the Leap Motion SDK Agreement available at       *
* https://developer.leapmotion.com/sdk_agreement, or another agreement between *
* Leap Motion and you, your company or other organization.                     *
\******************************************************************************/

using UnityEngine;
using System.Collections;

/// <summary>
/// Attach one of these to one of the objects in your scene to use Leap input.
/// It will take care of calling update on LeapInput and create hand objects
/// to represent the hand data in the scene using LeapUnityHandController.
/// It has a number of public fields so you can easily set the values from
/// the Unity inspector. Hands will 
/// </summary>
public class LeapUnityBridge : MonoBehaviour
{
	/// <summary>
	/// These values, set from the Inspector, set the corresponding fields in the
	/// LeapUnityExtension for translating vectors.
	/// </summary>
	public Vector3 m_LeapScaling = new Vector3(0.02f, 0.02f, 0.02f);
	public Vector3 m_LeapOffset = new Vector3(0,0,0);
	
	public bool m_UseFixedUpdate = false; //If true, calls LeapInput.Update from FixedUpdate instead of Update
	public bool m_ShowInspectorFingers = true; //If false, hides the hand game objects in the inspector.
	public GameObject m_InputParent; //The parent of the hand objects for motion.  Useful 
	public GameObject m_FingerTemplate; //The template object to use for the fingers. Must have Tags set correctly
	public GameObject m_PalmTemplate; //The template object to use for the palms.
	
	/// <summary>
	/// The materials to use for the different hands.
	/// </summary>
	public Material m_PrimaryHandMaterial; 
	public Material m_SecondaryHandMaterial;
	public Material m_UnknownHandMaterial;
	
	private static bool m_Created = false;
	
	void Awake()
	{
		if( m_Created )
		{
			throw new UnityException("A LeapUnityBridge has already been created!");
		}
		m_Created = true;
		Leap.UnityVectorExtension.InputScale = m_LeapScaling;
		Leap.UnityVectorExtension.InputOffset = m_LeapOffset;
		
		if( !m_FingerTemplate )
		{
			Debug.LogError("No Finger template set!");
			return;
		}
		if( !m_PalmTemplate )
		{
			Debug.LogError("No Palm template set!");
			return;
		}
		CreateSceneHands();
	}
	void OnDestroy()
	{
		m_Created = false;	
	}
	
	void FixedUpdate()
	{
		if( m_UseFixedUpdate )
			LeapInput.Update();
	}
	
	void Update()
	{
		if( !m_UseFixedUpdate )
			LeapInput.Update();
		
		if( Input.GetKeyDown(KeyCode.T) )
			LeapInput.EnableTranslation = !LeapInput.EnableTranslation;
		if( Input.GetKeyDown(KeyCode.R) )
			LeapInput.EnableRotation = !LeapInput.EnableRotation;
		if( Input.GetKeyDown(KeyCode.S) )
			LeapInput.EnableScaling = !LeapInput.EnableScaling;
	}
	
	private void CreateSceneHands()
	{
		GameObject hands = new GameObject("Leap Hands");
		
		if( m_InputParent )
		{
			hands.transform.parent = m_InputParent.transform;
		}
		else
		{
			hands.transform.parent = transform;
		}
		
		hands.AddComponent(typeof(LeapUnityHandController));
		LeapUnityHandController behavior = hands.GetComponent<LeapUnityHandController>();
		behavior.m_palms = new GameObject[2];
		behavior.m_fingers = new GameObject[10];
		behavior.m_hands = new GameObject[3]; //extra 'invalid' hand for grouping purposes
		behavior.m_materials = new Material[] { m_PrimaryHandMaterial, m_SecondaryHandMaterial, m_UnknownHandMaterial };
		
		for( int i = 0; i < behavior.m_hands.Length; i++ )
		{
			behavior.m_hands[i] = CreateHand(hands, i);	
		}
		for( int i = 0; i < behavior.m_fingers.Length; i++ )
		{
			behavior.m_fingers[i] = CreateFinger(behavior.m_hands[2], i);
		}
		for( int i = 0; i < behavior.m_palms.Length; i++ )
		{
			behavior.m_palms[i] = CreatePalm(behavior.m_hands[2], i);	
		}
		
		foreach( GameObject fingerTip in GameObject.FindGameObjectsWithTag("FingerTip") )
		{
			Debug.Log ("adding component...");
			fingerTip.AddComponent(typeof(LeapFingerCollisionDispatcher));	
		}
	}
	private GameObject CreateHand(GameObject parent, int index)
	{
		GameObject hand = new GameObject();
		hand.transform.parent = parent.transform;
		if( index == 0 )
			hand.name = "Primary Hand";
		else if( index == 1 )
			hand.name = "Secondary Hand";
		else
			hand.name = "Unknown Hand";
		
		return hand;
	}
	private GameObject CreateFinger(GameObject parent, int index)
	{
		GameObject finger = Instantiate(m_FingerTemplate) as GameObject;
		finger.transform.parent = parent.transform;
		finger.name = "Finger " + index;
		
		return finger;
	}
	private GameObject CreatePalm(GameObject parent, int index)
	{
		GameObject palm = Instantiate(m_PalmTemplate) as GameObject;
		palm.name = "Palm " + index;
		palm.transform.parent = parent.transform;
		
		return palm;
	}
};
