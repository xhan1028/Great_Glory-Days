using System;
using UnityEngine;
using UnityEngine.Pool;

namespace Pool
{
  public class PoolManager : MonoBehaviour
  {
    public delegate void PoolEventListener(PoolObject obj);
    
    public event PoolEventListener onGet;
    
    public event PoolEventListener onRelease;
    
    public IObjectPool<PoolObject> pool;

    public PoolObject prefabObj;

    public Transform parent;

    private void Awake()
    {
      pool = new ObjectPool<PoolObject>(CreateFunc, ActionOnGet, ActionOnRelease, ActionOnDestroy);
    }

    protected virtual void ActionOnDestroy(PoolObject obj)
    {
      Destroy(obj.gameObject);
    }

    protected virtual void ActionOnRelease(PoolObject obj)
    {
      obj.OnRelease();
      onRelease?.Invoke(obj);
      obj.gameObject.SetActive(false);
    }

    protected virtual void ActionOnGet(PoolObject obj)
    {
      obj.OnGet();
      onGet?.Invoke(obj);
      obj.gameObject.SetActive(true);
    }

    protected virtual PoolObject CreateFunc()
    {
      var obj = parent is not null ? Instantiate(prefabObj, parent) : Instantiate(prefabObj);
      obj.name = prefabObj.name;
      obj.manager = this;
      
      return obj;
    }

    public PoolObject Get() => pool.Get();

    public void Release(PoolObject obj) => pool.Release(obj);
  }
}