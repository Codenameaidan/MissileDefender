using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public int maxHealth;
	public float fireRate;
	public GameObject missile;
	public Transform shootLocation;
	public float shootSpeed;
	public GameObject targetMarker;
	public GameObject[] buildings;

	public Text totalAmmo;

	public AudioClip shootSound;
	public GameOverController gameOverController;

	private int health;
	private int ammo;


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int currAmmo = this.GetAmmo ();
		totalAmmo.text = ""+currAmmo;

		if (Input.GetMouseButtonDown(0) && currAmmo > 0 && Time.timeScale>0) { //On click, if ammo, if not paused
			Shoot ();
		}
	}

	void Shoot(){
		Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - shootLocation.position;
		diff.Normalize();

		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		shootLocation.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
		GameObject target = Instantiate (targetMarker, new Vector3(Camera.main.ScreenToWorldPoint (Input.mousePosition).x,Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 0), new Quaternion(0,0,0,0));

		Rigidbody2D rb = Instantiate (missile, new Vector3(shootLocation.transform.position.x, shootLocation.transform.position.y, shootLocation.transform.position.z), shootLocation.rotation).GetComponent<Rigidbody2D> ();
		rb.GetComponent<Rocket> ().setVector (Camera.main.ScreenToWorldPoint(Input.mousePosition));
		rb.GetComponent<Rocket> ().setTarget (target);
		rb.AddForce (shootLocation.transform.up * shootSpeed);

		for (int x = 0; x < 1000; x++) { //1000 tries to remove ammo
			//This is a weird way to randomly remove from 1 of 4 buckets (any of the buckets could be empty :/)
			//Will fix later
			int rnd = Random.Range(0, buildings.Length);
			if (buildings [rnd].GetComponent<Building> ().getAmmo () > 0) {
				buildings [rnd].GetComponent<Building> ().takeAmmo ();
				break;
			}

		}
		this.GetComponent<AudioSource> ().PlayOneShot (shootSound);

	}

	int GetAmmo(){
		int total = 0;
		for (int x = 0; x < buildings.Length; x++)
		{
			total += buildings [x].GetComponent<Building> ().getAmmo();
		}
		return total;
	}


	public void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.gameObject.layer == 8)
		{
			Time.timeScale = 0;
			gameOverController.EndGame ();
		}
	}

}
