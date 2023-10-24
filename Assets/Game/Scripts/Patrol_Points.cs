using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol_Points : MonoBehaviour
{
    [Header("Patrol Points")]

    [SerializeField] Transform[] patrol_points;
    int index_patrol_point = 0;



    public Transform Return_Next_Path_Point(int _plus_index)
    {
        index_patrol_point += _plus_index;
        Reset_Patrol_Points();
        return patrol_points[index_patrol_point];
    }



    void Reset_Patrol_Points()
    {
        if(index_patrol_point >= patrol_points.Length)
        {
            index_patrol_point = 0;
        }


        if (index_patrol_point <= -1)
        {
            index_patrol_point = patrol_points.Length - 1;
        }
    }
}
