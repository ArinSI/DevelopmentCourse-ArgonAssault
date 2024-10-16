using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    //Declare Script References
    private PlayerInputHandler playerInputHandler;
    //Declare Private Bools
    private bool isListeningInput = true;

    // Start is called before the first frame update
    void Start()
    {
        playerInputHandler = FindAnyObjectByType<PlayerInputHandler>();

        if (playerInputHandler == null )
        {
            Debug.Log("PlayerInputHandler Can not be Assigned to InputListener.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isListeningInput)
        {
            ListenMovement();
            ListenAttack();
        }
       
    }

    private void ListenMovement()
    {
        float horizontalInput = 0f;
        float verticalInput = 0f;
        bool isShiftPressed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift); // Check if Shift is pressed

        // A and D control horizontal input for Y/Z-axis rotation
        if (Input.GetKey(KeyCode.A)) horizontalInput = -1f;
        if (Input.GetKey(KeyCode.D)) horizontalInput = 1f;

        // W and S control vertical input for X-axis rotation
        if (Input.GetKey(KeyCode.W)) verticalInput = 1f;
        if (Input.GetKey(KeyCode.S)) verticalInput = -1f;

        // Call the HandleRotation function with the Shift state
        playerInputHandler.HandleRotation(horizontalInput, verticalInput, isShiftPressed);
    }

    private void ListenAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerInputHandler.HandleAttack();
        }
    }
}
