using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIanimation : MonoBehaviour {

	public List<GameObject> ani;


	// Use this for initialization
	void Start () {
		
		for (int j = 0; j < ani.Count; j++)
			ani [j].SetActive (false);
		ani [MenuAnimation.i].SetActive (true);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		for (int j = 0; j < ani.Count; j++) {
			ani [j].SetActive (false);

		}
		ani [MenuAnimation.i].SetActive (true);

	}
}
