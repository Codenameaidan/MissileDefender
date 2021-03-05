using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
	public GameObject pause;
	public GameObject options;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			pause.SetActive (!pause.activeSelf);
			if (pause.activeSelf) {
				Time.timeScale = 0;
			} else {
				Time.timeScale = 1;
			}
		}
	}

	public void clickResume(){
		pause.SetActive (false);
		Time.timeScale = 1;
	}
	public void clickOptions(){
		pause.SetActive (false);
		options.SetActive (true);
	}
	public void clickQuit(){

	}

}
