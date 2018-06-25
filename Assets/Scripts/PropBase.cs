using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropBase : MonoBehaviour {
/*	The objects I want to be intractable will all inherit from this base class. 

	This means I can make variants child classes of this script, that will, while 
	having different code inside their version of the functions below, all still 
	be accessible by other scripts as if they were this ‘PropBase’ class.

	Find out more here: https://unity3d.com/learn/tutorials/topics/scripting/inheritance
*/

	//For interactions you want to be updated each frame while the player has the button down
	public virtual void Pulse () {

	}

	//For interactions you want to be sent on the button press only
	public virtual void Trigger () {

	}
}
