using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingPanel : PropBase {
	/*This code is a exsample of a intractable object that uses the Pulse function
	 * to apply change over a period of time */

	[SerializeField]
	private Color[] flashColours;
	[SerializeField]
	private Color currentColour;

	private int currentSelection;	
	private float count;			//A timer for changing the target colour
	[SerializeField]
	private float countSpeed = 1;	//Time it takes for it to change the target colour
	[SerializeField]
	private float changeSpeed = 1;	//How quickly it goes from current colour to the next
	private MeshRenderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<MeshRenderer> ();
		currentSelection = Random.Range (0,flashColours.Length);
		currentColour = flashColours [currentSelection];
		rend.material.SetColor("_EmissionColor", currentColour);
	}
	
	// We Override the Pulse function with the code for this script to make the material of this object change colour each frame
	public override void Pulse () {
		if (count > 0) {
			currentColour = Color.Lerp (currentColour, flashColours [currentSelection], Time.deltaTime * changeSpeed);
			rend.material.SetColor("_EmissionColor", currentColour);
			count -= Time.deltaTime;
		} else {
			count = countSpeed;
			currentSelection = Random.Range (0,flashColours.Length);
		}
	}
}
