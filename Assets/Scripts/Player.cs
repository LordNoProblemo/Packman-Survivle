﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float speed = 0.4f;
	Vector2 dest = Vector2.zero;
	public GameManager Manager;

	void Start() {
		dest = transform.position;
	}

	void FixedUpdate() {
		if (!Manager.canMove ())
			return;
		// Move closer to Destination
		Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
		GetComponent<Rigidbody2D>().MovePosition(p);
		//Debug.Log ((Vector2)transform.position);
		// Check for Input if not moving
		//if ((Vector2)transform.position == dest) {
			if (Input.GetKey(KeyCode.UpArrow) )
				dest = (Vector2)transform.position + Vector2.up;
			if (Input.GetKey(KeyCode.RightArrow))
				dest = (Vector2)transform.position + Vector2.right;
			if (Input.GetKey(KeyCode.DownArrow) )
				dest = (Vector2)transform.position - Vector2.up;
			if (Input.GetKey(KeyCode.LeftArrow) )
				dest = (Vector2)transform.position - Vector2.right;
		Vector2 dir = dest - (Vector2)transform.position;
		GetComponent<Animator>().SetFloat("DirX", dir.x);
		GetComponent<Animator> ().SetFloat ("DirY", dir.y);
		//}
	}

	bool valid(Vector2 dir) {
		// Cast Line from 'next to Pac-Man' to 'Pac-Man'
		Vector2 pos = transform.position;
		RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
		return (hit.collider == GetComponent<Collider2D>());
	}
}
