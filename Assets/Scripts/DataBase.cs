using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase  {

	private class playerStats
    {
        private string name;
        private float time;
        private uint points;
        public playerStats(string n, float t, uint p)
        {
            name = n;
            time = t;
            points = p;
        }
        public string getName()
        {
            return name;
        }
        public uint getPoints()
        {
            return points;
        }
        public float getTime()
        {
            return time;
        }
        public bool better(playerStats p2)
        {
            if (time < p2.time)
                return false;
            return (time > p2.time) || (points >= p2.points);
        }
        private string encode(char c)
        {
            int encInt = 255 - c;
            string ret = "";
            while(encInt > 0)
            {
                ret = (encInt % 2) + ret;
                encInt /= 2;
            }
            while(ret.Length < 8)
            {
                ret = 0 + ret;
            }
            return ret;
        }
        public string encode()
        {
            string toEncode = name + '\t' + time + '\t' + points;
            string ret = "";
            for (int i = 0; i < toEncode.Length; i++)
                ret += encode(toEncode[i]);
            return ret;
        }
        private static char decode(string enCh)
        {
           
            int antiAscii = 0;
            for(int i = 0; i < 8; i++)
            {
                antiAscii += (enCh[i] - '0') * (int)Mathf.Pow(2, 7 - i);
            }
            char ret =(char)( 255 - antiAscii);
            return ret;
        }
        private static string Decode(string code)
        {
            string ret = "";
            int n =code.Length / 8;
            for(int i = 0; i < n;i++)
            {
                ret += decode(code.Substring(8 * i, 8));
            }
            return ret;

        }
        public static playerStats fromCode(string code)
        {
          //  Debug.Log(code.Length);
            if ( code.Length == 0)
                return null;
            string[] data = Decode(code).Split('\t');
            if (data.Length == 0 || data.Length != 3)
                return null;
            return new playerStats(data[0],float.Parse(data[1]),uint.Parse(data[2]));
        }
    }
    private int end;
    private playerStats[] bestest;
    public DataBase()
    {
        end = 0;
        bestest = new playerStats[10];
        for (int i = 0; i < 10; i++)
            bestest[i] = null;
    }
    public void load(string key)
    {
        string data = PlayerPrefs.GetString(key);
        //Debug.Log(data);
        string[] dataRows = data.Split('\n');
        for(int i = 0; i < dataRows.Length; i++)
        {
            bestest[i] = playerStats.fromCode(dataRows[i]);
            if (bestest[i] == null)
                break;
            end++;
        }
    }
    public int addPlayer(string name,float time,uint points)
    {
        playerStats add = new playerStats(name, time, points);
        int i = 0;
        for(; i < end; i++)
        {
            if (add.better(bestest[i]))
                break;
        }
        if(i == end)
        {
            if (end < 10)
            {
                end++;
                bestest[i] = add;
                return i+1;
            }
            return 11;
        }
        if (end < 10)
            end++;
        for(int j = end - 1; j > i; j--)
        {
            bestest[j] = bestest[j - 1];
        }
        bestest[i] = add;
        return i + 1;
    }
    public void save(string key)
    {
        PlayerPrefs.SetString(key, toEncodeString());
        PlayerPrefs.Save();
    }
    private string toEncodeString()
    {
        string ret = "";
        if (bestest[0] == null)
            return ret;
        ret = bestest[0].encode();
        int i = 1;
        while(i < end)
        {
            ret += '\n' + bestest[i].encode();
            i++;
        }
        return ret;
    }

}
