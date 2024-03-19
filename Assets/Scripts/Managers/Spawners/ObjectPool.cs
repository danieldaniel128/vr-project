using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private IPoolable _poolableObject; // Specify the type here
    private Transform _poolParent;//holds the pool
    private int _size = 10;

    public List<IPoolable> AvailableObjectsPool { get; private set; }


    //public Action OnPoolCreated { get; set; }

    private void CreatePool(GameObject parent)
    {
        _poolParent = parent.transform;
        for (int i = 0; i < _size; i++)
        {
            CreateObject();
        }
    }
    private void CreateObject()
    {
        //GameObject poolableGameObject = GameObject.Instantiate((_poolableObject as MonoBehaviour).gameObject, Vector3.zero, Quaternion.identity, _poolParent.transform);  that will work too
        GameObject poolableGameObject = GameObject.Instantiate(_poolableObject.GameObject, Vector3.zero, Quaternion.identity, _poolParent.transform);
        poolableGameObject.SetActive(false);
        IPoolable poolable = poolableGameObject.GetComponent<IPoolable>();
        poolable.Parent = this;
        AvailableObjectsPool.Add(poolable);
    }
    public static ObjectPool CreateInstance(IPoolable poolableObject, int size)//factory
    {
        ObjectPool pool = new ObjectPool(poolableObject, size);
        GameObject poolGameObject = new GameObject(poolableObject + " Pool");
        pool.CreatePool(poolGameObject);
        return pool;
    }
    private void ExtendPool()
    {
        for (int i = 0; i < _size / 2; i++)
        {
            CreateObject();
        }
        _size = AvailableObjectsPool.Count;
    }
    private ObjectPool(IPoolable poolableObject, int size)
    {
        _poolableObject = poolableObject;
        _size = size;
        AvailableObjectsPool = new List<IPoolable>(size);
    }

    public IPoolable GetPooledObject()
    {
        // Find an inactive object in the pool and return it
        for (int i = 0; i < _size; i++)
        {
            if (!AvailableObjectsPool[i].GameObject.activeInHierarchy)
            {
                AvailableObjectsPool[i].GameObject.SetActive(true);
                return AvailableObjectsPool[i];
            }
        }
        // If all objects are in use, you can optionally expand the pool
        ExtendPool();
        return AvailableObjectsPool[_size / 2];
    }
    
    public void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
}
