using UnityEngine;

public class ActivateObjectOnPlayerEnter : MonoBehaviour
{
    public GameObject[] objectsToActivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject obj in objectsToActivate)
            {
                FacePlayer script = obj.GetComponent<FacePlayer>();
                if (script != null)
                {
                    script.enabled = true;
                }
            }
        }
    }
}
