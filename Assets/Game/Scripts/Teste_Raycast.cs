using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste_Raycast : MonoBehaviour
{

    public Transform player; // Referência ao objeto Player
    public Transform my_target;
    private RaycastHit hitInfo; // Armazena informações sobre o que o Raycast atingiu
    public float distancia;
    public float max_distance;
    public bool saw_player;
    public Transform head; // Referência ao objeto Player


    public BoxCollider radar;

    [Space(20)]

    public float velocidadeRotacao = 2f; 

    [Space(20)]
    public Transform hologram;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = my_target;
            radar.enabled = false;
        }
    }


    void Update()
    {
        distancia = Vector3.Distance(my_target.position, head.transform.position);

        // Verifique se há um jogador definido
        if (player != null && distancia < max_distance)
        {
            // Calcule a direção do Raycast do cubo ao jogador
            Vector3 direcao = player.position - head.transform.position;

            // Realize o Linecast
            if (Physics.Linecast(head.transform.position, player.position, out hitInfo))
            {

                if (hitInfo.collider.gameObject.tag == "Player")
                {
                    // O Raycast atingiu o jogador
                    saw_player = true;
                    Looking();
                }
                else
                {
                    Create_Hologram();
                    player = null;
                    radar.enabled = true;
                }

                direcao = hitInfo.point - head.transform.position;    
                Debug.DrawRay(head.transform.position, direcao, Color.red);

            }

        }

    }


    void Looking()
    {
        Vector3 direcaoParaObjeto = player.position - transform.position;
        direcaoParaObjeto.y = 0f; // Mantenha apenas a direção horizontal

        // Calcule a rotação desejada usando Quaternion.LookRotation
        Quaternion rotacaoDesejada = Quaternion.LookRotation(direcaoParaObjeto);

        // Interpole suavemente entre a rotação atual e a rotação desejada
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoDesejada, Time.deltaTime * velocidadeRotacao);
    }


    void Create_Hologram()
    {
        if (saw_player)
        {
            hologram.transform.position = new Vector3(player.transform.position.x, 0f, player.transform.position.z);
            hologram.transform.rotation = Quaternion.Euler(0f,player.transform.rotation.y,0f);

            saw_player = false;
        }
    }
}
