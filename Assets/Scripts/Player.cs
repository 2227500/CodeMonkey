using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
        
        Debug.Log(inputVector)
 
;    }
}
