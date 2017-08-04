using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : MonoBehaviour {
	public GameObject activator;
	//GameManager Manager;
	// Use this for initialization
	void Start () {
		float x = Random.value * 9 - 4.5f;
		float y = Random.value * 9 - 4.5f;
		//Manager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		transform.position = new Vector3 (x, y, 0);
		
	}
	
	// Update is called once per frame
	void Update () {
		//GetComponent<Collider2D> ().isTrigger = Manager.ghostMode;
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject == null || col.gameObject.tag != "Player") {
			float x = Random.value * 9 - 4.5f;
			float y = Random.value * 9 - 4.5f;

			transform.position = new Vector3 (x, y, 0);
		} else {
			Instantiate (activator);
			GameObject.Destroy (gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject == null || col.gameObject.tag != "Player") {
			float x = Random.value * 9 - 4.5f;
			float y = Random.value * 9 - 4.5f;

			transform.position = new Vector3 (x, y, 0);
		} else {
			Instantiate (activator);
			GameObject.Destroy (gameObject);
		}
	}
}
