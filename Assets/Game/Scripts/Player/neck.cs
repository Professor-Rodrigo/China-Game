using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class neck : MonoBehaviour
{
    public Transform referencia;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x,referencia.transform.position.y, transform.position.z);
    }
}
