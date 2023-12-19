using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class Player1Movement : MonoBehaviour {
    // Health bar
    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI healthLabel;
    [SerializeField] private int maxHealth;
    [SerializeField] private float health;
    [SerializeField] private TextMeshProUGUI timeLabel;
    private float decreaseTime = 0f;
    public GameObject Coin;

    // Needed for movement
    private Rigidbody rb;
    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    public float moveSpeed;
    private bool inEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        // Health bar with a max value that changes between hard/easy mode
        if (SaveOptions.optionManager != null) {
            if (SaveOptions.optionManager.getMode()) {
                maxHealth = 7;
            } else {
                maxHealth = 20;
            }
        }
        else {
            maxHealth = 10;
        }
        health = maxHealth;
        if (healthBar == null)
            GameObject.Find("healthBar");
        healthBar.value = health; // set health bar to new value
        healthLabel.text = "HP: " + health.ToString();

    }

    // Get the current movement and updates the time in the scene
    void Update() {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if (!inEnd) {
            timeLabel.text = System.Math.Round(Time.timeSinceLevelLoad-decreaseTime,2) + " sec";
        }
    }
    void FixedUpdate() {
        Vector3 moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        // Move the player using the transform
        transform.Translate(moveDirection.normalized * moveSpeed * Time.fixedDeltaTime);
    }
    
    
    // Changes the health of the player and activates losing condition if needed
    public void changeHealth(float amount) { 
        if (health + amount <= 0) {
            health = 0;
        } else {
            health += amount; 
        } 

        if (health <= 0) {
            healthBar.value = (float)health/maxHealth;
            healthLabel.text = "HP: " + System.Math.Round(health,2).ToString();
            StartCoroutine(EndGame(false));
        } else {

            healthBar.value = (float)health/maxHealth;
            healthLabel.text = "HP: " + System.Math.Round(health,2).ToString();
        }
    }
   

    // If touching the coin, wins game
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin")) // Adjust the condition as needed
        {
            StartCoroutine(EndGame(true));
        }
        if (collision.gameObject.tag == "Clock") {
            collision.gameObject.SetActive(false);
            decreaseTime += 1f;
        }

    }

    // Using a waitforseconds to create an animation effect
    IEnumerator EndGame(bool isWin)
    {
        inEnd = true;
         if (isWin) {
            UpdateInstructions.textManager.isWinning(true);
        } else {
            UpdateInstructions.textManager.isWinning(false);
        }

        Vector3 movement = new Vector3(0.0f, 10f, 0.0f);
        Destroy(Coin);
        rb.drag = 0;

        yield return new WaitForSeconds(1f); 

        // Destroys all enemies and walls in the scene
        GameObject[] enemyToDestroy = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject obj in enemyToDestroy)
        {
            Destroy(obj);
        }

        yield return new WaitForSeconds(1f); 

        GameObject[] wallsToDestroy = GameObject.FindGameObjectsWithTag("Wall");

        foreach (GameObject obj in wallsToDestroy)
        {
            Destroy(obj);
        }

        yield return new WaitForSeconds(1f); 

        GameObject[] clocksToDestroy = GameObject.FindGameObjectsWithTag("Clock");

        foreach (GameObject obj in clocksToDestroy)
        {
            Destroy(obj);
        }

        yield return new WaitForSeconds(1f); 

        GameObject[] keysToDestroy = GameObject.FindGameObjectsWithTag("FirstButton");

        foreach (GameObject obj in keysToDestroy)
        {
            Destroy(obj);
        }
    }

}
