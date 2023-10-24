using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stealth_Player : MonoBehaviour
{

    bool is_stealth_mode_active;
    CharacterController cC;

   public Transform neck;

   public float sentado;

   public float emPE;


    void Start()
    {
        cC = GetComponent<CharacterController>();
    }


    public bool Input_Stealth()
   {
      // Enter Stealth Mode
      if (Input.GetButtonDown("Fire1") && !is_stealth_mode_active)
      {
         StartCoroutine(Delay_Stealth_Mode(true, 0.7f));
         neck.position = new Vector3(neck.position.x,sentado ,neck.position.z);
         return is_stealth_mode_active;
      }

      // Exit Stealth Mode
      if (Input.GetButtonDown("Fire1") && is_stealth_mode_active)
      {
         StartCoroutine(Delay_Stealth_Mode(false, 0.5f));
         neck.position = new Vector3(neck.position.x, emPE ,neck.position.z);

         return is_stealth_mode_active;
      }
     
      return is_stealth_mode_active;
   }


   IEnumerator Delay_Stealth_Mode(bool _stealth_value , float value)
   {
      yield return new WaitForSeconds(0.1f);
      is_stealth_mode_active = _stealth_value;

      yield return new WaitForSeconds(0.2f);
      cC.radius = value;
   }
}
