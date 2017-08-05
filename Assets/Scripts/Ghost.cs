using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {


	public AbstractManager Manager = null;
	public GameObject Body;
	public GameObject eatMode;
	public Vector3 dir;
	public float speed;
	public ulong step;
	private uint eatPoints=1;
	//public float gModTimer = 0;
	// Use this for initialization
	void Start () {
		
		speed = Random.value * 0.03f + 0.07f;
		GameObject man = GameObject.FindGameObjectWithTag ("Manager");
		if(man != null)
			Manager = man.GetComponent<AbstractManager> ();
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
		p = Random.value;
		float z = 0;
		if (p >= 0.99) {
			transform.localScale = transform.localScale * 5;
			eatPoints = 5;
			z = -0.5f;
		} else if (p >= 0.94) {
			transform.localScale = transform.localScale * 3;
			eatPoints = 3;
			z = -0.4f;
		} else if (p > 0.84) {
			transform.localScale = transform.localScale * 2;
			eatPoints = 2;
			z = -0.3f;
		}
		transform.position = new Vector3 (x, y, z);

	}
	float infNorm()
	{
		Vector2 pos = transform.position;
		return Mathf.Max (Mathf.Abs (pos.x), Mathf.Abs (pos.y));
	}

	// Update is called once per frame
	void FixedUpdate () {
		//GetComponent<Collider2D> ().isTrigger = Manager.ghostMode;
		if (Manager != null) {
			Body.SetActive (!Manager.eat);
			eatMode.SetActive (Manager.eat);
			if (!Manager.canMove () || Manager.ghostFreeze)
				return;
		}
		//GetComponent<Collider2D> ().isTrigger = (Manager.ghostMode && Manager.eat);
		if (infNorm () >= 5.1)
			GameObject.Destroy (gameObject);
		
		/*Vector2 p = Vector2.MoveTowards(transform.position, (Vector2)transform.position+speed*dir, speed);
		GetComponent<Rigidbody2D>().MovePosition(p);*/
		transform.position = transform.position + speed * dir;
		step++;
		
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		
		if (col.gameObject.tag == "Player" && Manager != null && Manager.ghostMode) {
			return;
		}
		if (col.gameObject.tag == "Player") {
			if (Manager != null && Manager.eat) {
				Manager.points += eatPoints;
				GameObject.Destroy (gameObject);
			} else if (Manager != null) {
				Manager.end = true;
			}
		} else if (col.gameObject.tag == "Wall" && step > 10) {
			GameObject.Destroy (gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (Manager != null && Manager.ghostMode && col.gameObject.tag == "Player" && !Manager.eat)
			return;
		if (col.gameObject.tag == "Player") {
			if (Manager != null && Manager.eat) {
				Manager.points += eatPoints;
				GameObject.Destroy (gameObject);
			} else if (Manager != null) {
				Manager.end = true;
			}
		} else if (col.gameObject.tag == "Wall" && step > 10) {
			//Debug.Log ("Nyan");
			GameObject.Destroy (gameObject);
		}
	}
}
