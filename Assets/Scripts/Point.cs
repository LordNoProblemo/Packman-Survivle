using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour {

	public AbstractManager Manager;
	// Use this for initialization
	void Start () {
		Manager = GameObject.FindGameObjectWithTag ("Manager").GetComponent<AbstractManager>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//GetComponent<Collider2D> ().isTrigger = Manager.ghostMode;
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") {
			Manager.points++;

		}
		float x = Random.value * 9 - 4.5f;
		float y = Random.value * 9 - 4.5f;

		transform.position = new Vector3 (x, y, 0);
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") {
			Manager.points++;

		}
		float x = Random.value * 9 - 4.5f;
		float y = Random.value * 9 - 4.5f;

		transform.position = new Vector3 (x, y, 0);
	}
}
