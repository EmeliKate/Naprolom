using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    private Vector3 moveDirection;
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void FixedUpdate()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            moveDirection = transform.forward * speed;
        } else if (Input.GetAxis("Vertical") < 0)
        {
            moveDirection = -transform.forward * speed;
        }
        else
        {
            moveDirection = Vector3.zero;
        }
        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal")*rotationSpeed, 0));
        characterController.SimpleMove(moveDirection);
    }
}