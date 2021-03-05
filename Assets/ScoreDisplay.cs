using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
	public Text score;
	public Text hiScore;

	private int playerHiScore;
	// Use this for initialization
	void Start () {
		playerHiScore = PlayerPrefs.GetInt ("hs");
		hiScore.text = ""+playerHiScore;
	}
	
	// Update is called once per frame
	void Update () {
		score.text = ""+Score.score;
		if (Score.score > playerHiScore) {
			hiScore.text = "" + Score.score;
			PlayerPrefs.SetInt ("hs", Score.score);
		}
	}
}
