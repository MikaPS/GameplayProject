using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    private float mouseSen = 6f; 
    public Transform player;
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    void Awake()
    {
      // Ensures the cursor stays on screen
      Cursor.visible = true;
      Cursor.lockState = CursorLockMode.None;
      // Updates mouse sen from the options screen
      if (SaveOptions.optionManager != null) {
        mouseSen = SaveOptions.optionManager.getMouseSen();
      } else {
        mouseSen = 5f;
      }
    }

    void Update() {
        float yOffset = 1.0f; // Move camera up a bit
        transform.position = new Vector3(player.position.x, player.position.y + yOffset, player.position.z);
        // Moves camera based on the mouse movement
        float inputX = Input.GetAxisRaw("Mouse X") * mouseSen;
        float inputY = Input.GetAxisRaw("Mouse Y") * mouseSen;
        rotationY += inputX;
        rotationX -= inputY;
        // Make sure the camera would stay in view of the player
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        // Rotate player on Y axis
        player.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}
