using UnityEngine;
using System.Collections;



public class CharacterMovement : MonoBehaviour
{
    CharacterController characterController;
    Animator animator;
    Stats stats;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        stats = GetComponent<Stats>();
    }

    void Update()
    {
        if(stats.health > 0)
        {
            UpdateMovement();
        }
    }

    void UpdateMovement()
    {
        //Movement
        stats.gravity = characterController.isGrounded ? 0 : Mathf.Min(stats.gravity + 1, stats.maxGravity);

        if(!stats.bullRush)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), -stats.gravity, Input.GetAxis("Vertical"));
            moveDirection = moveDirection.normalized * stats.speed;

            //Rotation
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitFloor;
            Vector3 playerToMouse = Vector3.zero;

            if (Physics.Raycast(cameraRay, out hitFloor))
            {
                playerToMouse = hitFloor.point - transform.position;
                playerToMouse.y = 0;
                transform.rotation = Quaternion.LookRotation(playerToMouse);
            }

            //Animation
            if (animator != null)
            {
                if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0 || Mathf.Abs(Input.GetAxis("Vertical")) > 0)
                {
                    Vector3 movementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                    float angle = Vector3.SignedAngle(movementInput, playerToMouse, Vector3.up);
                    animator.SetBool("MoveForward", -45 < angle && angle < 45);
                    animator.SetBool("MoveRight", -135 < angle && angle <= -45);
                    animator.SetBool("MoveLeft", 45 <= angle && angle < 135);
                    animator.SetBool("MoveBack", Mathf.Abs(angle) >= 135);
                }
                else
                {
                    animator.SetBool("MoveForward", false);
                    animator.SetBool("MoveRight", false);
                    animator.SetBool("MoveLeft", false);
                    animator.SetBool("MoveBack", false);
                }
            }
        } else
        {
            moveDirection = transform.forward * stats.speed * stats.bullRushSpeedFactor;
            stats.bullRushTimer -= Time.deltaTime;
            if(stats.bullRushTimer <= 0)
            {
                stats.bullRush = false;
            }
        }

        //Apply movement
        characterController.Move(moveDirection * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if(stats.bullRush)
        {
            if(other.CompareTag("Enemy"))
            {
                other.GetComponent<Stats>().ChangeHealth(-stats.bullRushDamage * stats.damageFactor);
            }
        }
    }
}