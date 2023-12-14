using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerMovement : MonoBehaviour
{
    private float currentSpeed;
    public float walkSpeed = 10f;
    public float runSpeed = 15f;
    public float gravity = -10f;
    private float baseGravity;
    private bool jumped = false;


    private float moveX;
    private float moveZ;
    private Vector3 move;

    public CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = walkSpeed;
        baseGravity = gravity * Time.fixedDeltaTime;
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runSpeed;
        }
        else
        {
            currentSpeed = walkSpeed;
        }

    }
    private void FixedUpdate()
    {
        moveX = Input.GetAxis("Horizontal") * currentSpeed * Time.deltaTime;
        moveZ = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;
        move = transform.right * moveX +
               transform.up * baseGravity +
               transform.forward * moveZ;
        characterController.Move(move);

        if (Input.GetKey(KeyCode.Space) && characterController.isGrounded)
        {
            baseGravity = -gravity * Time.fixedDeltaTime;
            jumped = true;
        }
        if (!characterController.isGrounded && jumped == true)
        {
            StartCoroutine(GetDown());
            jumped = false;
        }
    }
    IEnumerator GetDown()
    {
        yield return new WaitForSeconds(0.2f);
        baseGravity = 4f * Time.fixedDeltaTime;
        yield return new WaitForSeconds(0.05f);
        baseGravity = 1.2f * Time.fixedDeltaTime;
        yield return new WaitForSeconds(0.05f);
        baseGravity = -2.8f * Time.fixedDeltaTime;
        yield return new WaitForSeconds(0.05f);
        baseGravity = gravity * Time.fixedDeltaTime;
    }
}