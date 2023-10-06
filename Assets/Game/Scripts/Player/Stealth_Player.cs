using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stealth_Player : MonoBehaviour
{

    bool is_stealth_mode_active;

    public bool Input_Stealth()
   {
      // Enter Stealth Mode
      if (Input.GetButtonDown("Fire1") && !is_stealth_mode_active)
      {
         StartCoroutine(Delay_Stealth_Mode(true));
         return is_stealth_mode_active;
      }

      // Exit Stealth Mode
      if (Input.GetButtonDown("Fire1") && is_stealth_mode_active)
      {
         StartCoroutine(Delay_Stealth_Mode(false));
         return is_stealth_mode_active;
      }
     
      return is_stealth_mode_active;
   }


   IEnumerator Delay_Stealth_Mode(bool _stealth_value)
   {
      yield return new WaitForSeconds(0.1f);
      is_stealth_mode_active = _stealth_value;
   }
}
