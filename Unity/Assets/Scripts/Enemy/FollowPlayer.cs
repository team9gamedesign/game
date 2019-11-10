using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 3.0f;

    public GameObject player;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(player == null) {
            player = GameObject.FindWithTag("Player"); //TODO: Fix so we don't look for tags
        }
        UpdateMovement();
    }

    void UpdateMovement()
    {
        moveDirection = player.transform.position - transform.position;
        moveDirection.y = 0;
        moveDirection = moveDirection.normalized * speed;

        Vector3 rotationVector = new Vector3(moveDirection.x, 0, moveDirection.z);
        if(rotationVector != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(rotationVector);
        }
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
