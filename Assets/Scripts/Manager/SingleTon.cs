using System;
using UnityEngine;

namespace Manager
{
  public abstract class SingleTon<T> : MonoBehaviour where T : SingleTon<T>
  {
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
      if (Instance is null) 
        Instance = (T)this;
      else
      {
        Debug.LogError($"SingleTon {typeof(T).Name} is already exist.");
        Destroy(this);
      }
      
      if (this is IDontDestroy)
        DontDestroyOnLoad(gameObject);
    }
  }
}
