using UnityEngine;

public class ObjectSwitcher : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;

    private float minDelay = 0.5f;
    private float maxDelay = 0.8f;

    private GameObject currentObject;
    private float nextSwitchTime;

    private void Start()
    {
        // Set initial active object
        object1.SetActive(true);
        currentObject = object1;

        // Calculate next switch time
        nextSwitchTime = Time.time + Random.Range(minDelay, maxDelay);
    }

    private void Update()
    {
        // Check if it's time to switch objects
        if (Time.time >= nextSwitchTime)
        {
            // Disable the current object
            currentObject.SetActive(false);

            // Select the next object
            if (currentObject == object1)
            {
                currentObject = object2;
            }
            else if (currentObject == object2)
            {
                currentObject = object3;
            }
            else if (currentObject == object3)
            {
                currentObject = object1;
            }

            // Enable the newly selected object
            currentObject.SetActive(true);

            // Calculate next switch time
            nextSwitchTime = Time.time + Random.Range(minDelay, maxDelay);
        }
    }
}
