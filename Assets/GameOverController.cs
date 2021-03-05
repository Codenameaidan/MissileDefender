using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {

	// Use this for initialization
	public GameObject gameOverMenu;
	public Text scoreText;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void EndGame(){
		gameOverMenu.SetActive (true);
		//if(score > hiscore

		scoreText.text = "SCORE: " + Score.score;
		Score.score = 0;




	}

	public void Retry(){
		gameOverMenu.SetActive (false);
		Time.timeScale = 1;
		SceneManager.LoadScene (0);
	}

	public void Quit(){
		gameOverMenu.SetActive (false);
		Application.Quit ();
	}
}
