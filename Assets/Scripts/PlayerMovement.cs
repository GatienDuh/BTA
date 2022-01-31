using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;

    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jumpSpeed = 8.0f;
    [SerializeField] private float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    //#Movement

    private void Update()
    {
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 temp = transform.rotation.eulerAngles;
            temp.y = 0f;
            transform.rotation = Quaternion.Euler(temp);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 temp = transform.rotation.eulerAngles;
            temp.y = 180f;
            transform.rotation = Quaternion.Euler(temp);
        }
    }

    private void FixedUpdate()
    {
        if (GetComponent<PlayerCombat>().isAttacking == false)
        {
            characterController.Move(moveDirection * Time.deltaTime);
        }
    }
}
