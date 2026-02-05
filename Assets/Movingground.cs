using UnityEngine;

public class MovingGround : MonoBehaviour
{
    [Header("Movement Settings")]
    public Vector3 moveDirection = new Vector3(5, 0, 0); // Direction and distance
    public float speed = 2f;
    
    private Vector3 startPos;
    private Vector3 endPos;

    void Start()
    {
        startPos = transform.position;
        // Calculate the end point based on your moveDirection
        endPos = startPos + moveDirection;
    }

    void Update()
    {
        // Calculate the "ping-pong" value between 0 and 1
        float time = Mathf.PingPong(Time.time * speed, 1);
        
        // Smoothly move between start and end
        transform.position = Vector3.Lerp(startPos, endPos, time);
    }

    // --- Player Parenting Logic ---

    private void OnTriggerEnter(Collider other)
    {
        // Ensure your Player object is tagged "Player" in the Inspector
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