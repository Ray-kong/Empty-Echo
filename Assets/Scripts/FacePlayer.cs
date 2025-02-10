using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    public string playerTag = "Player";
    public float detectionRange = 10f;
    public float movementSpeed = 5f;

    private Transform player;
    private Vector3 naturalPosition;
    private bool isPlayerInRange;

    private void Start()
    {
        // Store the enemy's initial position as the natural position
        naturalPosition = transform.position;

        // Find the player object based on the specified tag
        player = GameObject.FindGameObjectWithTag(playerTag).transform;
    }

    private void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Player object not found!");
            return;
        }

        // Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            // Player is within range, look at the player
            LookAtPlayer();

            // Set the flag to indicate the player is in range
            isPlayerInRange = true;
        }
        else if (isPlayerInRange)
        {
            // Player is out of range, return to the natural position
            ReturnToNaturalPosition();
            isPlayerInRange = false;
        }
    }

    private void LookAtPlayer()
    {
        // Calculate the direction to the player
        Vector3 directionToPlayer = (player.position - transform.position).normalized;

        // Rotate the enemy to face the player
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime);
    }

    private void ReturnToNaturalPosition()
    {
        // Calculate the direction to the natural position
        Vector3 directionToNaturalPosition = (naturalPosition - transform.position).normalized;

        // Move the enemy towards the natural position
        transform.position += directionToNaturalPosition * movementSpeed * Time.deltaTime;
    }
}
