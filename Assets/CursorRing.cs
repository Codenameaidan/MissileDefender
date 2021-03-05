using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorRing : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3(Camera.main.ScreenToWorldPoint (Input.mousePosition).x,Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 0);
		Debug.Log (this.transform.position.x + ", " + this.transform.position.y);
	}
}
