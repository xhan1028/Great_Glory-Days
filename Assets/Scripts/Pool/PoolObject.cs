using System;
using UnityEngine;

namespace Pool
{
  public class PoolObject<T> : MonoBehaviour where T : PoolObject<T>
  {
    public event PoolManager<T>.PoolEventListener onGet;

    public event PoolManager<T>.PoolEventListener onRelease;

    public PoolManager<T> manager { private get; set; }

    public float despawnTime;

    private float curTime;

    public virtual void OnGet() => onGet?.Invoke((T) this);

    public virtual void OnRelease() => onRelease?.Invoke((T) this);

    public virtual void OnGetAfter()
    {
      curTime = 0;
    }

    public virtual void OnReleaseAfter()
    {
    }

    public void Release() => manager.Release((T) this);

    private void Update()
    {
      if (despawnTime == 0) return;
      
      if (curTime >= despawnTime)
        Release();
      else
        curTime += Time.deltaTime;
    }
  }
}
