using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBombBonus : MonoBehaviour {

	public List<GameObject> Bonuses;
	// Use this for initialization
	void Start () {
		int n = Random.Range (1, 6);
		for (int i = 0; i < n; i++) {
			Instantiate (Bonuses [Random.Range (0, Bonuses.Count)]);
		}
		GameObject.Destroy (gameObject);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
