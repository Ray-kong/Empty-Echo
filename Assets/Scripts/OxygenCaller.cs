using UnityEngine;

public class OxygenCaller : MonoBehaviour
{
    public GameObject targetObject; // The object to blink when oxygen is below 20
    public float blinkInterval = 0.5f; // The interval at which the object should blink
    public int thresholdToBlink = 90;

    private Oxygen oxygenScript;
    private bool isBlinking = false;

    private void Start()
    {
        // Assuming the Oxygen script is attached to the same GameObject
        oxygenScript = GetComponent<Oxygen>();
    }

    private void Update()
    {
            float oxygenPercent = oxygenScript.GetOxygenPercent();
            Debug.Log("Current Oxygen Percent: " + oxygenPercent);

            if (oxygenPercent < thresholdToBlink)
            {
                if (!isBlinking)
                {
                    StartBlinking();
                }
            }
            else
            {
                if (isBlinking)
                {
                    StopBlinking();
                }
            }
    }

    private void StartBlinking()
    {
        isBlinking = true;
        targetObject.SetActive(true);
        InvokeRepeating("ToggleObjectVisibility", 0f, blinkInterval);
    }

    private void StopBlinking()
    {
        isBlinking = false;
        CancelInvoke("ToggleObjectVisibility");
        targetObject.SetActive(false);
    }

    private void ToggleObjectVisibility()
    {
        targetObject.SetActive(!targetObject.activeSelf);
    }
}
