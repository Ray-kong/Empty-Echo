using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public float rangeThreshold = 3f;
    public KeyCode interactKey = KeyCode.F;
    public LerpingObject[] objectsToTrigger;

    private GameObject player;
    private AudioSource doorSound;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        doorSound = GetComponent<AudioSource>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(interactKey) && IsPlayerInRange())
        {
            TriggerObjectLerp();
        }
    }

    private bool IsPlayerInRange()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        return distance <= rangeThreshold;
    }

    private void TriggerObjectLerp()
    {
        foreach (LerpingObject objLerp in objectsToTrigger)
        {
            objLerp.moveToB = !objLerp.moveToB;
        }
        doorSound.Play();
    }
}
