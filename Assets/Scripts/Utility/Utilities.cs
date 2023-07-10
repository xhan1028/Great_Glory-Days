using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utility
{
  public static class Utilities
  {
    public static void NInvoke<T>(this MonoBehaviour sender, T action, float delay, params object[] parameters)
      where T : MulticastDelegate
    {
      IEnumerator Routine()
      {
        yield return new WaitForSecondsRealtime(delay);
        action.DynamicInvoke(parameters);
      }
      sender.StartCoroutine(Routine());
    }
  }
}