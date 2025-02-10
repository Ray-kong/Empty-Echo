using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    public float xSpeed = 0.0f;
    public float ySpeed = 0.0f;
    public float zSpeed = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // Rotate the object based on the defined speeds
        transform.Rotate(new Vector3(xSpeed, ySpeed, zSpeed) * Time.deltaTime);
    }
}
