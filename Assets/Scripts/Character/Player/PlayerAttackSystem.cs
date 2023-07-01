using System;
using Manager;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Character.Player
{
  public class PlayerAttackSystem : SingleTon<PlayerAttackSystem>
  {
    public PlayerAttackController targetAttackController;
    
    protected override void Awake()
    {
      base.Awake();
      ScreenClick.Instance.onPointClick += ScreenClick_OnPointClick;
    }

    private void ScreenClick_OnPointClick(PointerEventData eventdata)
    {
      if (targetAttackController is null) return;
      Debug.Log("Click");
      if (eventdata.button == PointerEventData.InputButton.Left)
      {
        targetAttackController.Attack();
      }
    }
  }
}
