using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightObject : MonoBehaviour {
	[SerializeField]
	private GameObject targetObject;

	[SerializeField]
	private MeshFilter rend;

	void Start(){
		rend = GetComponent<MeshFilter> ();
	}
	//private MeshRenderer rend;
	// Use this for initialization
	void Update () {
		if (targetObject != null) {
			transform.position = targetObject.transform.position;
			transform.localScale = targetObject.transform.localScale;
			transform.rotation = targetObject.transform.rotation;
		}
	}
	
	// Update is called once per frame
	public void NewObject (GameObject NewObject) {
		targetObject = NewObject;
		transform.position = targetObject.transform.position;
		transform.localScale = targetObject.transform.lossyScale;
		transform.rotation = targetObject.transform.rotation;
		if (targetObject.GetComponent<MeshFilter> ()) {
			rend.mesh = targetObject.GetComponent<MeshFilter> ().sharedMesh;
		}
	}
	public void ClearObject(){
		rend.mesh = null;
		transform.position = Vector3.zero;
	}
}
