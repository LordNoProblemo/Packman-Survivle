using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreezeBonus : MonoBehaviour {


	public Text stats;
	public GameManager manager;
	public float timer;
	private string who;
	// Use this for initialization
	void Start () {
		GameObject[] temp = GameObject.FindGameObjectsWithTag(gameObject.tag);
		timer = Random.value * 5 + 5;
		timer *= 100;
		if(temp.Length > 1)
		{
			for(uint i = 0; i < temp.Length; i++)
				if (temp[i] != null && !temp[i].Equals(gameObject)) {
					temp[i].GetComponent<FreezeBonus> ().timer += 100* 2.5f/*Might Change*/;
					GameObject.Destroy (gameObject);
					return;
				}
		}
		manager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		float p = Random.value;
		if (p < 0.5) {
			manager.ghostFreeze = true;
			who = "GHOSTS ";
		} else {
			manager.playerFreeze = true;
			who = "YOU ";
		}
		timer = 5 +Random.value * 5;

		timer *= 100;
		Timer ();
	}

	// Update is called once per frame
	void Update () {
		if (!manager.canMove ())
			return;
		Timer ();

		if (timer > 0) {
			timer -= Time.deltaTime*100;
			if (timer < 0)
				timer = 0;
			return;
		}
		manager.ghostFreeze = false;
		manager.playerFreeze = false;
		GameObject.Destroy (gameObject);
	}
	void Timer()
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
		stats.text = who+"ARE FROZEN!\n" +FTIME;
	}
}
