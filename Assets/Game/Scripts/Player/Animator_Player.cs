using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator_Player : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Set_Movement_Animation(float _animation_speed)
    {
        anim.SetFloat("Run_Speed", _animation_speed);

        if(Input.GetKey("space") && _animation_speed > 0f)
        {
            anim.SetBool("is_running", true);
            return;
        }  
        
        anim.SetBool("is_running", false);

    }


    // Used for Is Running and Is Crounched Animations
   public void Set_Animation(string animation_state ,bool _animation_boolean)
   {
        anim.SetBool(animation_state, _animation_boolean);
   }
}
