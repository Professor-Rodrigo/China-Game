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

    void Start()
    {
        inputs_Player = GetComponent<Inputs_Player>();
    }

    void Update()
    {
        // Movement  
        movement_Player.Move_Player(inputs_Player.Input_Movement());

        animator_Player.Set_Movement_Animation(movement_Player.Movement_Speed());
    }
}
