using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public Rigidbody[] limbRigidbodies; // Array of all the ragdoll limb rigidbodies
    public float lagForce = 10f; // Force applied to lag the limbs
    public float damping = 5f; // Damping factor to control the lag effect

    private Vector3[] initialPositions; // Initial positions of the ragdoll limbs

    private void Start()
    {
        // Store the initial positions of the ragdoll limbs
        initialPositions = new Vector3[limbRigidbodies.Length];
        for (int i = 0; i < limbRigidbodies.Length; i++)
        {
            initialPositions[i] = limbRigidbodies[i].transform.localPosition;
        }
    }

    private void Update()
    {
        for (int i = 0; i < limbRigidbodies.Length; i++)
        {
            // Calculate the desired position based on the initial position and the ragdoll's current position
            Vector3 desiredPosition = transform.TransformPoint(initialPositions[i]);
            
            // Apply a force towards the desired position to lag the limb
            Vector3 force = (desiredPosition - limbRigidbodies[i].transform.position) * lagForce;
            limbRigidbodies[i].AddForce(force);
            
            // Apply damping to slow down the movement of the limb
            limbRigidbodies[i].velocity *= 1f - damping * Time.deltaTime;
        }
    }
}
