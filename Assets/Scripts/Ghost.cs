using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

	public bool eat;
	public GameManager Manager;
	public GameObject Body;
	public GameObject eatMode;
	public Vector3 dir;
	public float speed;
	public ulong step;
	// Use this for initialization
	void Start () {
		eat = false;
		speed = Random.value * 0.03f + 0.07f;
		Manager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		eatMode.SetActive (false);
		Body.SetActive (true);
		float p = Random.value;
		float x, y;
		if (p > 0.5) {
			x = Random.Range (0, 2) * 9f - 9f/2;
			y = Random.value * 9f - 9f/2;
			dir = new Vector3(-x, Random.value * 9.5f - 4.75f);
		} else {
			y = Random.Range (0, 2) * 9f - 9f/2;
			x = Random.value * 9f - 9f/2;
			dir = new Vector3 (Random.value * 9.5f - 4.75f,-y );
		}
		transform.position = new Vector3 (x, y, 0);
		dir = dir - (Vector3)transform.position;
		dir.Normalize ();

	}
	float infNorm()
	{
		Vector2 pos = transform.position;
		return Mathf.Max (Mathf.Abs (pos.x), Mathf.Abs (pos.y));
	}
	// Update is called once per frame
	void FixedUpdate () {
		Body.SetActive (!eat);
		eatMode.SetActive (eat);
		if (!Manager.canMove ())
			return;
		if (infNorm () >= 5.1)
			GameObject.Destroy (gameObject);
		
		/*Vector2 p = Vector2.MoveTowards(transform.position, (Vector2)transform.position+speed*dir, speed);
		GetComponent<Rigidbody2D>().MovePosition(p);*/
		transform.position = transform.position + speed * dir;
		step++;
		
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") {
			if (eat) {
				Manager.points += 100;
				GameObject.Destroy (gameObject);
			} else {
				Manager.end = true;
			}
		} else if (col.gameObject.tag == "Wall" && step > 10) {
			GameObject.Destroy (gameObject);
		}
	}

}
