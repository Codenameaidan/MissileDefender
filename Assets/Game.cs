using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	public GameObject[] rockets;
	
	// Update is called once per frame
	void FixedUpdate () {
		int x = Random.Range (0, 120); // ~Once every 2 seconds

		if(x == 7)
		{
			ShootRocket ();
		}
	}

	void ShootRocket()
	{
		int rnd = Random.Range (1, 5); //generate # of rockets to shoot (1-4)
		for (int x = 0; x < rnd; x++) {
			Vector3 startLocation = new Vector3 (Random.Range (-150, 150), 400, 0);
			Vector3 targetLocation;


			int chanceTowardsCenter = Random.Range (1, 4); //1 in 3 chance a rocket will go to an actual target rather than random.
			if (chanceTowardsCenter == 2) {
				targetLocation = new Vector3 (0, 12, 0);
			} else {
				targetLocation = new Vector3 (Random.Range (-110, 110), 0, 0);
			}

			Vector3 diff = targetLocation - startLocation;
			diff.Normalize ();

			float rot_z = Mathf.Atan2 (diff.y, diff.x) * Mathf.Rad2Deg;
			GameObject rocket = Instantiate (rockets [0], startLocation, Quaternion.Euler (0f, 0f, rot_z - 90));
			rocket.GetComponent<Rigidbody2D> ().AddForce (rocket.transform.up * Random.Range (1600, 2200));
		}
	}
}
