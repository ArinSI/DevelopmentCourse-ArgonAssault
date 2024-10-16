using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Set Up Variables
    public float PlayerVelocity = 0f;
    public Vector3 direction = Vector3.forward;
    public float SpeedFrequency;
    public float rotationSpeed;
    public float shiftRotationSpeed;
    // Set Up Player Components
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.Log("Rigidbody Can not be located.");
        }

        //Initialise Coroutines
        StartCoroutine(MoveRoutine());
    }

    private IEnumerator MoveRoutine()
    {
        while (true)
        {
            transform.Translate(direction * PlayerVelocity * Time.deltaTime, Space.Self);
            yield return new WaitForSeconds(SpeedFrequency);
        }
    }

    public void HandleRotation(float horizontalInput, float verticalInput, bool isShiftPressed)
    {
        // Check if Shift key is pressed
        if (isShiftPressed)
        {
            // Rotate on Z axis based on A/D input (horizontal) when Shift is pressed
            if (horizontalInput != 0)
            {
                float zRotation = -horizontalInput * shiftRotationSpeed * Time.deltaTime;
                transform.Rotate(0, 0, zRotation, Space.Self); // Rotate around Z-axis locally
            }
        }
        else
        {
            // Rotate on Y axis based on A/D input (horizontal)
            if (horizontalInput != 0)
            {
                float yRotation = horizontalInput * rotationSpeed * Time.deltaTime;
                transform.Rotate(0, yRotation, 0, Space.Self); // Rotate around Y-axis locally
            }
        }

        // Rotate on X axis based on W/S input (vertical)
        if (verticalInput != 0)
        {
            float xRotation = verticalInput * rotationSpeed * Time.deltaTime;
            transform.Rotate(xRotation, 0, 0, Space.Self); // Rotate around X-axis locally
        }
    }
}
