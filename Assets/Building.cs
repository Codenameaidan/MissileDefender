using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour {

	// Use this for initialization
	public int maxAmmo;
	public float ammoRegenSpeed;

	public Text ammoText;
	public GameObject explosion;
	public Transform pos;

	private bool destroyed = false;
	private int currentAmmo;

	void Start () {
		StartCoroutine (genAmmo ());
	}

	public int getAmmo(){ //Return the ammo this building has
		if (destroyed)
			return 0;
		else
			return currentAmmo;
	}
	public void takeAmmo(){ //Subtract one ammo and update text
		currentAmmo--;
		ammoText.text = "" + currentAmmo;
	}

	public void OnCollisionEnter2D(Collision2D col) //Destroy
	{
		if (destroyed) {
			return;
		}
		if (col.collider.gameObject.layer == 8){
			Instantiate (explosion, pos.position, pos.rotation);
			currentAmmo = 0;
			ammoText.text = "x";
			destroyed = true;
			this.GetComponent<Animator>().enabled = true;
		}
	}

	IEnumerator genAmmo(){ //Generate more ammo over time
		while (!destroyed) {
			yield return new WaitForSeconds (ammoRegenSpeed);
			if (currentAmmo < maxAmmo) {
				currentAmmo++;
				ammoText.text = "" + currentAmmo;
			}
		}
		ammoText.text = "x";
	}
}
