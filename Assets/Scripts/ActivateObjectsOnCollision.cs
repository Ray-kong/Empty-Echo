using UnityEngine;

public class ActivateObjectsOnCollision : MonoBehaviour
{
    public GameObject[] objectsToActivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject obj in objectsToActivate)
            {
                obj.SetActive(true);
            }
        }
    }
}
