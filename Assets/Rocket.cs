using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

	public GameObject[] explosions;
	private Vector3 explodePosition;
	private GameObject target;

	// Use this for initialization
	public void setVector(Vector3 v){
		explodePosition = v;
	}
	public void setTarget(GameObject g){
		target = g;
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs (this.transform.position.x) >= Mathf.Abs (explodePosition.x) &&
		   Mathf.Abs (this.transform.position.y) >= Mathf.Abs (explodePosition.y)) {
			//EXPLODE
			Instantiate(explosions[0], this.transform.position, this.transform.rotation);
			Destroy (target.gameObject);
			Destroy (this.gameObject);
		}
		//Debug.Log (this.transform.position.x + " > " + explodePosition.x +" && "+this.transform.position.y + " > " + explodePosition.y);
	}
}
