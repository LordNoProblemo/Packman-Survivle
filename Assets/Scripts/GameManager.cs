using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : AbstractManager {



	// Use this for initialization
	void Start () {
		started = false;
		paused = false;
		end = false;
		points = 0;
		timer = 0;
		numOfEnemyPerSpawn = 1;
		Timer.text = "TIMER:\n00:00:00";
		Points.text = "POINTS:\n0";
		status.text = "To start the game,\npress on Space";

		lEnemySpawn = 0;
		lPowerUpSpawn = 0;	

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("MainMenu");
		}
		if (!started) {
			if (Input.GetKey (KeyCode.Space)) {
				started = true;
			}
		} else if (!end) {
			status.text = "PAUSED";
			status.enabled = paused;
			if (Input.GetKeyDown (KeyCode.P)) {
				paused = !paused;
			}
		} else {
			status.text = "GAME ENDED!!!";
			status.enabled = true;
		}
		if (started && Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene ("Game");
		}

		if (canMove ()) {
			timer += Time.deltaTime*100;
			updateTimer ();
			updatePoint ();
			spawnPoint ();
			spawnEnemy ();
			SpawnPowerUp ();
		}

			

	}


}
