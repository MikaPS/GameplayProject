using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ButtonCode : MonoBehaviour
{
    // References to all walls
    public GameObject wall1;
    public GameObject wall2;

    // References to possible materials
    public Material purpleMat;

    // Start is called before the first frame update
    void Start()
    {
        // Only purple materials in this level
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = purpleMat;

        wall1.GetComponent<MeshRenderer>().enabled = false;
        wall1.GetComponent<Collider>().enabled = false;
        wall2.GetComponent<MeshRenderer>().enabled = false;
        wall2.GetComponent<Collider>().enabled = false;
    }


    // When clicking on a button, change the state of the correct walls
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            wallState(wall1);
            wallState(wall2);
            UpdateInstructions.textManager.updateText("You will win if you can touch the coin without getting caught in the green raycast lights");
        }
    }

    // Make the wall invisible/visible and detect / not detect collisions
    private void wallState(GameObject w) {
        w.GetComponent<MeshRenderer>().enabled = !w.GetComponent<MeshRenderer>().enabled;
        w.GetComponent<Collider>().enabled = !w.GetComponent<Collider>().enabled;
    }
}
