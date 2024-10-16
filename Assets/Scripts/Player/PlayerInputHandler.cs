using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    // Set Up Script References
    private PlayerMovement playerMovement;
    private PlayerAttack playerAttack;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>();

        if (playerMovement == null)
        {
            Debug.Log("PlayerMovement Script Can not be Assigned to PlayerInputHandler");
        }

        playerAttack = FindAnyObjectByType<PlayerAttack>();

        if (playerAttack == null)
        {
            Debug.Log("PlayerInputHandler Can not Locate PlayerAttack Script.");
        }
    }

    public void HandleRotation(float horizontalInput, float verticalInput, bool isShiftPressed)
    {
        playerMovement.HandleRotation( horizontalInput, verticalInput, isShiftPressed);
    }

    public void HandleAttack()
    {
        playerAttack.Attack();
    }

    
}
