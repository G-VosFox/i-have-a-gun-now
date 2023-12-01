using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerMovement : MonoBehaviour
{
    private float currentSpeed;
    public float walkSpeed = 10f;
    public float runSpeed = 15f;
    public float gravity = -0.005f;
    private float baseGravity;
    private bool jumped = false;
    public float hP = 10;


    private float moveX;
    private float moveZ;
    private Vector3 move;

    public CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = walkSpeed;
        baseGravity = gravity;
    }
    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * currentSpeed * Time.deltaTime;
        moveZ = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;
        move = transform.right * moveX +
               transform.up * baseGravity +
               transform.forward * moveZ;
        characterController.Move(move);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runSpeed;
        }
        else
        {
            currentSpeed = walkSpeed;
        }

        if (Input.GetKey(KeyCode.Space) && characterController.isGrounded)
        {
            Debug.Log("jump");
            baseGravity = -gravity;
            jumped = true;
        }
        if (!characterController.isGrounded && jumped == true) 
        {
            StartCoroutine(GetDown());
            jumped = false;
        }
        if (hP == 0)
        {
            Debug.Log("you are dead, not big suprise");
        }
    }
    IEnumerator GetDown()
    {
        yield return new WaitForSeconds(0.4f);
        baseGravity = gravity;
    }
}