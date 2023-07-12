using System;
using UnityEngine;

namespace UI
{
  public class Skill : MonoBehaviour
  {
    private Animator animator;

    public Action onUse;

    public float coolDown;

    public bool isCooldown;
    
    private void Awake()
    {
      animator = GetComponent<Animator>();
    }

    public void Use()
    {
      if (isCooldown) return;
      onUse?.Invoke();
      animator.SetFloat("cool", 1 / coolDown);
      animator.Play("Cool");
      isCooldown = true;
    }

    private void EndCooltime()
    {
      isCooldown = false;
    }
  }
}
