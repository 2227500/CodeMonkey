using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private PlayerInput playerInput;

    private bool isWalking;
    public void Update()
    {
        HandleMovement();
        HandleInteraction();
;   }


    public void HandleInteraction()
    {
        Vector2 inputVector = playerInput.GetMovementInputNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        float interactDistance = 2f;

        if (Physics.Raycast(transform.position, moveDir, out RaycastHit raycastHit, interactDistance))
        {
            Debug.Log(raycastHit.transform);
        }
        else
        {
            Debug.Log("-");
        }
    }

    public void HandleMovement()
    {
        Vector2 inputVector = playerInput.GetMovementInputNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);



        float maxDistance = moveSpeed * Time.deltaTime;
        float playerHeight = 2f;
        float playerRadius = .7f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, maxDistance);


        if (!canMove)
        {
            // attempt movement on the X axis
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, maxDistance);
            if (canMove)
            {
                moveDir = moveDirX;
            }
            else
            {
                // Attempt movement on the Z axis
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.y).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, maxDistance);
                if (canMove)
                {
                    moveDir = moveDirZ;
                }
            }
        }




        if (canMove)
        {
            transform.position = transform.position + moveDir * maxDistance;
        }

        //Debug.Log(moveDir);
        //isWalking = moveDir != Vector3.zero; 
        if (moveDir != Vector3.zero)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        } // is walking is set to true if the player is moving

        // Making the player rotate in the direction of movement
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
