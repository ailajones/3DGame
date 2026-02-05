using UnityEngine;

public class FloatingPlatform : MonoBehaviour
{
    [Header("Gently Bobbing")]
    public float floatAmplitude = 0.2f; // Low value = "Slight" movement
    public float floatFrequency = 0.8f; // Speed of the bob

    [Header("Spinning in Place")]
    public float rotationSpeed = 30f;   // Degrees per second

    private Vector3 startPos;

    void Start()
    {
        // Store the exact spot where you placed it in the editor
        startPos = transform.position;
    }

    void Update()
    {
        // 1. Bob up and down relative to the start position
        // Sine wave goes from -1 to 1, so this stays centered on startPos
        float newY = startPos.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = new Vector3(startPos.x, newY, startPos.z);

        // 2. Spin in place (around its own center)
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    // 3. Parenting logic so the player moves WITH the platform
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}