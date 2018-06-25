using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPointer : MonoBehaviour {

	//Returns whatever object is infrount of the controller
	private GameObject pointerOver;
	[SerializeField]
	//Is the object that is currently intractable
	private PropBase selectedObject;
	//Is the object currently stored in hand, ready to throw.
	[SerializeField]
	private PickUp inHand;

	//This is a refrance to the object we want the pointer to be cast from.
	[SerializeField]
	public Transform controllerRef;
	//This is where we want object we are holding to appear
	[SerializeField]
	private Transform holdingRef;
	//The amount of force we want to throw objects from our hand with.
	[SerializeField]
	[Range(2,12)]
	private float throwForce = 10;

	//The script that handles the visuals to show what object is selected
	[SerializeField]
	private HighlightObject selectVisual;
	private LineRenderer line;

	void Start () {
		line = GetComponent<LineRenderer> ();
	}
	
	void Update () {
		//If a object is currently being held I don't want to select another object until it is thrown.
		if (inHand == null) {
			WorldPointer ();
		} else {
			line.SetPosition (0, controllerRef.position);
			line.SetPosition (1, controllerRef.position);
			pointerOver = null;
		}
		//This function handles how you intract with selected objects
		Intract ();
	}

	//This function handles shooting a raycast into the world from the controller to see what can be intracted with.
	void WorldPointer(){
		//We set the line visual to start from the controller.
		line.SetPosition (0, controllerRef.position);

		RaycastHit hit;
		//We reset the pointer so things don't stay selected when we are pointing at nothing.
		pointerOver = null;

		//This sends a line from the controller directly ahead of it, it returns true if it hits something. Using the RaycastHit we can then get information back.
		if (Physics.Raycast (controllerRef.position, controllerRef.forward, out hit)) {
			//Beacuse raycast is true only when it hits anything, we don't need to check if hit is null
			//We set pointerOver to whatever object the raycast hit.
			pointerOver = hit.collider.gameObject;
			//We set the line visual to stop and the point the raycast hit the object.
			line.SetPosition (1, hit.point);

			//Here we check if the object we hit has the PropBase component, or a child class of its.
			if (pointerOver.GetComponent<PropBase> ()) {
				//We set the object to be highlighted
				selectVisual.NewObject (pointerOver);
			} else {
				selectVisual.ClearObject ();
			}
		} else {
			//If the raycast hits nothing we set the line visual to stop a little bit infrount of the controller.
			line.SetPosition (1, controllerRef.position + controllerRef.forward * 10);
			selectVisual.ClearObject ();
		}

		Debug.DrawRay(controllerRef.position , controllerRef.forward * 10,Color.grey);
	}

	void Intract(){
		//We set up the input "OculusTouchpad" in the Input manager
		if (Input.GetButtonDown ("Jump") || OVRInput.GetDown (OVRInput.Button.PrimaryTouchpad)) {
			selectVisual.ClearObject ();				
			//Check if you are holding something you can throw first
			if (inHand != null) {
				inHand.Release (controllerRef.forward, throwForce);
				inHand = null;
				//We do this check here to prevent Errors if you have nothing selected
			} else if (selectedObject != null) {
				//Check if you can pick up the selected object second
				if (selectedObject.GetComponent<PickUp> ()) {
					//Beacuse PickUp is a child of PropBase, we can ask InHand to store selectedObject as PickUp, rather than use GetComponent
					inHand = selectedObject as PickUp;
					inHand.Store (holdingRef);
					//If non of the above were valid then simple call the trigger function of the selected object
				} else {
					selectedObject.Trigger ();
				}
			}
			//If you have a object that you need to hold down a button to intract with
		} else if (Input.GetButton ("Jump") && selectedObject != null || OVRInput.Get (OVRInput.Button.PrimaryTouchpad) && selectedObject != null) {
			selectedObject.Pulse ();
			//When you are not pressing down the touchpad button, the selected object can be updated
		} else if (pointerOver != null) {
			if (pointerOver.GetComponent<PropBase> ()) {
				selectedObject = pointerOver.GetComponent<PropBase> ();
			} else {
				selectedObject = null;
			}
		} else {
			selectedObject = null;
		}
	
	}

}
