using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs_Player : MonoBehaviour
{

   public Vector3 Input_Movement()
   {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movement_player_input = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        return movement_player_input;
   }

   
    
}
