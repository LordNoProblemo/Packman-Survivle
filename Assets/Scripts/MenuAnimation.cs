using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour {

	public List<GameObject> ghosts;
	private float timer = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= 1) {
			timer = 0;
			Instantiate (ghosts [Random.Range (0, ghosts.Count)]);
		}
		
	}
}
