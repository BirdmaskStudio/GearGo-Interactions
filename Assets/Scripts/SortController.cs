using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortController : MonoBehaviour {
	/* A quick script that checks which controller is active, the left or right motion controller */
	[SerializeField]
	private Transform PCControllerRef;
	[SerializeField]
	private Transform rightControllerRef;
	[SerializeField]
	private Transform LeftControllerRef;

	[SerializeField]
	private Transform controllerRef;

	void Update () {
		if(OVRInput.IsControllerConnected( OVRInput.Controller.LTrackedRemote)){
			SetRef (LeftControllerRef);
		}else if(OVRInput.IsControllerConnected( OVRInput.Controller.RTrackedRemote)){
			SetRef (rightControllerRef);
		}else{
			SetRef (PCControllerRef);
			PCControllerRef.LookAt (Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(100));
		}
	}

	void SetRef(Transform Ref){
		controllerRef.parent = Ref;
		controllerRef.localPosition = Vector3.zero;
		controllerRef.localRotation = Quaternion.identity;
	}

}
