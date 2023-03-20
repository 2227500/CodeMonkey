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
        Vector2 inputVector = playerInput.GetMovementInput();

        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        transform.position = transform.position + moveDir * moveSpeed * Time.deltaTime;

        // isWalking = moveDir != Vector3.zero; 
        if(moveDir != Vector3.zero)
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
 
;    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
