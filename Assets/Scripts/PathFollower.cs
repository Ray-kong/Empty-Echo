using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public Transform[] waypoints; // Array of waypoints defining the path
    public float speed = 5f; // Speed at which the object moves along the path

    private int currentWaypointIndex = 0; // Index of the current waypoint
    private bool isMoving = true; // Flag to track if the object is currently moving

    private void Update()
    {
        if (isMoving)
        {
            // Check if there are waypoints defined
            if (waypoints.Length == 0)
            {
                Debug.LogWarning("No waypoints defined for the path!");
                return;
            }

            // Get the current waypoint
            Transform currentWaypoint = waypoints[currentWaypointIndex];

            // Calculate the distance to the current waypoint
            float distanceToWaypoint = Vector3.Distance(transform.position, currentWaypoint.position);

            // Move towards the current waypoint
            transform.position = Vector3.Lerp(transform.position, currentWaypoint.position, speed * Time.deltaTime / distanceToWaypoint);

            // Check if the object has reached the current waypoint
            if (distanceToWaypoint <= 0.1f)
            {
                // Move to the next waypoint
                currentWaypointIndex++;

                // Check if we've reached the end of the path
                if (currentWaypointIndex >= waypoints.Length)
                {
                    // Stop moving
                    isMoving = false;
                    return;
                }
            }
        }
    }

    public void StartMoving()
    {
        // Reset the current waypoint index and start moving
        currentWaypointIndex = 0;
        isMoving = true;
    }

    public void StopMoving()
    {
        // Stop moving
        isMoving = false;
    }
}
