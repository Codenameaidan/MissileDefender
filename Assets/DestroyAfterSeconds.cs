using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour {
	public float time;
	// Use this for initialization
	void Start () {
		
	}
	
	IEnumerator destroy(){
		yield return new WaitForSeconds (time);
		Destroy (this.gameObject);
	}
}
