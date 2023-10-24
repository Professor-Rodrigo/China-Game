using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
   
   public Enemys_Radar enemys_Radar;

   public Enemys_Vision enemys_Vision;

   public Enemys_Look enemys_Look;

   public Enemy_Hologram enemy_Hologram;

   public Patrol_Behaviour patrol_Behaviour;

   //  EVENTS

   //  [Space(50)]

   //  public UnityEvent Normal_Patrol;

   //  public UnityEvent Is_Seeing_Player;

   //  public UnityEvent Is_Checking;

    

   //  public void Decide_Behaviour(int _IA_case)
   //  {
   //      switch (_IA_case)
   //      {
   //          case 1:
                
                
   //              break;

   //          case 2:
               
   //             //  Is_Seeing_Player.Invoke();

   //              break;

   //          case 3:
                
   //              break;

   //          default:
   //              Debug.Log("Opção desconhecida");
   //              break;
   //      }

   //  }



   void Update()
   {
      if (enemys_Radar._return_player_target())
      {
         enemys_Vision.Set_Raycast_To_Target(enemys_Radar._return_player_target());
      

         if (enemys_Vision.is_seeing_player())
         {
            enemys_Look.Look_At_Target(enemys_Radar._return_player_target(), enemys_Vision.is_seeing_player());

            patrol_Behaviour.enabled = false;

         }
         else
         {
            patrol_Behaviour.enabled = true;
         }
      }

      else
      {
         patrol_Behaviour.enabled = true;

      }

      
   }

}
