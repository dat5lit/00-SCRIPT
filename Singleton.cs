using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T>:MonoBehaviour where T: MonoBehaviour
{
    public static T instance => _instance;
    private static T _instance;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this.GetComponent<T>();
            return;
        }
        if (_instance.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
        {
            Destroy(this.gameObject);
        }
    }


}
