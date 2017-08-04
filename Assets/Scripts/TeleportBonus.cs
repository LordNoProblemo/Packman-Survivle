using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBonus : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float x = 8.5f * Random.value - 8.5f / 2;
		float y = 8.5f * Random.value - 8.5f / 2;
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		player.transform.position = new Vector3 (x, y, -1);
		player.GetComponent<Player> ().dest = new Vector2 (x, y);
		GameObject.Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
