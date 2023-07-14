using System.Collections;
using System.Collections.Generic;
using Manager;
using UnityEngine;

public class TalkManager : SingleTon<TalkManager>
{
    Dictionary<int, string[]> talkData;

    protected override void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1000, new string[] { "자네는 이순신이 아닌가?", "이번 전쟁 잘 부탁하네.." });
        talkData.Add(1001, new string[] { "장군님의 검날이.. 무뎌지면 안될텐데" });
        talkData.Add(1002, new string[] { "저기 너.. 이예찬이 누군지 알아?" });
        talkData.Add(1003, new string[] { "황하늘 그 녀석..", "밥만 많이 먹는 친구지.." });
        talkData.Add(1004, new string[] { "박준모 ..", "모내기.. 끝말잇기 시작" });
        talkData.Add(1005, new string[] { "요즘 세상이 흉흉하군..", "악의 힘이란게.. 도대체 뭐지?" });
        talkData.Add(1006, new string[] { "이번에 많은 장군들이 출전했다는데..", "괜찮으실까?" });
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
