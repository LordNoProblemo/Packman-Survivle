using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeBonus : MonoBehaviour {
	private GameObject player;
	public Text stats;
	public GameManager manager;
	public float timer;
	float scale = 1f;
	// Use this for initialization
	void Start () {
		GameObject[] temp = GameObject.FindGameObjectsWithTag(gameObject.tag);
		timer = Random.value * 5 + 5;
		timer *= 100;
		if(temp.Length > 1)
		{
			for(uint i = 0; i < temp.Length; i++)
				if (temp[i] != null && !temp[i].Equals(gameObject)) {
					temp[i].GetComponent<SizeBonus> ().timer += 100* 2.5f/*Might Change*/;
					GameObject.Destroy (gameObject);
					return;
				}
		}
		player = GameObject.FindGameObjectWithTag ("Player");
		manager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		float p = Random.value;
		if (p < 0.5)
			scale = 0.5f;
		else if (p < 0.99)
			scale = 2f;
		else
			scale = 3f;
		timer = 5 ;
		if (p < 0.99)
			timer += Random.value * 5;
		timer *= 100;
		player.gameObject.transform.localScale *= scale;
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
		player.transform.localScale /= scale;
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
		stats.text = "CHANGE OF SIZE!\n" +FTIME;
	}
}
