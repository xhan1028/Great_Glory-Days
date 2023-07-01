using System;
using UnityEngine;

namespace Character.Player
{
  [Serializable]
  public struct AttackData
  {
    public BoxCollider2D hitBoxCollider;

    public string animationParameter;

    public float endTime;

    public float cooldownTime;

    public float attackDelay;
  }
}
