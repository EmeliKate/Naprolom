using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    private Vector3 moveDirection;
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
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
