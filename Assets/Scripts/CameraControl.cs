using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class CameraControl : MonoBehaviour
{
    public float sensX;
    public float sensY;
    public float sensZ;

    public Transform orientation;

    private float xRotation;
    private float yRotation;
    private float zRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


    }

    private void LateUpdate()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        float mouseZ = 0f;

        if (Input.GetKey(KeyCode.Q))
        {
            mouseZ = Time.deltaTime * sensZ;
        }

        if (Input.GetKey(KeyCode.E))
        {
            mouseZ = -Time.deltaTime * sensZ;
        }

        yRotation += mouseX;
        xRotation -= mouseY;
        zRotation += mouseZ;

        //xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, zRotation);
        orientation.rotation = Quaternion.Euler(xRotation, yRotation, zRotation);
    }

}
