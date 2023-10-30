using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Hologram : MonoBehaviour
{

    public Transform hologram;




    public void Create_Hologram(Transform _player_target , bool _active_state)
    {
        hologram.gameObject.SetActive(_active_state);
        hologram.transform.position = new Vector3(_player_target.transform.position.x, 0f, _player_target.transform.position.z);
        hologram.transform.rotation = Quaternion.Euler(0f, _player_target.transform.rotation.y, 0f);
    }


    public bool hologram_state()
    {
        return hologram.gameObject.activeSelf;
    }
    
}
