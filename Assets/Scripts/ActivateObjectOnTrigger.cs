using UnityEngine;

public class ActivateObjectOnTrigger : MonoBehaviour
{
    public GameObject objectToActivate; // The object you want to activate

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectToActivate.SetActive(true); // Activate the object
        }
    }
}
