using System;
using UnityEngine;

namespace Camera
{
  public class HorCamera : MonoBehaviour
  {
    public Transform target;

    public float min;

    public float max;

    private void LateUpdate()
    {
      var targetPos = new Vector3(Mathf.Clamp(target.position.x, min, max), transform.position.y, transform.position.z);
      transform.position = Vector3.Lerp(transform.position,targetPos, Time.deltaTime * 2);
    }
  }
}