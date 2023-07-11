using UnityEngine;

namespace Pool
{
  public class PoolObject<T> : MonoBehaviour where T : PoolObject<T>
  {
    public event PoolManager<T>.PoolEventListener onGet;
    
    public event PoolManager<T>.PoolEventListener onRelease;
    
    public PoolManager<T> manager { private get; set; }

    public virtual void OnGet() => onGet?.Invoke((T)this);
    
    public virtual void OnRelease() => onRelease?.Invoke((T)this);

    public virtual void OnGetAfter()
    {
      
    }

    public virtual void OnReleaseAfter()
    {
      
    }

    public void Release() => manager.Release((T)this);
  }
}