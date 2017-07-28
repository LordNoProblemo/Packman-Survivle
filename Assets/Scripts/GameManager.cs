using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Text Timer, Points, status;
	public uint points;
	public float lEnemySpawn,lPowerUpSpawn;
	public int numOfEnemyPerSpawn;
	public GameObject player;
	private bool started,paused;
	public bool end;
	public List<GameObject> powerUps;
	public GameObject Point;
	public List<GameObject> enemy;
	//public List<GameObject> enemyObs;
	public float timer = 0;
	private List<GameObject> PntObjs;
	private int spawned;
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
			status.text = "GAME ENDED!!!\n PRESS R TO RESTART";
			status.enabled = true;
		}
		if (started && Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel ("Game");
		}
		if (canMove ()) {
			timer += Time.deltaTime*100;

		}
		if (canMove ()) {
			updateTimer ();
			updatePoint ();
			spawnPoint ();
			spawnEnemy ();
		}

			

	}
	public bool canMove()
	{
		//Debug.Log (started && !paused && !end);
		return started && !paused && !end;
	}
	void updateTimer()
	{
		ulong x = (ulong)timer ;
		ulong mSec = (x)%100;
		x /= 100;
		ulong Sec = x % 60;
		ulong Min = x / 60;
		string FTIME = "" + mSec;
		if (FTIME.Length < 2)
			FTIME = "0" + FTIME;
		FTIME = Sec +":"+ FTIME;
		if(FTIME.Length<5)
			FTIME = "0" + FTIME;
		FTIME = Min + ":" + FTIME;
		if(FTIME.Length < 8)
			FTIME = "0" + FTIME;
		Timer.text = "TIMER:\n" +FTIME;
	}
	void updatePoint()
	{
		Points.text = "POINTS:\n" + points;
	}
	void spawnPoint()
	{
		GameObject newP;
		if ( PntObjs == null) {
			float x = Random.value * 9 - 4.5f;
			float y = Random.value * 9 - 4.5f;
			newP = (GameObject)Instantiate (Point);
			newP.transform.position = new Vector3 (x, y, 0);
			PntObjs = new List<GameObject> ();
			PntObjs.Add (newP);
			return;
		} else if ((uint)Mathf.Sqrt(points/3 +1) > PntObjs.Count) {
			float x = Random.value * 9 - 4.5f;
			float y = Random.value * 9 - 4.5f;
			newP = (GameObject)Instantiate (Point);
			newP.transform.position = new Vector3 (x, y, 0);
			PntObjs.Add (newP);
		}
	}
	void spawnEnemy()
	{
		if (timer - lEnemySpawn >= 100) {
			uint n = (uint)Random.Range (1, numOfEnemyPerSpawn + 1);
			for (uint i = 0; i < n; i++) {
				int ID = Random.Range (0, enemy.Count);
				Instantiate (enemy [ID]);
				lEnemySpawn = timer;
			}
			spawned++;
		}
		if (spawned == 30) {
			spawned = 0;
			numOfEnemyPerSpawn++;
		}
	}

}
