using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
   [Header("Delete this header")]
   [SerializeField] Transform the_target;


 
   [Header("Behaviour References")]

   [SerializeField]  Enemy_Vision vision_system;

   [SerializeField]  Patrol_Behaviour patrol_system;

   [SerializeField]  Patrol_Points patrol_point;


   [SerializeField]  Enemy_Hologram holograms_system;





   void Start()
   {
      Decide_Behaviour("Patrol_to_Actual_Point");
   }



    public void Decide_Behaviour(string _IA_case)
    {
        switch (_IA_case)
        {
            //Initial PATTROLING
            case "Patrol_to_Actual_Point":

               print("começou a patrulhar");
               patrol_system.Set_Patrol_Point_To_Go(patrol_point.Return_Next_Path_Point(0));
               patrol_system.Start_Patroling();
                
               break;

            //Next PATTROLING
            case "Patrol_to_Next_Point":

               print("patrulhando para proximo ponto");
               patrol_system.Set_Patrol_Point_To_Go(patrol_point.Return_Next_Path_Point(1));
               patrol_system.Start_Patroling();
               
               break;

            //Player Entered Radar
            case "Player_Entered_Radar":

               print("entered radar");

               vision_system.enabled = true;
               break;

            //Player Exit Radar
            case "Player_Exited_Radar":

               print("exited radar");

               //PATROL TO CHARACTER HOLOGRAM
               if (vision_system.Alert_Bar_State())
               {
                  Decide_Behaviour("Lose_Sight_Player");
               }

               vision_system.enabled = false;
                  
               break;

            // Is seeing player
            case "Is_Seeing_Player":
                
               print("Is seeing Player");

               patrol_system.Stop_Patroling();

               holograms_system.Create_Hologram(the_target,false);

               break;

            // Lose Sight of player that were seeing before
            case "Lose_Sight_Player":
                
               print("Enemy lose sight of player");


               holograms_system.Create_Hologram(the_target,true);

               print("patrulhando para o holograma");
               patrol_system.Set_Patrol_Point_To_Go(holograms_system.hologram);
               patrol_system.Start_Patroling();

               break;

           
            default:
                Debug.Log("Opção desconhecida");
                break;
        }

    }





}
