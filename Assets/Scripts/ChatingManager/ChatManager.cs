using Manager;
using TMPro;
using UnityEngine;

namespace ChatingManager
{
  public class ChatManager : SingleTon<ChatManager>
  {
    public TalkManager talkManager;
    public GameObject talkPanel;
    public TextMeshProUGUI talkText;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;
    public Player_Movement movement;

    private string[] talkData;
    private bool isCustomTalk;

    public void Action(GameObject scanObj)
    {
      isCustomTalk = false;
      scanObject = scanObj;
      Npc npc = scanObject.GetComponent<Npc>();
      Talk(npc.id, npc.isNpc);

      talkPanel.SetActive(isAction);

      Time.timeScale = isAction ? 0f : 1f;
    }

    public void Talk(int id, bool isNpc)
    {
      string talkData = talkManager.GetTalk(id, talkIndex);

      if (talkData == null)
      {
        isAction = false;
        talkIndex = 0;
        scanObject = null;
        return;
      }

      if (isNpc)
      {
        talkText.text = talkData;
      }
      else
      {
        talkText.text = talkData;
      }

      isAction = true;
      talkIndex++;
    }

    public void Talk(params string[] data)
    {
      isCustomTalk = true;
      talkIndex = 0;
      talkData = data;

      Talk();
      Time.timeScale = 0f;
    }

    private void Talk()
    {
      talkText.text = talkData[talkIndex];
      talkPanel.SetActive(true);
    }

    private void Update()
    {
      if (isCustomTalk && Input.GetKeyDown(KeyCode.F))
      {
        if (talkIndex == talkData.Length - 1)
        {
          isCustomTalk = false;
          talkIndex = 0;
          Time.timeScale = 1f;
          talkPanel.SetActive(false);
          return;
        }
        talkIndex++;
        Talk();
      }
    }
  }
}
