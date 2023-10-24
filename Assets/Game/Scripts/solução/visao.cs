using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visao : MonoBehaviour
{
    [Header("Delete this header")]
    [SerializeField] Transform the_target;


    [Header("Player's head")]
    [SerializeField] Transform targets_head;


     [Header("raycast")]
    [SerializeField] olhar _olhar;


   


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            the_target = targets_head;
            _olhar.enabled = true;            
        }
    }



    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           the_target = null;
            _olhar.enabled = false;            

        }
    }
    
    

    public Transform _return_player_target()
    {
        return the_target;
    }






    
}
