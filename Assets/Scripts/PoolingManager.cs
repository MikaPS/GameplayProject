using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    public static PoolingManager PoolSingleton;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    void Awake()
    {
        if (PoolSingleton == null)
            PoolSingleton = this;
        else
            Destroy(PoolSingleton);
    }


    // Start is called before the first frame update
    void Start()
    {
        // Create a list of objects to pool
        pooledObjects = new List<GameObject>();
        GameObject tmpObject;
        for (int n = 0; n < amountToPool; n++) {
            tmpObject = Instantiate(objectToPool);
            tmpObject.SetActive(false);
            pooledObjects.Add(tmpObject);
        }
    }

    // Go through all the objects to pool
    // If the object is disabled, return it so it can be enabled again
    // If no objects are disabled, return null
    public GameObject GetPooledObject() {
        for(int n = 0; n < amountToPool; n++) {
            if (pooledObjects[n] != null) {
                if(!pooledObjects[n].activeInHierarchy) {
                    return pooledObjects[n];
                }
            }
        }
        return null;
    }

}
