using UnityEngine;

namespace Character.Boss.Last
{
  public class Last_Auto : MonoBehaviour
  {
    [SerializeField]
    private Vector3 distance = Vector3.down * 35.0f;

    private Transform targetTransform;
    private RectTransform rectTransform;

    public void Setup(Transform target)
    {
      targetTransform = target;
      rectTransform = GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
      if (targetTransform == null)
      {
        Destroy(gameObject);
        return;
      }

      //Vector3 screenPosition = Camera.main.WorldToScreenPoint(targetTransform.position);
      //  rectTransform.position = screenPosition + distance;
    }
  }
}
