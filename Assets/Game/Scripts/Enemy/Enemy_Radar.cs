using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Radar : MonoBehaviour
{

    [Header("Enemys AI")]
    [SerializeField] Enemy_Controller enemy_controller;
   


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemy_controller.Decide_Behaviour("Player_Entered_Radar");
        }
    }



    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemy_controller.Decide_Behaviour("Player_Exited_Radar");

        }
    }
    


}
