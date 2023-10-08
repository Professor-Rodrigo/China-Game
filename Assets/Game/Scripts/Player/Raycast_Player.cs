using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast_Player : MonoBehaviour
{

     private RaycastHit hitInfo; // Armazena informações sobre o que o Raycast atingiu

    public float alturaDoPontoDeColisao;
    public float  profundidadeDoPontoDeColisao;

    void Update()
    {
        // Realize o Linecast
            if (Physics.Linecast(transform.position, transform.forward, out hitInfo))
            {

                // Obtenha a altura (coordenada Y) do ponto de colisão
                alturaDoPontoDeColisao = hitInfo.point.y;

                // Obtenha a profundidade (coordenada Z) do ponto de colisão
                profundidadeDoPontoDeColisao = hitInfo.point.z;

                Vector3 direcao = hitInfo.point - transform.position;    
                Debug.DrawRay(transform.position, direcao, Color.red);
            }


       
    }


           


}
