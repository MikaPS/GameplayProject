using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRayCast : MonoBehaviour
{
    private float rotationSpeed = 20;
    private float maxRotation;
    public Player1Movement player;
    public LineRenderer lineRenderer;
    public Material redMaterial;
    public Material greenMaterial;

    void Start() {
        maxRotation = transform.eulerAngles.y+25;
        lineRenderer.materials = new Material[] { greenMaterial };
        lineRenderer.startWidth = 0.5f;
        lineRenderer.endWidth = 0.5f;

    }

    void Update()
    {   
        // Rotate the enemy a little bit so the rays would have more affect and would look cooler on screen 
        if (transform.eulerAngles.y >= maxRotation) {
            transform.Rotate(new Vector3(0, -25, 0));
        } else {
            transform.Rotate(new Vector3(0, rotationSpeed, 0) * Time.deltaTime);
        }
        
        // Cast the raycast and if hits player, sets the color to red and remove some health. Green lines otherwise
        if (Physics.Raycast(transform.position, transform.TransformDirection (Vector3.forward), out RaycastHit hitinfo, 7f)) { 
            if (hitinfo.transform.name == "Player") {
                player.changeHealth(-0.1f);
                lineRenderer.materials = new Material[] { redMaterial };
                lineRenderer.SetPositions(new Vector3[] { this.transform.position, hitinfo.point });


            } else {
                lineRenderer.materials = new Material[] { greenMaterial };
                lineRenderer.SetPositions(new Vector3[] { this.transform.position, hitinfo.point });
            }
        } else {
            lineRenderer.materials = new Material[] { greenMaterial };
            lineRenderer.SetPositions(new Vector3[] { this.transform.position, this.transform.position+this.transform.forward*8 });
        }
    }
}
