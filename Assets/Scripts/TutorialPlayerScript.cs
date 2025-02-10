using UnityEngine;

public class TutorialPlayerScript : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public float moveSpeed = 5f;

    private float fullSpeed;
    private float halfSpeed;

    public bool canWS;
    public bool canLook;
    public bool canAD;
    public bool canF;

    private float mouseX;
    private float mouseY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        fullSpeed = moveSpeed;
    }

    void FixedUpdate()
    {
        // OutsideSourceEnabler();

        if (canLook)
        {
            HandleMouseInput();
        }

        if (canWS)
        {
            HandleWSInput();
        }

        if (canAD)
        {
            HandleADInput();
        }

        if (canF)
        {
            HandleFInput();
        }
    }

    private void HandleMouseInput()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up, mouseX);
        transform.Rotate(-mouseY, 0f, 0f, Space.Self);
    }

    private void HandleWSInput()
    {
        float forwardSpeed = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(transform.forward * forwardSpeed, Space.World);
    }

    private void HandleADInput()
    {
        float strafeSpeed = Input.GetAxis("Horizontal") * moveSpeed * 0.5f * Time.deltaTime;
        transform.Rotate(0f, 0f, -strafeSpeed * 100f, Space.Self);
    }

    private void HandleFInput()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Perform action for pressing F
        }
    }

    public void OutsideSourceEnabler(string settingToEnable) {
        if (settingToEnable == "canWS") {
            canWS = true;
        } else if (settingToEnable == "canLook") {
            canLook = true;
        } else if (settingToEnable == "canAD") {
            canAD = true;
        } else if (settingToEnable == "canF") {
            canF = true;
        }

    }
}


// using UnityEngine;

// public class TutorialPlayerScript : MonoBehaviour
// {
//     public float mouseSensitivity = 100f;
//     public float moveSpeed = 5f;
    
//     private float fullSpeed; 
//     private float halfSpeed;

//     public bool canWS;
//     public bool canLook;
//     public bool canAD;
//     public bool canF;

    

//     void Start()
//     {
//         Cursor.lockState = CursorLockMode.Locked;
//         fullSpeed = moveSpeed;
//     }

//     void FixedUpdate()
//     {
//         RotationsPlusMove();
//         //SpeedAlteration();
//     }

//     //simply input controls. Rotating and Moving
//     private void RotationsPlusMove() {
//         if (canLook) {
//             float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
//             float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
//         }

//         transform.Rotate(Vector3.up, mouseX);
//         transform.Rotate(-mouseY, 0f, 0f, Space.Self);

//         float forwardSpeed = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
//         float strafeSpeed = Input.GetAxis("Horizontal") * moveSpeed * 0.5f * Time.deltaTime;

//         transform.Translate(transform.forward * forwardSpeed, Space.World);
//         transform.Rotate(0f, 0f, -strafeSpeed * 100f, Space.Self);
//     }

//     // returns oxygen perecentage we have left

//     //will alter the speed of the player based on if 
//     private void SpeedAlteration() {

//     }



// }
    