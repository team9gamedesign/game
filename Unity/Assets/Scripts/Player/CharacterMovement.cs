using UnityEngine;
using System.Collections;



public class CharacterMovement : MonoBehaviour
{
    CharacterController characterController;

    Stats stats;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
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
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDirection = moveDirection.normalized * stats.speed;

        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitFloor;

        if(Physics.Raycast(cameraRay, out hitFloor))
        {
            Vector3 playerToMouse = hitFloor.point - transform.position;
            playerToMouse.y = 0;
            transform.rotation = Quaternion.LookRotation(playerToMouse);
        }

        characterController.Move(moveDirection * Time.deltaTime);
    }
}