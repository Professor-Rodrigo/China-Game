using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detections_Bar : MonoBehaviour
{
    public float progress_bar;

    public float multiplier;

    public bool allowed;


    // Update is called once per frame
    void Update()
    {

        if (allowed)
        {
            progress_bar += multiplier * Time.deltaTime;    
            
        }
    }
}
