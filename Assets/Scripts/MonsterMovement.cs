using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public float patrolSpeed = 5f;
    public float chaseSpeed = 10f;
    public float runSpeed = 15f;
    public float chaseThreshold = 10f;
    public float runThreshold = 3f;

    private GameObject player;
    private Transform currentDestination;
    private MonsterState currentState;

    private enum MonsterState
    {
        Patrol,
        Chase,
        Run
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ChangeState(MonsterState.Patrol);
    }

    private void Update()
    {
        switch (currentState)
        {
            case MonsterState.Patrol:
                Patrol();
                break;
            case MonsterState.Chase:
                Chase();
                break;
            case MonsterState.Run:
                Run();
                break;
        }
    }

    private void Patrol()
    {
        if (currentDestination == null)
        {
            FindNewDestination();
        }

        Vector3 direction = currentDestination.position - transform.position;
        transform.Translate(direction.normalized * patrolSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentDestination.position) < 0.2f)
        {
            FindNewDestination();
        }

        // Check if the player is within chase range
        if (Vector3.Distance(transform.position, player.transform.position) <= chaseThreshold)
        {
            ChangeState(MonsterState.Chase);
        }
    }

    private void Chase()
    {
        // Find all MonsterDestinations
        GameObject[] destinations = GameObject.FindGameObjectsWithTag("MonsterDestination");

        float closestDistance = Mathf.Infinity;
        Transform closestDestination = null;

        foreach (GameObject destination in destinations)
        {
            Vector3 direction = destination.transform.position - player.transform.position;
            float distance = direction.magnitude;

            if (distance < closestDistance && Vector3.Dot(player.transform.forward, direction.normalized) < 0)
            {
                closestDistance = distance;
                closestDestination = destination.transform;
            }
        }

        if (closestDestination != null)
        {
            Vector3 direction = closestDestination.position - transform.position;
            transform.Translate(direction.normalized * chaseSpeed * Time.deltaTime);
        }

        // Check if the player is within run range and looking away
        if (Vector3.Distance(transform.position, player.transform.position) <= runThreshold &&
            Vector3.Dot(player.transform.forward, (transform.position - player.transform.position).normalized) > 0.5f)
        {
            ChangeState(MonsterState.Run);
        }

        // Check if the player is out of chase range
        if (Vector3.Distance(transform.position, player.transform.position) > chaseThreshold)
        {
            ChangeState(MonsterState.Patrol);
        }
    }

    private void Run()
    {
        // Find all MonsterDestinations
        GameObject[] destinations = GameObject.FindGameObjectsWithTag("MonsterDestination");

        float farthestDistance = 0f;
        Transform farthestDestination = null;

        foreach (GameObject destination in destinations)
        {
            Vector3 direction = destination.transform.position - player.transform.position;
            float distance = direction.magnitude;

            if (distance > farthestDistance && Vector3.Dot(player.transform.forward, direction.normalized) > 0.9f)
            {
                farthestDistance = distance;
                farthestDestination = destination.transform;
            }
        }

        if (farthestDestination != null)
        {
            Vector3 direction = farthestDestination.position - transform.position;
            transform.Translate(direction.normalized * runSpeed * Time.deltaTime);
        }

        // Check if the player is within chase range
        if (Vector3.Distance(transform.position, player.transform.position) <= chaseThreshold)
        {
            ChangeState(MonsterState.Chase);
        }
    }

    private void FindNewDestination()
    {
        GameObject[] destinations = GameObject.FindGameObjectsWithTag("MonsterDestination");

        if (destinations.Length > 0)
        {
            int randomIndex = Random.Range(0, destinations.Length);
            currentDestination = destinations[randomIndex].transform;
        }
    }

    private void ChangeState(MonsterState newState)
    {
        currentState = newState;
    }
}
