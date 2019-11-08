using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    CharacterController characterController;
    Animator myAnimator;

    public float speed = 3.0f;

    public GameObject player;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
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
        
        if(myAnimator != null)
        {
            Vector3 horizontalVelocity = new Vector3(characterController.velocity.x, 0 , characterController.velocity.z);
            myAnimator.SetFloat("Speed", horizontalVelocity.magnitude);
        }
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
