using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset;   // Offset position of the camera from the player
    public float mouseSensitivity = 2f; // Sensitivity for mouse movement
    public float pitchLimit = 85f; // Limit for camera pitch rotation

    private float yaw; // Y-axis rotation
    private float pitch; // X-axis rotation

    void Start()
    {
        // Initialize camera rotation
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Get mouse input for rotation
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, -pitchLimit, pitchLimit); // Clamp pitch rotation

        // Update camera rotation
        transform.eulerAngles = new Vector3(pitch, yaw, 0f);

        // Update camera position
        transform.position = player.position + offset;
    }
}