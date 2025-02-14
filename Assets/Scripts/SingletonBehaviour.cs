using System;
using UnityEngine;

public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance
    {
        get
        {
            if(SingletonBehaviour<T>._instance == null)
            {
                SingletonBehaviour<T>._instance = (UnityEngine.Object.FindObjectOfType(typeof(T)) as T);
            }
            return SingletonBehaviour<T>._instance;
        }
    }

    protected virtual void OnApplicationQuit()
    {
        SingletonBehaviour<T>._isQuit = true;
        base.StopAllCoroutines();
    }

    private static T _instance;
    private static bool _isQuit;
}
