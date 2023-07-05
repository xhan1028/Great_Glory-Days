using System;
using UnityEngine;

namespace Interact
{
  public class PlayerInteract : MonoBehaviour
  {
    public const float Radius = 3;

    private InteractUI ui;

    private InteractableObject targetObj;
    
    private void Awake()
    {
      ui = FindObjectOfType<InteractUI>();
    }

    private void Update()
    {
      if (targetObj is not null)
      {
        ui.transform.position = UnityEngine.Camera.main.WorldToScreenPoint(targetObj.transform.position);
        if (Input.GetKeyDown(KeyCode.F))
        {
          targetObj.OnInteract();
        }
      }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.gameObject.CompareTag("InteractableObject"))
      {
        targetObj = other.GetComponent<InteractableObject>();
        ui.text = targetObj.description;
        ui.Enable();
      }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
      if (other.gameObject.CompareTag("InteractableObject"))
      {
        ui.Disable();
        targetObj = null;
      }
    }
  }
}