using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 7f;
    public void Update()
    {
        Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = inputVector.y + 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = inputVector.y - 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = inputVector.x - 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = inputVector.x + 1;
        }
        inputVector = inputVector.normalized;

        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        transform.position = transform.position + moveDir * moveSpeed * Time.deltaTime;

        // Making the player rotate in the direction of movement
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
 
;    }
}
