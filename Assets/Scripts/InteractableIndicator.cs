using UnityEngine;

public class InteractableIndicator : MonoBehaviour
{
    public float distanceThreshold = 3f; // Distance threshold for activation
    public string playerTag = "Player"; // Tag of the player object
    public string interactableTag = "Interactable"; // Tag of the interactable objects
    public GameObject indicatorImage; // Reference to the UI image object

    private GameObject playerObject; // Reference to the player object

    private void Start()
    {
        // Find the player object based on the tag
        playerObject = GameObject.FindGameObjectWithTag(playerTag);
        
        // Ensure the indicator image is initially inactive
        indicatorImage.SetActive(false);
    }

    private void Update()
    {
        // Check if any interactable object is within the distance threshold
        bool isInteractableNearby = CheckInteractableNearby();
        
        // Set the indicator image active or inactive based on the result
        indicatorImage.SetActive(isInteractableNearby);
    }

    private bool CheckInteractableNearby()
    {
        // Find all objects with the "Interactable" tag
        GameObject[] interactableObjects = GameObject.FindGameObjectsWithTag(interactableTag);
        GameObject[] interactableObjects2 = GameObject.FindGameObjectsWithTag("Keycard");

        // Iterate through each interactable object and check the distance
        foreach (GameObject interactableObject in interactableObjects)
        {
            float distance = Vector3.Distance(interactableObject.transform.position, playerObject.transform.position);
            
            // If the distance is within the threshold, return true
            if (distance <= distanceThreshold)
            {
                return true;
            }
        }
        // Iterate through each interactable object and check the distance
        foreach (GameObject interactableObject in interactableObjects2)
        {
            float distance = Vector3.Distance(interactableObject.transform.position, playerObject.transform.position);

            // If the distance is within the threshold, return true
            if (distance <= distanceThreshold)
            {
                return true;
            }
        }

        // No interactable objects within the distance threshold
        return false;
    }
}
