using UnityEngine;

public class LerpAndDelete : MonoBehaviour
{
    public Transform targetPosition;
    public bool lerpToTarget = false;
    public float lerpSpeed = 1f;
    public float deletionDistance = 0.1f;
    public GameObject objectToDelete;

    private void Update()
    {
        if (lerpToTarget)
        {
            Vector3 currentPosition = transform.position;
            Vector3 target = targetPosition.position;

            // Lerp the object's position towards the target position
            transform.position = Vector3.Lerp(currentPosition, target, lerpSpeed * Time.deltaTime);

            // Check if the object is close enough to the target position
            float distance = Vector3.Distance(transform.position, target);
            if (distance <= deletionDistance)
            {
                // Delete the specified object
                Destroy(objectToDelete);
            }
        }
    }
}
