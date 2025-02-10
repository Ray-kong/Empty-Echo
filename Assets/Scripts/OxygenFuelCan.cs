
using UnityEngine;

public class OxygenFuelCan : MonoBehaviour
{
    private GameObject player;
    private Oxygen oxygen;
    public float range = 10f;
    private Rigidbody playerRb;
    private Rigidbody oxygenRb;
    public bool moveable = true;
    //public float speed = 5f;
    [SerializeField] private float refuelAmount = 15;
    //private bool canNowMove = false;
    //private bool used = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        oxygenRb = GetComponent<Rigidbody>();
        // Get the MouseLook component from the player object
        oxygen = player.GetComponent<Oxygen>();
        playerRb = player.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Vector3.Distance(playerRb.position, oxygenRb.position) <= range)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                oxygen.IncreaseOxygen(refuelAmount);
                if (moveable) {
                    Destroy(gameObject);
                }

            }
        }
    }
}



/*
 * using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenFuelCan : MonoBehaviour
{
    private GameObject player;
    private Oxygen mouseLook;
    public float range = 10f;
    public float speed = 5f;
    public bool doesRefill = true;

    private float refuelAmount = 15;

    private bool canNowMove = false;

    private bool used = false;

    void Start()
    {
        // Find the player object with the "Player" tag
        player = GameObject.FindGameObjectWithTag("Player");

        // Get the MouseLook component from the player object
        mouseLook = player.GetComponent<Oxygen>();
    }

    void Update()
    {
        moveCan();

        // // Call the ExhaustStatus method from the MouseLook component
        // mouseLook.ExhaustStatus();

        // Check if the player is within range
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= range)
        {
            // Check if the player presses F
            if (Input.GetKeyDown(KeyCode.F))
            {
                canNowMove = true;
                if (doesRefill) {
                    refuel();
                }


                // Destroy the object after it reaches the player
                if (Vector3.Distance(transform.position, player.transform.position) <= 0.1f)
                {
                    Destroy(gameObject);
                }
            }

            // Check if the object is within a range of 1 from the player
            if (distance <= 0.5f)
            {
                Debug.Log("Object is within a range of 1 from the player");
                Destroy(gameObject);
            }
        }
    }

    private void moveCan() {
        if (canNowMove) {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * speed);
        }
    }

    private void refuel() {
        if (!used) {
            if (mouseLook.GetOxygenPercent() + refuelAmount > 100) {
                mouseLook.setOxygen(100);
            } else {
                mouseLook.IncreaseOxygen(refuelAmount);
            }
        }
        used = true;
    }


}
 */