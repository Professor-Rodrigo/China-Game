using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol_Behaviour : MonoBehaviour
{
    [Header("NavMesh Agent")]
    [SerializeField] NavMeshAgent nav_mesh;   


    [Header("Rest Time")]
    [SerializeField] float rest_time_between_patrols;
    
    //Patrol Settings
    Transform patrol_point;

    float distance_from_destiny;
    bool can_patrol;

    bool already_reached_patrol_point;



    [Header("Enemys AI")]
    [SerializeField] Enemy_Controller enemy_controller;


   public void Start_Patroling()
    {
        StopAllCoroutines();
        Disable_NavMesh(true);
        
        StartCoroutine(Reached_Patrol_Point());

    }


    public void Stop_Patroling()
    {
        StopAllCoroutines();
        can_patrol = false;
        Disable_NavMesh(false);
    }



    public void Set_Patrol_Point_To_Go(Transform _target_point)
    {
        patrol_point = _target_point;
        already_reached_patrol_point = false;
    }



    void Update() => Patrol_To_Point();




    void Patrol_To_Point()
    {
        if (can_patrol)
        {
            nav_mesh.SetDestination(patrol_point.position);

            distance_from_destiny = Vector3.Distance(nav_mesh.gameObject.transform.position, patrol_point.position);
        
            Calculate_Distance_From_Patrol_Point();
        } 
    }



    void Calculate_Distance_From_Patrol_Point()
    {
        if (distance_from_destiny < 1.5f && !already_reached_patrol_point)
        {
            can_patrol = false;
            patrol_point.gameObject.SetActive(false);

            already_reached_patrol_point = true;
            StartCoroutine(Reached_Patrol_Point());

            enemy_controller.Decide_Behaviour("Patrol_to_Next_Point");

        }
    }



    IEnumerator Reached_Patrol_Point()
    {
        yield return new WaitForSeconds(rest_time_between_patrols);
        can_patrol = true;

    }




    public void Disable_NavMesh(bool _state)
    {
        nav_mesh.enabled = _state;
    }



}
