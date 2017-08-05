using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float speed = 0.4f;
	public Vector2 dest = Vector2.zero;
	public AbstractManager Manager;
	public GameObject ghostBody;
	bool isDirX = true;
	void Start() {
		dest = transform.position;

	}

	void FixedUpdate() {
		
		if (!Manager.canMove () || Manager.playerFreeze)
			return;
		ghostBody.SetActive (Manager.ghostMode);
		GetComponent<Collider2D> ().isTrigger = Manager.ghostMode;

		Vector3 pos = transform.position;

		Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
		GetComponent<Rigidbody2D>().MovePosition(p);

		if (Input.GetKey (KeyCode.UpArrow)) {
			dest = (Vector2)transform.position + Vector2.up;
			isDirX = false;
			if(!ghostBody.GetComponent<SpriteRenderer> ().flipX)
				ghostBody.transform.eulerAngles = new Vector3 (0, 0, -90);
			else
				ghostBody.transform.eulerAngles = new Vector3 (0, 0, 90);

		
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			dest = (Vector2)transform.position + Vector2.right;
			isDirX = true;
			//ghostBody.transform.rotation.eulerAngles = new Vector3 (0, 0, 0);
			ghostBody.transform.eulerAngles = new Vector3 (0, 0, 0);
			ghostBody.GetComponent<SpriteRenderer> ().flipX  = true;

		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			dest = (Vector2)transform.position - Vector2.up;
			isDirX = false;
			if(!ghostBody.GetComponent<SpriteRenderer> ().flipX)
				ghostBody.transform.eulerAngles = new Vector3 (0, 0, 90);
			else
				ghostBody.transform.eulerAngles = new Vector3 (0, 0, -90);
			//ghostBody.GetComponent<SpriteRenderer> ().flipX  = false;

		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			dest = (Vector2)transform.position - Vector2.right;

			isDirX = true;
			ghostBody.transform.eulerAngles = new Vector3 (0, 0, 0);
			//GetComponentInChildren<SpriteRenderer> ().flipX = false;
			ghostBody.GetComponent<SpriteRenderer> ().flipX = false;
		}
		Vector2 dir = dest - (Vector2)transform.position;
		GetComponent<Animator>().SetFloat("DirX", dir.x);
		GetComponent<Animator> ().SetFloat ("DirY", dir.y);
		//}
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		Vector3 pos = transform.position;
		if (col.gameObject.tag == "Wall" && Manager.ghostMode) {
			if (isDirX) {
				transform.position = new Vector3 (-pos.x, pos.y, -1);
				if (pos.x > 0)
					pos.x -= 0.1f;
				else
					pos.x += 0.1f;
				dest = new Vector3 (-pos.x, pos.y, -1);

			} else {
				transform.position = new Vector3 (pos.x, -pos.y, -1);
				if (pos.y > 0)
					pos.y -= 0.1f;
				else
					pos.y += 0.1f;
				dest = new Vector3 (pos.x, -pos.y, -1);
			}
			

		}
	}

}
