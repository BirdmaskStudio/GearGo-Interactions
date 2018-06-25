using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : PropBase {
/*	This is a child of the PropBase script that handles picking up items and throwing them
 	If you wanted you could make a child that inherits from this script, perhaps one that
 	had a condition to being picked up or isn't thrown when released from the players hand.

	E.G You could make a child class called Key, On 'Release' it could check what object the 
	player is pointing at. If it's a door that is locked the key changes the doors scripts 
	locked boolean to false and triggers it to open before destroying itself, for anything 
	else it just gets thrown as normal.
*/
	private Rigidbody rb;

	void Start(){
		rb = GetComponent<Rigidbody> ();
	}

	public virtual void Store(Transform NewParent){
		//The following stops the object being effected by physics while it's in the players hand
		rb.isKinematic = true;
		//And fixes it to the new parent it is given by the player script to follow.
		transform.parent = NewParent;
		//It then resets it's position and rotation to match it's new parent object
		transform.localRotation = Quaternion.identity;
		transform.localPosition = Vector3.zero;
	}
	public virtual void Release(Vector3 ThrowDir, float ThrowForce){
		//On Release the object is made to be effected by physics again.
		rb.isKinematic = false;
		//Free itself from following it's parent object
		transform.parent = null;
		//And applies a burst of force for one frame to propel itself away from the player.
		rb.AddForce (ThrowDir * ThrowForce,ForceMode.Impulse);
	}
}
