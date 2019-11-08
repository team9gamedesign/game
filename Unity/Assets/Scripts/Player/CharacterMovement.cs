using UnityEngine;
using System.Collections;



public class CharacterMovement : MonoBehaviour
{
    CharacterController characterController;
    Animator myAnimator;

    public float speed = 6.0f;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        UpdateMovement();
    }

    void UpdateMovement()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
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