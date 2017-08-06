using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.fullScreen = true;
	}
	public bool ret = false;
	// Update is called once per frame
	void Update () {
		if (ret && Input.GetKey (KeyCode.Escape))
			SceneManager.LoadScene ("MainMenu");
		
	}
	public void Exit()
	{
		Application.Quit ();
	}
	public void LoadScene(string SceneName)
	{
		SceneManager.LoadScene (SceneName);
	}
	public void OpenAndCloseDialog(GameObject dial)
	{
		dial.SetActive (!dial.activeSelf);
	}
}
