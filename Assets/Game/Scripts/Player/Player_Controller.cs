using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Controller : MonoBehaviour
{
    // Inputs Settings
    Inputs_Player inputs_Player;
    

    [Header("Movement")]
    [SerializeField] Movement_Player movement_Player;


    [Header("Animator")]
    [SerializeField] Animator_Player animator_Player;

    [Header("Stealth")]
    [SerializeField] Stealth_Player stealth_Player;

    void Start()
    {
        inputs_Player = GetComponent<Inputs_Player>();
    }

    void Update()
    {
        transform.position = new Vector3(movement_Player.transform.position.x, 0f, movement_Player.transform.position.z);

        // Movement  
        movement_Player.Move_Player(inputs_Player.Input_Movement());

        movement_Player.Set_Speed(inputs_Player.Input_Running(),stealth_Player.Input_Stealth());
        
        //Animations
        animator_Player.Set_Movement_Animation(movement_Player.Movement_Speed());

        animator_Player.Set_Animation("is_running",inputs_Player.Input_Running());

        animator_Player.Set_Animation("is_stealth",stealth_Player.Input_Stealth());

        
    }
}
