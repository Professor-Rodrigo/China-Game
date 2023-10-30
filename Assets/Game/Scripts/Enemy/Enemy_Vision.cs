using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Vision : MonoBehaviour
{
    [Header("Origin Ray Points")]
    [SerializeField] Transform player, origin;


    [Header("alert_bar")]
    [SerializeField] GameObject alert_bar;


    [Header("Distance Settings")]
    [SerializeField] float max_distance;
    float distance;


    [Header("Rotation Settings")]
    [SerializeField] float rotation_speed = 2f;
   
    
    [Header("Enemys AI")]
    [SerializeField] Enemy_Controller enemy_controller;
    

    void OnDisable()
    {
        alert_bar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, origin.transform.position);
            
        RaycastHit hit;

        
        if (Physics.Raycast(origin.transform.position, player.transform.position - origin.transform.position, out hit))
        {
            Debug.DrawLine(origin.transform.position, hit.point, Color.red);


            if (hit.collider.CompareTag("Player") && distance < max_distance)
            {
                
                if(!alert_bar.activeSelf)
                {
                    enemy_controller.Decide_Behaviour("Is_Seeing_Player");
                }

                // O jogador está visível
                alert_bar.SetActive(true);
                Look_At_Target();

            }

            else
            {

                if(alert_bar.activeSelf)
                {
                    enemy_controller.Decide_Behaviour("Lose_Sight_Player");
                }

                //Perdeu o jogador da visao
                alert_bar.SetActive(false);

            }
        }
        
       
    }


    public bool Alert_Bar_State()
    {
        return alert_bar.activeSelf;
    }
    



    void Look_At_Target()
    {
        Vector3 _direction_to_object = player.position - transform.position;
        _direction_to_object.y = 0f; // Mantenha apenas a direção horizontal

        // Calcule a rotação desejada usando Quaternion.LookRotation
        Quaternion _target_rotation = Quaternion.LookRotation(_direction_to_object);

        // Interpole suavemente entre a rotação atual e a rotação desejada
        transform.rotation = Quaternion.Slerp(transform.rotation, _target_rotation, Time.deltaTime * rotation_speed);
    }

}
