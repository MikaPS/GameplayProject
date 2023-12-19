using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandClockSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToSpawn;
    [SerializeField] private int amountToSpawn;
    public float distance = 10.0f; 

    
     void Update()
    {
        // Updates the distance from spawn manager 
        transform.localScale = new Vector3( distance / 5, 1, distance / 5 );
        
        // Updates based on the amountToSpawn
        for (int n = 0; n < amountToSpawn; n++) {            
            // Generates a random location to spawn in
            Vector3 pos = new Vector3( transform.position.x + Random.Range(-distance, distance), transform.position.y, transform.position.z + Random.Range(-distance, distance));
            // Uses the pool script
            GameObject newObject = PoolingManager.PoolSingleton.GetPooledObject(); 
            if (newObject != null) {
                newObject.transform.position = pos;
                newObject.transform.rotation = this.transform.rotation;
                newObject.SetActive(true);
            }
        }
    }
}
