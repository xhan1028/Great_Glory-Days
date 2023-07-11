using UnityEngine;

namespace Pool
{
  public class PoolObject : MonoBehaviour
  {
    public event PoolManager.PoolEventListener onGet;
    
    public event PoolManager.PoolEventListener onRelease;
    
    public PoolManager manager { private get; set; }

    public virtual void OnGet() => onGet?.Invoke(this);
    
    public virtual void OnRelease() => onRelease?.Invoke(this);

    public void Release() => manager.Release(this);
  }
}