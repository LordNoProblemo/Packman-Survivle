using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler {

	public GameObject animator;
	// Use this for initialization
	void Start () {
		animator.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnPointerEnter(PointerEventData p)
	{
		animator.SetActive (true);
	}
	public void OnPointerExit(PointerEventData p)
	{
		animator.SetActive (false);
	}

}
