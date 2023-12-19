using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClonePrefabs : MonoBehaviour
{
    public GameObject prefabToClone;

    void Start()
    {
        // List positions to spawn the prefabs clones
        List<Vector3> pos = new List<Vector3>();
        pos.Add(new Vector3(7f, 1f, 7f));
        pos.Add(new Vector3(0f, 1f, 2f));
    
        // Adds an extra key on level 2
        if (SceneManager.GetActiveScene().buildIndex >= 2) {
            pos.Add(new Vector3(6.5f, 1f, -4.5f));
        }

        // Instantiate the clones at the right positions with a rotation of 90 (so they could be seen with the current camera angle)
        foreach (Vector3 position in pos)
        {
            Quaternion rotation = Quaternion.Euler(0f, 0f, -90f); 
            Instantiate(prefabToClone, position, rotation);
        }
    }


}
