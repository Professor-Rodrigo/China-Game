using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys_Vision : MonoBehaviour
{
    public Enemy_Hologram enemy_Hologram;

    [Header("Seeing Player")]
    [SerializeField] bool saw_player;

    
    [Header("Raycast name collided")]
    [SerializeField] string namehit;


    [Header("Distance between target")]
    //Distance between target and this object 
    [SerializeField] float distanceToTarget;

    [SerializeField] float max_distanceToTarget;


    [Header("Distance between target")]
    //Distance between target and this object 
    [SerializeField] float pos;

    //Raycast Settings
    Vector3 rayDirection;
    RaycastHit hitInfo;

    [Header("alert_bar")]
    public GameObject alert_bar;


    public void Set_Raycast_To_Target(Transform _target_player)
    {
        distanceToTarget = Vector3.Distance(transform.position, _target_player.position);

        if (distanceToTarget != pos)
        {
            pos = distanceToTarget;


            rayDirection = (_target_player.position - transform.position).normalized; 
       

            if (Physics.Raycast(transform.position, rayDirection, out hitInfo))
            {
                Debug.DrawLine(transform.position, hitInfo.point, Color.red);

                namehit = hitInfo.collider.name; 
                

                if (hitInfo.collider.gameObject.CompareTag("Player") && distanceToTarget <= max_distanceToTarget)
                {
                    // O Raycast reached player
                    saw_player = true;
                    alert_bar.SetActive(true);
                    enemy_Hologram.Create_Hologram(_target_player,false, saw_player);
                }

                else
                {
                    enemy_Hologram.Create_Hologram(_target_player,true, saw_player);
                    saw_player = false;
                    alert_bar.SetActive(false);


                }

            }
            
        }

        

    }


    


    public bool is_seeing_player()
    {
        return saw_player;
    }

   
}
