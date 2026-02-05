using UnityEngine;

public class MushroomMagic : MonoBehaviour
{
    [Header("Gently Bobbing")]
    public float floatAmplitude = 0.3f; 
    public float floatFrequency = 1.2f;

    [Header("Spinning in Place")]
    public float rotationSpeed = 40f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // 1. Spin in place
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self);

        // 2. Bob up and down
        float newY = startPos.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }

    // 3. Keep the player on top
    private void OnTriggerEnter(Collider other)
    {
        // Make sure your player object has the "Player" tag in the Inspector
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Set parent to null so the player moves independently again
            other.transform.SetParent(null);
        }
    }
}