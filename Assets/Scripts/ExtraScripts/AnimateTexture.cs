using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateTexture : MonoBehaviour {
	[SerializeField]
	//[Range(-1,1)]
	private Vector2 animSpeed;
	[SerializeField]
	private Vector2 place;
	private MeshRenderer meshRend;
	private Vector2 startOffset;
	// Use this for initialization
	void Start () {
		meshRend = GetComponent<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		place += animSpeed * Time.deltaTime; 
		meshRend.material.mainTextureOffset = (place);
	}
}
