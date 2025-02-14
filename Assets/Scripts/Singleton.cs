using System;

public class Singleton<T> where T : class, new()
{
    public static T Instance
    {
        get
        {
            if (Singleton<T>._instance == null)
            {
                Singleton<T>._instance = Activator.CreateInstance<T>();
            }
            return Singleton<T>._instance;
        }
    }
    protected Singleton()
    {
    }

    private static T _instance;
} 