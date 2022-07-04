using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject _objectToSpawn;
    [SerializeField]
    private int _poolSize;
    private int _currentSize;
    private Queue<GameObject> _objectPool;

    private void Awake()
    {
        _objectPool = new Queue<GameObject>();
    }

    public virtual GameObject SpawnObject(GameObject currentObject = null)
    {
        if(currentObject == null)
        {
            currentObject = _objectToSpawn;
        }

        GameObject spawnObject = null;

        if (_currentSize < _poolSize)
        {
            spawnObject = Instantiate(currentObject, transform.position, Quaternion.identity);
            spawnObject.name = currentObject.name + "_" + _currentSize;
            _currentSize++;
        }
        else
        {
            spawnObject = _objectPool.Dequeue();
            spawnObject.transform.position = transform.position;
            spawnObject.transform.rotation = Quaternion.identity;
        }
        _objectPool.Enqueue(spawnObject);
        return spawnObject;
    }
}
