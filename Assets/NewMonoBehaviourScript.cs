using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("How far the platform moves from its starting point.")]
    public float movementDistance = 3f;

    [Tooltip("How fast the platform moves back and forth.")]
    public float movementSpeed = 2f;

    [Tooltip("Move on X axis (true) or Z axis (false)?")]
    public bool moveOnXAxis = true;

    [Header("Rotation Settings")]
    [Tooltip("Speed of rotation in degrees per second. Set to 0 to stop spinning.")]
    public float rotationSpeed = 50f;

    // We store the initial position so we can oscillate around it
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // 1. Handle Movement (Sine Wave)
        float offset = Mathf.Sin(Time.time * movementSpeed) * movementDistance;

        if (moveOnXAxis)
        {
            transform.position = new Vector3(startPosition.x + offset, startPosition.y, startPosition.z);
        }
        else
        {
            transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z + offset);
        }

        // 2. Handle Rotation
        // Vector3.up refers to the Y axis (green arrow). 
        // We multiply by Time.deltaTime to ensure smooth rotation regardless of framerate.
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}