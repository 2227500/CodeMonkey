using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions(); //construct on awake
        playerInputActions.Player.Enable(); //enable the action map "Player"
    }

    public Vector2 GetMovementInputNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();


        inputVector = inputVector.normalized;

        return inputVector;
    }
}
