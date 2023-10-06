using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Player : MonoBehaviour
{

    private Vector3 velocity; // Vetor de velocidade do jogador

    private CharacterController cC;
    private Transform cam;


    [Header("Rotation Settings")]
    [SerializeField] float rotationSpeed = 3.0f; // Velocidade de rotação do jogador

    [Header("Movement Settings")]
    [SerializeField] float movementSpeed = 6.0f;  


    [Header("Gravity Settings")]
    float yVelocity;
    [SerializeField] float gravity = 9.8f; 


    void Start()
    {
        cC = GetComponent<CharacterController>();
        cam = Camera.main.transform;
    }


    public void Move_Player(Vector3 _received_input)
    {
        Vector3 moveDirection = cam.forward * _received_input.z + cam.right * _received_input.x;
        moveDirection.y = 0f;

        if (moveDirection != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
        }

        // Aplicar gravidade
        if (cC.isGrounded)
        {
            velocity.y = -0.5f;
        }
        else
        {
            velocity.y -= gravity * Time.deltaTime; 
        }

        // Mover o jogador usando o Character Controller
        cC.Move(moveDirection.normalized * movementSpeed * Time.deltaTime + velocity * Time.deltaTime);

    }
    

    public float Movement_Speed()
    {
        float my_speed = cC.velocity.magnitude;

        return my_speed;
    }


    public void Set_Speed(bool _is_running , bool crounched)
    {
        if (_is_running && !crounched)
        {
            movementSpeed = 6.0f;
            return;
        }

        movementSpeed = 3.0f;
    }
}
