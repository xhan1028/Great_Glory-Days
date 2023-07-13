using System;
using TMPro;
using UnityEngine;

namespace UI
{
  public class Count : MonoBehaviour
  {
    private TextMeshProUGUI textMeshProUGUI;

    private Animator animator;
    
    private int curCount;
    
    private Action callback;

    public bool isCounting;

    public float time;

    private const float Max = 1.25f;

    public float maxTime;

    private void Awake()
    {
      textMeshProUGUI = GetComponent<TextMeshProUGUI>();
      animator = GetComponent<Animator>();
    }

    public void StartCounting(int count, Action callBack)
    {
      Set(count - 1);
      time = 0;
      callback = callBack;
      maxTime = count * Max;
      isCounting = true;
    }

    private void Update()
    {
      if (isCounting)
      {
        time += Time.deltaTime;
      }
    }

    private void Set(int count)
    {
      curCount = count;
      textMeshProUGUI.text = (curCount + 1).ToString();
      animator.Play("Count");
    }

    private void NextCount()
    {
      if (curCount == 0)
      {
        callback.Invoke();
        isCounting = false;
      }
      else
      {
        Set(curCount - 1);
      }
    }
  }
}
