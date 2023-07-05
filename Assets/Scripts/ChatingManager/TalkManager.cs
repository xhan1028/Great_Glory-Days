using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1000, new string[] { "안녕!", "너의 이름은 ?" });
        talkData.Add(2000, new string[] { "Hello", "What your name?" });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if(talkIndex >= talkData[id].Length)
        {
            return null;
        }
        else 
        {
            return talkData[id][talkIndex];
        }
        
    }
}
