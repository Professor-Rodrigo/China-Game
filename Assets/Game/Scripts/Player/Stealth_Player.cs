using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stealth_Player : MonoBehaviour
{

   CharacterController cC;

   bool is_stealth_mode_active;
   

   [Header("Neck Reference")]

   [SerializeField] Transform my_neck;


   [Header("Sit Neck position")]

   [SerializeField] float sit_position;  


   [Header("Standing Neck position")]

   [SerializeField] float stand_position;  


   void Start()
   {
      cC = GetComponent<CharacterController>();
   }


   public bool Input_Stealth()
   {
      // Enter Stealth Mode
      if (Input.GetButtonDown("Fire1") && !is_stealth_mode_active)
      {
         StartCoroutine(Delay_Stealth_Mode(true, 0.7f, sit_position));

         return is_stealth_mode_active;
      }

      // Exit Stealth Mode
      if (Input.GetButtonDown("Fire1") && is_stealth_mode_active)
      {
         StartCoroutine(Delay_Stealth_Mode(false, 0.5f, stand_position));

         return is_stealth_mode_active;
      }
     
      return is_stealth_mode_active;
   }



   IEnumerator Delay_Stealth_Mode(bool _stealth_value , float _cc_radius_value, float _neck_pos)
   {
      yield return new WaitForSeconds(0.1f);
      is_stealth_mode_active = _stealth_value;

      yield return new WaitForSeconds(0.2f);

      my_neck.position = new Vector3(my_neck.position.x, _neck_pos ,my_neck.position.z);


      cC.radius = _cc_radius_value;
   }
}
