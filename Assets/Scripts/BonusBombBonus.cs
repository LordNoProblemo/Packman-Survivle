using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBombBonus : MonoBehaviour {

	public List<GameObject> Bonuses;
    private float timer;
	// Use this for initialization
	void Start () {
		int n = Random.Range (1, 6);
		for (int i = 0; i < n; i++) {
			Instantiate (Bonuses [Random.Range (0, Bonuses.Count)]);
		}
        timer = 1.5f;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(timer > 0)
        {
            timer -= Time.deltaTime;
            return;
        }
        GameObject.Destroy(gameObject);
    }
}
