using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy_AI : MonoBehaviour
{

//         public bool no_repeat;


//    public Patrol_Behaviour patrol_Behaviour;

//    public Patrol_Points patrol_Points;
    
//     public Enemy_Hologram enemy_Hologram;

//     //  EVENTS
//     [Space(50)]

//     public UnityEvent Normal_Patrol;

//     public UnityEvent Is_Seeing_Player;

//     public UnityEvent Is_Checking;

    
//     void Start()
//     {
//         Decide_Behaviour(1);
//     }

//     public void Decide_Behaviour(int _IA_case)
//     {
//         switch (_IA_case)
//         {
//             case 1:
//                 if (!enemy_Hologram.hologram.gameObject.activeSelf)
//                 {
//                     Debug.Log("normal_Patrol");
//                     Normal_Patrol.Invoke();
//                     no_repeat = false;
//                     patrol_Behaviour.Set_Patrol_Point_To_Go(patrol_Points.Return_Next_Path_Point());
//                 }
                
//                 break;

//             case 2:
//                 Debug.Log("Seeing_Player");
//                 no_repeat = true;

//                 Is_Seeing_Player.Invoke();
//                 break;

//             case 3:
//                 if (!enemy_Hologram.hologram.gameObject.activeSelf)
//                 {
//                     Debug.Log("Checking");
//                     Is_Checking.Invoke();
//                     no_repeat = false;

//                     patrol_Behaviour.Set_Patrol_Point_To_Go(enemy_Hologram.hologram);
//                 }
               
//                 break;

//             default:
//                 Debug.Log("Opção desconhecida");
//                 break;
//         }

//     }



}
