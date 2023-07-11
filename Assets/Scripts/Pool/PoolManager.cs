using System;
using UnityEngine;
using UnityEngine.Pool;

namespace Pool
{
  public class PoolManager<T> : MonoBehaviour where T : PoolObject<T>
  {
    public delegate void PoolEventListener(T obj);
    
    public event PoolEventListener onGet;
    
    public event PoolEventListener onRelease;
    
    public IObjectPool<T> pool;

    public T prefabObj;

    public Transform parent;

    private Action<T> onGetAction;

    private void Awake()
    {
      pool = new ObjectPool<T>(CreateFunc, ActionOnGet, ActionOnRelease, ActionOnDestroy);
    }

    protected virtual void ActionOnDestroy(T obj)
    {
      Destroy(obj.gameObject);
    }

    protected virtual void ActionOnRelease(T obj)
    {
      obj.OnRelease();
      onRelease?.Invoke(obj);
      obj.gameObject.SetActive(false);
      obj.OnReleaseAfter();
    }

    protected virtual void ActionOnGet(T obj)
    {
      onGetAction?.Invoke(obj);
      obj.OnGet();
      onGet?.Invoke(obj);
      obj.gameObject.SetActive(true);
      obj.OnGetAfter();
    }

    protected virtual T CreateFunc()
    {
      var obj = parent is not null ? Instantiate(prefabObj, parent) : Instantiate(prefabObj);
      obj.name = prefabObj.name;
      obj.manager = this;
      
      return obj;
    }

    public T Get()=> pool.Get();

    public T Get(Action<T> action = null)
    {
      onGetAction = action;
      return pool.Get();
    }

    public void Release(T obj) => pool.Release(obj);
  }
}