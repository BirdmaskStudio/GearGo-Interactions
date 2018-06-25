using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : PropBase {
	[SerializeField]
	private GameObject gate;

	//We override the Trigger function so we can make it run this code instead of the default code in the 'PropBase' class.
	public override void Trigger () {
		//This toggles the activestate of the target object
		gate.SetActive (!gate.activeSelf);
	}
}
