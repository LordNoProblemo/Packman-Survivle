using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreBoard : MonoBehaviour {

    public string key;
    private DataBase db;
    public List<Text> Names, Times, Scores;
   
	// Use this for initialization
	void Start () {
        db = new DataBase();
        db.load(key);
        print();
        
    }
    string timer(float time)
    {
        uint inTime = (uint)time;
        uint mili = inTime % 100;
        inTime /= 100;
        uint sec = inTime % 60;
        inTime /= 60;
        string ret = "" + mili;
        if (ret.Length < 2)
            ret = 0 + ret;
        ret = sec+":" + ret;
        if (ret.Length < 5)
            ret = 0 + ret;
        ret = inTime + ":" + ret;
        if (ret.Length < 8)
            ret = 0 + ret;
        return ret;

    }
    void print()
    {
        DataBase.playerStats pl = null;
        for(int i =0; i < 10; i++)
        {
            pl = db.get(i);
            Names[i].text = (i+1) + ") ";
            if(pl != null)
            {
                Names[i].text += pl.getName();
                Times[i].text = timer(pl.getTime());
                Scores[i].text = "" + pl.getPoints();
            }
            else
            {
                Names[i].text += "-----";
                Times[i].text = "-----";
                Scores[i].text = "-----";
            }

        }

    }
	
	public void delete(InputField i)
    {
        db.RemovePlayer(int.Parse(i.text)-1);
        db.save(key);
        print();
    }
    public void deleteAll()
    {
        while (db.RemovePlayer(0)) ;
        
        print();
        db.save(key);
    }
}
