using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler {

	public GameObject animator;
	public bool click = false;
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
	public void OnPointerClick(PointerEventData p)
	{
		if(click)
			animator.SetActive (false);
	}

}
