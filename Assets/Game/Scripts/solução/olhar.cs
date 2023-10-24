using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class olhar : MonoBehaviour
{
    public Transform player, origin;

     [Header("alert_bar")]
    public GameObject alert_bar;

    public float distance, max_distance;

    [Header("enemy")]
    public Transform model;

    [Header("Rotation Settings")]
    [SerializeField] float rotation_speed = 2f;
   

    [Header("patrol")]
    public Patrol_Behaviour patrol_Behaviour;


        public Enemy_Hologram enemy_Hologram;


    void OnDisable()
    {
        alert_bar.SetActive(false);

        patrol_Behaviour.enabled = true;
    }

    public void Look_At_Target()
    {
          Vector3 _direction_to_object = player.position - model.position;
            _direction_to_object.y = 0f; // Mantenha apenas a direção horizontal

            // Calcule a rotação desejada usando Quaternion.LookRotation
            Quaternion _target_rotation = Quaternion.LookRotation(_direction_to_object);

            // Interpole suavemente entre a rotação atual e a rotação desejada
            model.rotation = Quaternion.Slerp(model.rotation, _target_rotation, Time.deltaTime * rotation_speed);
            

    }


    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, origin.transform.position);
            
        RaycastHit hit;

        
        if (Physics.Raycast(origin.transform.position, player.transform.position - origin.transform.position, out hit))
        {
            Debug.DrawLine(origin.transform.position, hit.point, Color.red);


            if (hit.collider.CompareTag("Player") )
            {
                // O jogador está visível
                // Aqui você pode fazer com que o inimigo olhe na direção do jogador.
                print("bateu");
                alert_bar.SetActive(true);
                    

                Look_At_Target();
                patrol_Behaviour.enabled = false;

                 enemy_Hologram.Create_Hologram(player.transform, false, false);


            }
            else
            {
                alert_bar.SetActive(false);

                enemy_Hologram.Create_Hologram(player.transform, true, patrol_Behaviour.enabled);

                patrol_Behaviour.enabled = true;


            }
        }
        

       
    }








  


}
