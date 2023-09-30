using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Player : MonoBehaviour
{
    
     public float movementSpeed = 6.0f; // Velocidade de movimento do jogador
    public float rotationSpeed = 3.0f; // Velocidade de rotação do jogador

     public float gravity = 9.8f; // Gravidade
      private Vector3 velocity; // Vetor de velocidade do jogador


    private CharacterController cC;
    private Transform cam;


    [Header("Movement Settings")]
    [SerializeField] private float speed = 6f;
    

        [Header("Gravity Settings")]
        public float yVelocity;
       


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
            velocity.y = -0.5f; // Reseta a velocidade vertical quando o jogador está no chão
        }
        else
        {
            velocity.y -= gravity * Time.deltaTime; // Aplica a gravidade
        }

        // Mover o jogador usando o Character Controller
        cC.Move(moveDirection.normalized * movementSpeed * Time.deltaTime + velocity * Time.deltaTime);


        if(Input.GetKey("space"))
        {
            movementSpeed = 6f;
            
        }
        else
        {
            movementSpeed = 3f;

        }
    }
    

    public float Movement_Speed()
    {

        if (cC.isGrounded)
        {
            float my_speed = cC.velocity.magnitude;

        
            return my_speed;
        }

        return 0f;
       
    }


}
