using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ButtonCode2 : MonoBehaviour
{
    // References to all walls
    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;
    public GameObject wall4;
    public GameObject wall5;
    // Creates an array so we can easily manipulate all walls
    private GameObject[] walls;
    public int color; // purple = 0, green = 1
    // References to possible materials
    public Material purpleMat;
    public Material greenMat;
    // private isWallOn = true;
    // Start is called before the first frame update
    void Start()
    {
        walls = new GameObject[] { wall1, wall2, wall3, wall4, wall5 };
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        // The first button always has to be purple to pass the level
        if (name == "Button") {            
            color = 0;
            meshRenderer.material = purpleMat;
        // For the rest of the buttons, randomly choose a color and set the appropriate material
        } else {
            color = Random.Range(0, 2);
            if (color == 0) {
                meshRenderer.material = purpleMat;
            } else {
                meshRenderer.material = greenMat;
            }
        }
       
        // Set some walls on and some off to make the game more interesting
        for (int i = 0; i < walls.Length; i++)
        {
            GameObject wall = walls[i];           
            if (i == 0 || i == 2 || i == 3) {
                wall.GetComponent<MeshRenderer>().enabled = false;
                wall.GetComponent<Collider>().enabled = false;
                wall.GetComponent<NavMeshObstacle>().enabled = false;
            } if (i == 1 || i == 4) {
                wall.GetComponent<MeshRenderer>().enabled = true;
                wall.GetComponent<Collider>().enabled = true;
                wall.GetComponent<NavMeshObstacle>().enabled = true;
            }
        }
    }


    // When clicking on a button, change the state of the correct walls
    private void OnTriggerEnter(Collider other)
    {
        // Change purple walls
        if (color == 0) {
            wallState(wall1);
            wallState(wall2);
            wallState(wall3);
        // Change green walls
        } else {
            wallState(wall4);
            wallState(wall5);
        }
    }

    // Make the wall invisible/visible and detect / not detect collisions
    private void wallState(GameObject w) {
        w.GetComponent<MeshRenderer>().enabled = !w.GetComponent<MeshRenderer>().enabled;
        w.GetComponent<Collider>().enabled = !w.GetComponent<Collider>().enabled;
        w.GetComponent<NavMeshObstacle>().enabled = !w.GetComponent<NavMeshObstacle>().enabled; 
    }
}
