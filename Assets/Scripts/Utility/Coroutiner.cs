using System;
using System.Collections;
using UnityEngine;

namespace Utility
{
  public class Coroutiner
  {
    public MonoBehaviour sender { get; }

    public Func<IEnumerator> routine { get; }

    private Coroutine curCoroutine;

    public Coroutiner(MonoBehaviour sender, Func<IEnumerator> routine)
    {
      this.sender = sender;
      this.routine = routine;
    }

    public void Start()
    {
      Stop();
      curCoroutine = sender.StartCoroutine(routine.Invoke());
    }

    public void Stop()
    {
      if (curCoroutine is not null)
        sender.StopCoroutine(curCoroutine);
    }
  }

  public class Coroutiner<TParam1>
  {
    public delegate IEnumerator RoutineDelegate(TParam1 param1);

    public MonoBehaviour sender { get; }

    public RoutineDelegate routine { get; }

    private Coroutine curCoroutine;

    public Coroutiner(MonoBehaviour sender, RoutineDelegate routine)
    {
      this.sender = sender;
      this.routine = routine;
    }

    public void Start(TParam1 param1)
    {
      Stop();
      curCoroutine = sender.StartCoroutine(routine.Invoke(param1));
    }

    public void Stop()
    {
      if (curCoroutine is not null)
        sender.StopCoroutine(curCoroutine);
    }
  }

  public class Coroutiner<TParam1, TParam2>
  {
    public delegate IEnumerator RoutineDelegate(TParam1 param1, TParam2 param2);

    public MonoBehaviour sender { get; }

    public RoutineDelegate routine { get; }

    private Coroutine curCoroutine;

    public Coroutiner(MonoBehaviour sender, RoutineDelegate routine)
    {
      this.sender = sender;
      this.routine = routine;
    }

    public void Start(TParam1 param1, TParam2 param2)
    {
      Stop();
      curCoroutine = sender.StartCoroutine(routine.Invoke(param1, param2));
    }

    public void Stop()
    {
      if (curCoroutine is not null)
        sender.StopCoroutine(curCoroutine);
    }
  }

  public class Coroutiner<TParam1, TParam2, TParam3>
  {
    public delegate IEnumerator RoutineDelegate(TParam1 param1, TParam2 param2, TParam3 param3);

    public MonoBehaviour sender { get; }

    public RoutineDelegate routine { get; }

    private Coroutine curCoroutine;

    public Coroutiner(MonoBehaviour sender, RoutineDelegate routine)
    {
      this.sender = sender;
      this.routine = routine;
    }

    public void Start(TParam1 param1, TParam2 param2, TParam3 param3)
    {
      Stop();
      curCoroutine = sender.StartCoroutine(routine.Invoke(param1, param2, param3));
    }

    public void Stop()
    {
      if (curCoroutine is not null)
        sender.StopCoroutine(curCoroutine);
    }
  }

  public class Coroutiner<TParam1, TParam2, TParam3, TParam4>
  {
    public delegate IEnumerator RoutineDelegate(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4);

    public MonoBehaviour sender { get; }

    public RoutineDelegate routine { get; }

    private Coroutine curCoroutine;

    public Coroutiner(MonoBehaviour sender, RoutineDelegate routine)
    {
      this.sender = sender;
      this.routine = routine;
    }

    public void Start(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4)
    {
      Stop();
      curCoroutine = sender.StartCoroutine(routine.Invoke(param1, param2, param3, param4));
    }

    public void Stop()
    {
      if (curCoroutine is not null)
        sender.StopCoroutine(curCoroutine);
    }
  }
}
