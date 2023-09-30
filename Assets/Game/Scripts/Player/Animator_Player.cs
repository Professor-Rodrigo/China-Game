using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator_Player : MonoBehaviour
{
    public Animator anim;



    public void Set_Movement_Animation(float _speed)
    {
        anim.SetFloat("Speed", _speed);

        if(Input.GetKey("space"))
        {
            anim.SetBool("is_running", true);
            
        }
        else
        {
            anim.SetBool("is_running", false);

        }
    }

}
