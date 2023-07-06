using System;
using UnityEngine;

namespace Interact
{
  [RequireComponent(typeof(CircleCollider2D))]
  public abstract class InteractableObject : MonoBehaviour
  {
    private CircleCollider2D _collider2D;

    public string description;

    private void Awake()
    {
      
    }

    public abstract void OnInteract();
  }
}