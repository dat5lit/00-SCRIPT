using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : Singleton<ObjectPooling> 
{
    // Start is called before the first frame update
    Dictionary<GameObject, List<GameObject>> _objectPooling = new Dictionary<GameObject, List<GameObject>>();
   
    public GameObject getObject(GameObject defaultPrefab)
    {
        if (_objectPooling.ContainsKey(defaultPrefab))
        {
            foreach(GameObject o in _objectPooling[defaultPrefab])
            {
                if (!o.gameObject.activeSelf)
                {
                    return o;
                }
            }
            GameObject g = Instantiate(defaultPrefab,this.transform.position,Quaternion.identity,this.transform);
            _objectPooling[defaultPrefab].Add(g);
            g.gameObject.SetActive(false);
            return g;
        }
        List<GameObject> newListObjPool = new List<GameObject>();
        GameObject g2 = Instantiate(defaultPrefab, this.transform.position, Quaternion.identity, this.transform);
        newListObjPool.Add(g2);
        _objectPooling.Add(defaultPrefab,newListObjPool);
        g2.gameObject.SetActive(false);
        return g2;
    }
    /*public GameObject getEnemy()
    {
        foreach (GameObject obj in _enemy)
        {
            if (!obj.gameObject.activeSelf)
            {
                return obj;
            }
        }
        GameObject g = Instantiate(_eMY, this.transform.position, Quaternion.identity, this.transform);
        _enemy.Add(g);
        return g;
    }
    public GameObject getBullet()
    {
        foreach (GameObject obj in _pools)
        {
            if (!obj.gameObject.activeSelf)
            {
                return obj;
            }
        }
        GameObject g = Instantiate(_bullet,this.transform.position, Quaternion.identity,this.transform);
        _pools.Add(g);
        return g;
    }*/
}
