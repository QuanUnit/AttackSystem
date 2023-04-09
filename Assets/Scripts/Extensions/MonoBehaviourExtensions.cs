using System;
using System.Collections;
using UnityEngine;

public static class MonoBehaviourExtensions
{
    public static Coroutine Delay(this MonoBehaviour mono, float time, Action callback)
    {
        return mono.StartCoroutine(Wait());

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(time);
            callback?.Invoke();
        }
    }
}
