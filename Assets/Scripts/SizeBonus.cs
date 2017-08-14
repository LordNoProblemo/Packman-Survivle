using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeBonus : MonoBehaviour {
	private GameObject player;
	public Text stats;
	public AbstractManager manager;
	public float timer;
	float scale = 1f;
    public bool main;
    public GameObject growAud, shrinAud;
    bool close;
	// Use this for initialization
	void Start () {
        close = false;
        growAud.SetActive(false);
        shrinAud.SetActive(false);
		GameObject[] temp = GameObject.FindGameObjectsWithTag(gameObject.tag);
		timer = Random.value * 5 + 5;
		timer *= 100;
        main = false;
        if (temp.Length > 1)
        {
            for (uint i = 0; i < temp.Length; i++)
                if (temp[i] != null  && temp[i].GetComponent<SizeBonus>() != null && temp[i].GetComponent<SizeBonus>().main && !temp[i].Equals(gameObject))
                {
                    temp[i].GetComponent<SizeBonus>().timer += 100 * 2.5f/*Might Change*/;
                    GameObject.Destroy(gameObject);
                    return;
                }
        }
        else
            main = true;
		player = GameObject.FindGameObjectWithTag ("Player");
		manager = GameObject.FindGameObjectWithTag ("Manager").GetComponent<AbstractManager> ();
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
        if (p < 0.5)
            shrinAud.SetActive(true);
        else
            growAud.SetActive(true);
		timer *= 100;
		player.gameObject.transform.localScale *= scale;
		Timer ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (manager == null)
            return;
		if (!manager.canMove ())
			return;
		Timer ();

		if (timer > 0) {
			timer -= Time.deltaTime*100;
			if (timer < 0)
				timer = 0;
			return;
		}
        if (!close)
        {
            player.transform.localScale /= scale;
            growAud.SetActive(!growAud.activeSelf);
            shrinAud.SetActive(!shrinAud.activeSelf);
            timer = 150;
            stats.gameObject.SetActive(false);
            close = true;
            return;
        }
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
