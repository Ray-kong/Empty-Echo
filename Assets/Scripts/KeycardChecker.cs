using UnityEngine;

public class KeycardChecker : MonoBehaviour
{
    public GameObject doorButton;
    private bool keysExist = false;
    private DoorButton doorButtonScript;

    private void Start()
    {
        doorButtonScript = doorButton.GetComponent<DoorButton>();

    }

    private void Update() {
        // CheckAndActivateDoorButton();
        CheckForKeycards();

        if (keysExist) {
            // CheckForKeycards();
            CheckAndActivateDoorButton();
        }


        // doorButtonScript.enabled = true;
    }

    private void CheckAndActivateDoorButton()
    {
        if (doorButtonScript != null)
        {
            doorButtonScript.enabled = keysExist;
        }
    }

    private void CheckForKeycards()
    {
        GameObject[] keycards = GameObject.FindGameObjectsWithTag("Keycard");

        if (keycards.Length <= 0) {
            keysExist = true;
        }
    }
}
