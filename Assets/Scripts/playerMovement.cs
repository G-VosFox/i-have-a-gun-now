using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    private float currentSpeed;
    public float walkSpeed = 10f;
    public float runSpeed = 15f;

    public float gravity = -0.5f;

    private float moveX;
    private float moveZ;
    private Vector3 move;

    public CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * currentSpeed * Time.deltaTime;
        moveZ = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;

        move = transform.right*moveX+ 
               transform.up*gravity+ 
               transform.forward*moveZ;
        characterController.Move(move);

        if (Input.GetKey(KeyCode.LeftShift)){
            currentSpeed = runSpeed;
        }
        else
        {
            currentSpeed = walkSpeed;
        }
    }
}
