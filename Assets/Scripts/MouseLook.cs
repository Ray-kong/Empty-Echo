using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public float moveSpeed = 5f;
    public bool hasKeycard = false;

    private float fullSpeed; 
    private float halfSpeed;

    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        fullSpeed = moveSpeed;
    }

    void LateUpdate()
    {
        RotationsPlusMove();
        //SpeedAlteration();
    }

    //simply input controls. Rotating and Moving
    private void RotationsPlusMove() {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up, mouseX);
        transform.Rotate(-mouseY, 0f, 0f, Space.Self);

        float forwardSpeed = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float strafeSpeed = Input.GetAxis("Horizontal") * moveSpeed * 0.5f* Time.deltaTime;

        transform.Translate(transform.forward * forwardSpeed, Space.World);
        transform.Rotate(0f, 0f, -strafeSpeed * 100f, Space.Self);
    }

    // returns oxygen perecentage we have left

    //will alter the speed of the player based on if 
    private void SpeedAlteration() {

    }



}
    