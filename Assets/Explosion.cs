using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	public GameObject[] debris;
	public AudioClip[] explosions;
	public float radius;

	private int ammo;
	// Use this for initialization
	void Start () {
		
		Collider2D[] colliders = Physics2D.OverlapCircleAll (new Vector2(this.transform.position.x,this.transform.position.y), radius);
		int totalDestroyed = 0;
		for (int x = 0; x < colliders.Length; x++) {
			if (colliders [x].gameObject.layer == 8) {
				totalDestroyed++;
				Destroy (colliders [x].gameObject);
			}
		}
		int source = totalDestroyed;
		if (source > 2)
			source = 2;
		this.GetComponent<AudioSource> ().PlayOneShot (explosions [source]);

		Score.score += (int)(Mathf.Pow (totalDestroyed, 2)*10);

		for (int x = 0; x < debris.Length; x++) {
			GameObject g = Instantiate (debris[x], this.transform.position, this.transform.rotation);
			g.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (Random.Range (-1, 1), Random.Range (-1, 1)) * Random.Range (500, 2500));
		}
	}

	void getAmmo(){

	}
	// Update is called once per frame
	void Update () {

	}
}
