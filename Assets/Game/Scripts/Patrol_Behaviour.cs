using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol_Behaviour : MonoBehaviour
{
    [Header("NavMesh Agent")]
    [SerializeField] NavMeshAgent nav_mesh;   


    [Header("Patrol Settings")]

    [SerializeField] float rest_time_between_patrols;
    
    float distance_from_destiny;
    bool can_patrol = true;
    public Transform patrol_point;

    public bool started_coroutine;

    public Enemy_Hologram enemy_Hologram;

    void OnEnable()
    {
        print("ligou");
        StopAllCoroutines();
        StartCoroutine(Reached_Patrol_Point(0));
        Disable_NavMesh(true);
    }

    void OnDisable()
    {
        print("desligou");
        StopAllCoroutines();
        can_patrol = false;
        Disable_NavMesh(false);
    }


    public void Set_Patrol_Point_To_Go(Transform _target_point)
    {
        patrol_point = _target_point;
        started_coroutine = false;
    }


    void Update()
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
        if (distance_from_destiny < 1.5f && !started_coroutine)
        {
            //patrol_point.gameObject.SetActive(false);

            can_patrol = false;

            started_coroutine = true;
            StartCoroutine(Reached_Patrol_Point(1));

        }
    }


    IEnumerator Reached_Patrol_Point(int _index)
    {
        yield return new WaitForSeconds(rest_time_between_patrols);
        can_patrol = true;

        // if (enemy_Hologram.hologram.gameObject.activeSelf)
        // {
        //     Set_Patrol_Point_To_Go(enemy_Hologram.hologram);
        // }
        // else
        // {
        //     Set_Patrol_Point_To_Go(GetComponent<Patrol_Points>().Return_Next_Path_Point(_index));

        // }

        Set_Patrol_Point_To_Go(GetComponent<Patrol_Points>().Return_Next_Path_Point(_index));

    }



    public void Disable_NavMesh(bool _state)
    {
        nav_mesh.enabled = _state;
    }
}
