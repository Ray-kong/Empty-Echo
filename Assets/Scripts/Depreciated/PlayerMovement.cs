using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float detectionRange = 2f; // Inspector-settable detection range
    [SerializeField] private float movementSpeed = 5f; // Inspector-settable movement speed
    [SerializeField] private float fuelExhaust_Percent = 100;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        RotatePlayer();
        MovePlayer();
        CheckObstacles();
        UpdateFuelExhaustPercent();
        LogDebugInfo();

        
    }

    private void RotatePlayer()
    {
        float rotateInput = Input.GetAxis("Horizontal");
        transform.localRotation *= Quaternion.Euler(0f, 0f, -rotateInput * Time.deltaTime * 100f);
    }

    private void MovePlayer()
    {
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = transform.TransformDirection(new Vector3(0f, 0f, verticalInput)) * movementSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

    private void CheckObstacles()
    {
        int obstaclesInRange = 0;
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        foreach (GameObject obstacle in obstacles)
        {
            float distanceToObstacle = Vector3.Distance(transform.position, obstacle.transform.position);

            if (distanceToObstacle <= detectionRange)
            {
                obstaclesInRange++;
            }
        }

        if (obstaclesInRange > 0)
        {
            movementSpeed *= 0.5f;
            fuelExhaust_Percent += 0f;
        }
    }

    private void UpdateFuelExhaustPercent()
    {
        int obstaclesInRange = 0;
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        foreach (GameObject obstacle in obstacles)
        {
            float distanceToObstacle = Vector3.Distance(transform.position, obstacle.transform.position);

            if (distanceToObstacle <= detectionRange)
            {
                obstaclesInRange++;
            }
        }

        float verticalInput = Input.GetAxis("Vertical");

        if (verticalInput != 0f && obstaclesInRange == 0)
        {
            fuelExhaust_Percent -= 0.7f * Time.deltaTime;
        }
    }

    private void LogDebugInfo()
    {
        Debug.Log("fuel: " + fuelExhaust_Percent +"%");
    }
}
