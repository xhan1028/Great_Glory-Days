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
        talkData.Add(1000, new string[] { "�ڳ״� �̼����� �ƴѰ�?", "�̹� ���� �� ��Ź�ϳ�.." });
        talkData.Add(1001, new string[] { "�屺���� �˳���.. �������� �ȵ��ٵ�" });
        talkData.Add(1002, new string[] { "���� ��.. �̿����� ������ �˾�?" });
        talkData.Add(1003, new string[] { "Ȳ�ϴ� �� �༮..", "�丸 ���� �Դ� ģ����.." });
        talkData.Add(1004, new string[] { "���ظ� ..", "�𳻱�.. �����ձ� ����" });
        talkData.Add(1005, new string[] { "���� ������ �����ϱ�..", "���� ���̶���.. ����ü ����?" });
        talkData.Add(1006, new string[] { "�̹��� ���� �屺���� �����ߴٴµ�..", "�������Ǳ�?" });
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
