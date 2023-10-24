using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys_Radar : MonoBehaviour
{
    [Header("Delete this header")]
    [SerializeField] Transform the_target;


    [Header("Player's head")]
    [SerializeField] Transform targets_head;



    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            the_target = targets_head;            
        }
    }



    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           the_target = null;
        }
    }
    
    

    public Transform _return_player_target()
    {
        return the_target;
    }


}

