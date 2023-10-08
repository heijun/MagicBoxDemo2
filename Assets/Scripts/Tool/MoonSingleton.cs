using UnityEngine;
using System.Collections;
/// <summary>
/// µ¥ÀýÄ£°åÀà
/// </summary>
public class MoonSingleton<T> : MonoBehaviour where T : MoonSingleton<T>
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject();
                obj.name = typeof(T).Name + "<MoonSingleton>";
                instance = obj.AddComponent<T>();
                DontDestroyOnLoad(obj);
            }

            return instance;
        }
    }

    protected virtual void Awake()
    {
            instance = (T)this;
    }

    public static bool IsInitialized
    {
        get { return instance != null; }

    }

    protected virtual void OnDestroy()
    {
        if (instance == this)
            instance = null;
    }
}
