using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys_Look : MonoBehaviour
{

    [Header("Rotation Settings")]
    [SerializeField] float rotation_speed = 2f;
   


   public void Look_At_Target(Transform _player_target, bool _is_seeing_player)
    {
        if (_is_seeing_player)
        {
            Vector3 _direction_to_object = _player_target.position - transform.position;
            _direction_to_object.y = 0f; // Mantenha apenas a direção horizontal

            // Calcule a rotação desejada usando Quaternion.LookRotation
            Quaternion _target_rotation = Quaternion.LookRotation(_direction_to_object);

            // Interpole suavemente entre a rotação atual e a rotação desejada
            transform.rotation = Quaternion.Slerp(transform.rotation, _target_rotation, Time.deltaTime * rotation_speed);
            
        }

    }

    
}
