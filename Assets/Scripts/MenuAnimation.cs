﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour {

	public List<GameObject> ghosts;
	private float timer = 0,pacTimer = 0;
	public static int i = 0;
    static bool start = true;
    public GameObject sound;
	// Use this for initialization
	void Start () {
		i = 0;
        if (sound != null)
            sound.SetActive(start);
        start = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(ghosts.Count > 0)
			timer += Time.deltaTime;
		pacTimer += Time.deltaTime;
		if (pacTimer >= 0.1) {
			i++;
			i %= 3;
			pacTimer = 0;
		}
		if (timer >= 1) {
			timer = 0;
			Instantiate (ghosts [Random.Range (0, ghosts.Count)]);
		}
		
	}
}
