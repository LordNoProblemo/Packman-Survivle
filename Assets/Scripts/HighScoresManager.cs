using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoresManager : MonoBehaviour {

    public string key;
    private DataBase db;
    public Text scoreBoard;
    public AbstractManager manager;
    public Button openButton;
   
	// Use this for initialization
	void Start () {
        db = new DataBase();
        db.load(key);
       // manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<AbstractManager>();
        scoreBoard.text = "Sorry.\n You didn't make it to the top 10 :(";
        scoreBoard.color = new Color(1, 0, 0);
        scoreBoard.gameObject.SetActive( false);
        openButton.enabled = false;
        openButton.GetComponentInChildren<Text>().color = new Color(1, 0, 0);
    }
	
	
    public void add(InputField name)
    {
        uint points = manager.points;
        float time = manager.timer;
        int score = db.addPlayer(name.text, time, points);
        scoreBoard.gameObject.SetActive(true);
        switch (score)
        {
            case (1):
                scoreBoard.text = "Congrats!\nYou've won 1st place!";
                scoreBoard.color = new Color(0, 1, 0);
                break;
            case (2):
                scoreBoard.text = "Congrats!\nYou've won 2nd place!";
                scoreBoard.color = new Color(0, 1, 0);
                break;
            case (3):
                scoreBoard.text = "Congrats!\nYou've won 3rd place!";
                scoreBoard.color = new Color(0, 1, 0);
                break;
            case (4):
                scoreBoard.text = "Congrats!\nYou've won 4yh place!";
                scoreBoard.color = new Color(0, 1, 0);
                break;
            case (5):
                scoreBoard.text = "Congrats!\nYou've won 5th place!";
                scoreBoard.color = new Color(0, 1, 0);
                break;
            case (6):
                scoreBoard.text = "Congrats!\nYou've won 6th place!";
                scoreBoard.color = new Color(0, 1, 0);
                break;
            case (7):
                scoreBoard.text = "Congrats!\nYou've won 7th place!";
                scoreBoard.color = new Color(0, 1, 0);
                break;
            case (8):
                scoreBoard.text = "Congrats!\nYou've won 8th place!";
                scoreBoard.color = new Color(0, 1, 0);
                break;
            case (9):
                scoreBoard.text = "Congrats!\nYou've won 9th place!";
                scoreBoard.color = new Color(0, 1, 0);
                break;
            case (10):
                scoreBoard.text = "Congrats!\nYou've won 10th place!";
                scoreBoard.color = new Color(0, 1, 0);
                break;

        }
        
        db.save(key);
        gameObject.SetActive(false);
    }

}
