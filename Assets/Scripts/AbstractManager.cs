using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class AbstractManager : MonoBehaviour {

	public Text Timer, Points, status;
	public uint points;
	public float lEnemySpawn,lPowerUpSpawn;
	public int numOfEnemyPerSpawn;
	public GameObject player;
	public bool started,paused;
	public bool playerFreeze = false, ghostFreeze = false;
	public bool end;
	public List<GameObject> powerUps;
	public GameObject Point;
	public List<GameObject> enemy;
	//public List<GameObject> enemyObs;
	public float timer = 0;
	public List<GameObject> PntObjs;
	public int spawned;
	public bool eat = false;
	public bool ghostMode = false;
	public bool canMove()
	{
		//Debug.Log (started && !paused && !end);
		return started && !paused && !end;
	}
	public void updateTimer()
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
	public void updatePoint()
	{
		Points.text = "POINTS:\n" + points;
	}
	public void spawnPoint()
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
	public void spawnEnemy()
	{
		if (ghostFreeze)
			return;
		if (timer - lEnemySpawn >= 100) {
			uint n = (uint)Random.Range (1, numOfEnemyPerSpawn + 1);
			for (uint i = 0; i < n; i++) {
				int ID = Random.Range (0, enemy.Count);
				Instantiate (enemy [ID]);

			}
			lEnemySpawn = timer;
			spawned++;
		}
		if (spawned == 30) {
			spawned = 0;
			numOfEnemyPerSpawn++;
		}
	}
	public void SpawnPowerUp()
	{
		if (timer - lPowerUpSpawn >= 1500) {
			Instantiate (powerUps [Random.Range (0, powerUps.Count)]);
			lPowerUpSpawn = timer;
		}
	}
    public void reset(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
